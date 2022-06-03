using System.Collections.Generic;
using TMPro;
using Unity.Services.Core;
using Unity.Services.Economy;
using Unity.Services.Economy.Model;
using Unity.Services.Authentication;
using UnityEngine;

public class CurrenciesUISample : MonoBehaviour
{
    // Get configs
    [SerializeField]
    TextMeshProUGUI m_GetConfigsText;
    [SerializeField]
    TMP_InputField m_GetCurrencyIdInput;

    // Get balances
    [SerializeField]
    TextMeshProUGUI m_GetBalancesText;

    // Set balance
    [SerializeField]
    TextMeshProUGUI m_SetBalanceText;
    [SerializeField]
    TMP_InputField m_SetBalanceCurrencyIdInput;
    [SerializeField]
    TMP_InputField m_SetBalanceNewBalanceInput;

    [SerializeField]
    int m_ItemsPerFetch = 20;

    private GetBalancesResult m_LatestGetBalancesResult;
    bool m_HasNext;

    async void Awake()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += delegate
        {
            Debug.Log("All signed in and ready to go!");
            Debug.Log($"Player ID is {AuthenticationService.Instance.PlayerId}");
            Debug.Log($"Access Token is {AuthenticationService.Instance.AccessToken}");
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void FetchCurrencies()
    {
        if (!IsAuthenticationSignedIn())
        {
            return;
        }

        string allCurrencies = "";
        List<CurrencyDefinition> currencies = await EconomyService.Instance.Configuration.GetCurrenciesAsync();
        ClearOutputTextBoxes();

        if (currencies.Count == 0)
        {
            m_GetConfigsText.text = "No currencies";
        }
        else
        {
            foreach (var currency in currencies)
            {
                allCurrencies += $"ID: {currency.Id}, Name: {currency.Name}, Max Allowed: {currency.Max}, Initial Value: {currency.Initial}\n";
            }
            m_GetConfigsText.text = allCurrencies;
        }
    }

    public async void FetchCurrency()
    {
        if (!IsAuthenticationSignedIn())
        {
            return;
        }

        if (string.IsNullOrEmpty(m_GetCurrencyIdInput.text))
        {
            Debug.Log("Please enter a currency ID");
            return;
        }

        CurrencyDefinition currency = await EconomyService.Instance.Configuration.GetCurrencyAsync(m_GetCurrencyIdInput.text);
        ClearOutputTextBoxes();

        if (currency == null)
        {
            m_GetConfigsText.text = "Currency not found";
        }
        else
        {
            m_GetConfigsText.text = $"ID: {currency.Id}, Name: {currency.Name}, Max Allowed: {currency.Max}, Initial Value: {currency.Initial}\n";
        }
    }

    public async void FetchBalances()
    {
        if (!IsAuthenticationSignedIn())
        {
            return;
        }

        string outputString = "";

        GetBalancesOptions options = new GetBalancesOptions
        {
            ItemsPerFetch = m_ItemsPerFetch
        };
        GetBalancesResult result = await EconomyService.Instance.PlayerBalances.GetBalancesAsync(options);

        m_LatestGetBalancesResult = result;
        m_HasNext = result.HasNext;

        if (result.Balances.Count == 0)
        {
            m_GetBalancesText.text = "No balances";
        }
        else
        {
            foreach (var balance in result.Balances)
            {
                CurrencyDefinition currency = await EconomyService.Instance.Configuration.GetCurrencyAsync(balance.CurrencyId);
                if (currency != null)
                {
                    var maxBalance = currency.Max > 0 ? currency.Max.ToString() : "Unlimited";
                    outputString += $"{currency.Id}: {balance.Balance} / {maxBalance}\n";
                }
                else
                {
                    outputString += $"{balance.CurrencyId}: {balance.Balance} (no longer exists in config)\n";
                }

                ClearOutputTextBoxes();
                m_GetBalancesText.text = outputString;
            }
        }
    }

    public async void FetchNextBalances()
    {
        if (!IsAuthenticationSignedIn())
        {
            return;
        }

        if (m_LatestGetBalancesResult == null)
        {
            Debug.Log("You need to fetch your first set of results first.");
            return;
        }

        string outputString = "";

        if (!m_HasNext)
        {
            Debug.Log("Economy: There are no available pages of results.");
            return;
        }

        Debug.Log("Getting next page...");

        GetBalancesResult nextResult = await m_LatestGetBalancesResult.GetNextAsync(m_ItemsPerFetch);

        m_LatestGetBalancesResult = nextResult;
        m_HasNext = nextResult.HasNext;

        List<PlayerBalance> nextBalances = nextResult.Balances;

        foreach (var balance in nextResult.Balances)
        {
            CurrencyDefinition currency = await EconomyService.Instance.Configuration.GetCurrencyAsync(balance.CurrencyId);
            if (currency != null)
            {
                var maxBalance = currency.Max > 0 ? currency.Max.ToString() : "Unlimited";
                outputString += $"{currency.Name}: {balance.Balance} / {maxBalance}\n";
            }

            ClearOutputTextBoxes();
            m_GetBalancesText.text += outputString;
        }
    }

    public async void SetBalance()
    {
        if (!IsAuthenticationSignedIn())
        {
            return;
        }
        ;

        if (string.IsNullOrEmpty(m_SetBalanceCurrencyIdInput.text))
        {
            Debug.Log("Please enter a currency ID");
            return;
        }

        string outputString = "";

        PlayerBalance playerBalance = await EconomyService.Instance.PlayerBalances.SetBalanceAsync(m_SetBalanceCurrencyIdInput.text, int.Parse(m_SetBalanceNewBalanceInput.text));
        ClearOutputTextBoxes();
        if (playerBalance != null)
        {
            outputString += $"{playerBalance.CurrencyId} has been set to {playerBalance.Balance}";
        }

        m_SetBalanceText.text = outputString;
    }

    void ClearOutputTextBoxes()
    {
        m_GetConfigsText.text = "";
        m_GetBalancesText.text = "";
        m_SetBalanceText.text = "";
    }

    static bool IsAuthenticationSignedIn()
    {
        if (!AuthenticationService.Instance.IsSignedIn)
        {
            Debug.Log("Wait until sign in is done");
            return false;
        }

        return true;
    }
}
