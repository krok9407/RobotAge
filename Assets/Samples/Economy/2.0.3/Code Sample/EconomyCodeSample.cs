using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Economy;
using Unity.Services.Economy.Model;

namespace EconomySample
{
    public class EconomyCodeSample : MonoBehaviour
    {
        private async void Awake()
        {
            // Economy needs to be initialized and then the user must sign in.
            await UnityServices.InitializeAsync();
            await AuthenticationService.Instance.SignInAnonymouslyAsync();

            // NOTE: You need to set up your Economy configuration with the items used in here before running this sample,
            // or alternatively alter the sample to to work with your current configuration.
            await ListAllCurrencyIds();

            await UpdatePlayersBalance("GOLD", 10);

            await AddItemToPlayersInventory("SWORD", "MY_ID");

            Dictionary<string, object> instanceData = new Dictionary<string, object>
            {
                { "rarity", "purple" }
            };
            await UpdatePlayersItemInstanceData("MY_ID", instanceData);

            await MakeVirtualPurchase("VIRTUAL_PURCHASE");

            await RedeemApplePurchase("APPLE_PURCHASE", "PURCHASE_RECEIPT", 10, "USD");

            await WriteLockExample();
        }

        private async Task ListAllCurrencyIds()
        {
            try
            {
                List<CurrencyDefinition> currencies = await EconomyService.Instance.Configuration.GetCurrenciesAsync();

                List<string> currenciesIds = new List<string>();
                foreach (var currency in currencies)
                {
                    currenciesIds.Add(currency.Id);
                }

                Debug.Log($"Currencies in config: {string.Join(", ", currenciesIds)}");
            }
            catch (EconomyException e)
            {
                Debug.LogError(e);
            }
        }

        private async Task UpdatePlayersBalance(string currencyId, int newBalance)
        {
            try
            {
                PlayerBalance updatedBalance = await EconomyService.Instance.PlayerBalances.SetBalanceAsync(currencyId, newBalance);
                Debug.Log($"{updatedBalance.CurrencyId} set to {updatedBalance.Balance}");
            }
            catch (EconomyRateLimitedException e)
            {
                Debug.LogError($"{e} - Retry after {e.RetryAfter}");
            }
            catch (EconomyException e)
            {
                Debug.LogError(e);
            }
        }

        private async Task AddItemToPlayersInventory(string itemId, string instanceId)
        {
            try
            {
                AddInventoryItemOptions options = new AddInventoryItemOptions() { PlayersInventoryItemId = instanceId };
                PlayersInventoryItem item = await EconomyService.Instance.PlayerInventory.AddInventoryItemAsync(itemId, options);
                Debug.Log($"Added {item.InventoryItemId} with ID {item.PlayersInventoryItemId} to player's inventory.");
            }
            catch (EconomyValidationException e)
            {
                foreach (var errorDetail in e.Details)
                {
                    foreach (var message in errorDetail.Messages)
                    {
                        Debug.LogError(message);
                    }
                }
            }
            catch (EconomyRateLimitedException e)
            {
                Debug.LogError($"{e} - Retry after {e.RetryAfter}");
            }
            catch (EconomyException e)
            {
                Debug.LogError(e);
            }
        }

        private async Task UpdatePlayersItemInstanceData(string playersInventoryItemId, Dictionary<string, object> instanceData)
        {
            try
            {
                PlayersInventoryItem item = await EconomyService.Instance.PlayerInventory.UpdatePlayersInventoryItemAsync(playersInventoryItemId, instanceData);
                Debug.Log($"Added instance data to item with ID {item.PlayersInventoryItemId}");
            }
            catch (EconomyValidationException e)
            {
                foreach (var errorDetail in e.Details)
                {
                    foreach (var message in errorDetail.Messages)
                    {
                        Debug.LogError(message);
                    }
                }
            }
            catch (EconomyRateLimitedException e)
            {
                Debug.LogError($"{e} - Retry after {e.RetryAfter}");
            }
            catch (EconomyException e)
            {
                Debug.LogError(e);
            }
        }

        private async Task MakeVirtualPurchase(string purchaseId)
        {
            try
            {
                MakeVirtualPurchaseResult result = await EconomyService.Instance.Purchases.MakeVirtualPurchaseAsync(purchaseId);
                Debug.Log($"Successfully processed virtual purchase");
            }
            catch (EconomyValidationException e)
            {
                foreach (var errorDetail in e.Details)
                {
                    foreach (var message in errorDetail.Messages)
                    {
                        Debug.LogError(message);
                    }
                }
            }
            catch (EconomyRateLimitedException e)
            {
                Debug.LogError($"{e} - Retry after {e.RetryAfter}");
            }
            catch (EconomyException e)
            {
                Debug.LogError(e);
            }
        }

        private async Task RedeemApplePurchase(string purchaseId, string receipt, int localCost, string localCurrency)
        {
            try
            {
                RedeemAppleAppStorePurchaseArgs args = new RedeemAppleAppStorePurchaseArgs(purchaseId, receipt, localCost, localCurrency);
                await EconomyService.Instance.Purchases.RedeemAppleAppStorePurchaseAsync(args);
                Debug.Log($"Successfully redeemed Apple purchase");
            }
            catch (EconomyAppleAppStorePurchaseFailedException e)
            {
                Debug.LogError(e);
            }
            catch (EconomyValidationException e)
            {
                foreach (var errorDetail in e.Details)
                {
                    foreach (var message in errorDetail.Messages)
                    {
                        Debug.LogError(message);
                    }
                }
            }
            catch (EconomyRateLimitedException e)
            {
                Debug.LogError($"{e} - Retry after {e.RetryAfter}");
            }
            catch (EconomyException e)
            {
                Debug.LogError(e);
            }
        }

        private async Task WriteLockExample()
        {
            try
            {
                // Each balance has its own write lock value
                GetBalancesResult result = await EconomyService.Instance.PlayerBalances.GetBalancesAsync();
                PlayerBalance goldBalance = result.Balances.Single(balance => balance.CurrencyId == "GOLD");

                // You'll notice that each time your run this method, the write lock will increase by 1.
                // This happens because we use it below in the set balance call.
                Debug.Log($"Writelock for gold balance: {goldBalance.WriteLock}");

                SetBalanceOptions options = new SetBalanceOptions() { WriteLock = goldBalance.WriteLock };
                await EconomyService.Instance.PlayerBalances.SetBalanceAsync("GOLD", 50, options);
            }
            catch (EconomyValidationException e)
            {
                foreach (var errorDetail in e.Details)
                {
                    foreach (var message in errorDetail.Messages)
                    {
                        Debug.LogError(message);
                    }
                }
            }
            catch (EconomyRateLimitedException e)
            {
                Debug.LogError(e);
            }
            catch (EconomyException e)
            {
                Debug.LogError(e);
            }
        }
    }
}
