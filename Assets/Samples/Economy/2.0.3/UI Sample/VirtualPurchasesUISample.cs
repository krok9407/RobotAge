using TMPro;
using Unity.Services.Economy;
using Unity.Services.Economy.Model;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;

public class VirtualPurchasesUISample : MonoBehaviour
{
    // Get config
    [SerializeField]
    TextMeshProUGUI m_GetConfigsText;
    [SerializeField]
    TMP_InputField m_GetPurchaseInput;

    // Make purchase
    [SerializeField]
    TextMeshProUGUI m_MakePurchaseText;
    [SerializeField]
    TMP_InputField m_MakePurchaseId;

    async void Awake()
    {
        await UnityServices.InitializeAsync();

        AuthenticationService.Instance.SignedIn += delegate
        {
            Debug.Log("All signed in and ready to go!");
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync();
    }

    public async void FetchPurchases()
    {
        if (!IsAuthenticationSignedIn())
        {
            return;
        }


        string outputString = "";
        foreach (var item in await EconomyService.Instance.Configuration.GetVirtualPurchasesAsync())
        {
            outputString += $"{FormatPurchase(item)}\n";
        }
        m_MakePurchaseText.text = "";
        m_GetConfigsText.text = outputString;
    }

    public async void FetchPurchase()
    {
        if (!IsAuthenticationSignedIn())
        {
            return;
        }

        if (string.IsNullOrEmpty(m_GetPurchaseInput.text))
        {
            Debug.Log("Please enter a purchase ID");
            return;
        }

        VirtualPurchaseDefinition purchase = await EconomyService.Instance.Configuration.GetVirtualPurchaseAsync(m_GetPurchaseInput.text);
        if (purchase != null)
        {
            m_MakePurchaseText.text = "";
            m_GetConfigsText.text = FormatPurchase(purchase);
        }
        else
        {
            m_GetConfigsText.text = "No item found with that ID";
        }
    }

    public async void MakePurchase()
    {
        if (!IsAuthenticationSignedIn())
        {
            return;
        }

        string purchaseId = m_MakePurchaseId.text;

        if (string.IsNullOrEmpty(m_MakePurchaseId.text))
        {
            Debug.Log("Please enter a purchase ID");
            return;
        }

        MakeVirtualPurchaseResult result = await EconomyService.Instance.Purchases.MakeVirtualPurchaseAsync(purchaseId);

        m_GetConfigsText.text = "";

        m_MakePurchaseText.text = FormatMakePurchaseResult(result);
    }

    static string FormatPurchase(VirtualPurchaseDefinition purchase)
    {
        string outputString = "-----";
        outputString += $"\nID: {purchase.Id}, Name: {purchase.Name}\n";
        outputString += "\n**Costs:**\n";
        foreach (var cost in purchase.Costs)
        {
            outputString += $"- {cost.Amount} {cost.Item.GetReferencedConfigurationItem().Name}\n";
        }

        outputString += "\n**Rewards:**\n";
        foreach (var reward in purchase.Rewards)
        {
            outputString += $"- {reward.Amount} {reward.Item.GetReferencedConfigurationItem().Name}\n";
        }
        return outputString;
    }

    static string FormatMakePurchaseResult(MakeVirtualPurchaseResult result)
    {
        string outputString = "-----";
        outputString += "\n**You purchased:**\n";

        foreach (var currency in result.Rewards.Currency)
        {
            outputString += $"- {currency.Amount} {currency.Id}\n";
        }

        foreach (var item in result.Rewards.Inventory)
        {
            outputString += $"- {item.Amount} {item.Id}\n";
        }
        return outputString;
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
