using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener //для получения сообщений из Unity Purchasing
{
    IStoreController m_StoreController;

    public static string Coins_0 = "com.GamesdMurdock.ShipClicker.coins_0"; //многоразовые - consumable
    public static string Coins_1 = "com.GamesdMurdock.ShipClicker.coins_1"; //многоразовые - consumable
    public static string Coins_2 = "com.GamesdMurdock.ShipClicker.coins_2"; //многоразовые - consumable
    public static string Coins_3 = "com.GamesdMurdock.ShipClicker.coins_3"; //многоразовые - consumable
    public static string Coins_4 = "com.GamesdMurdock.ShipClicker.coins_4"; //многоразовые - consumable

    void Start()
    {
        InitializePurchasing();
    }

    void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Прописываем свои товары для добавления в билдер
        builder.AddProduct(Coins_0, ProductType.Consumable);
        builder.AddProduct(Coins_1, ProductType.Consumable);
        builder.AddProduct(Coins_2, ProductType.Consumable);
        builder.AddProduct(Coins_3, ProductType.Consumable);
        builder.AddProduct(Coins_4, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyProduct(string productName)
    {
        m_StoreController.InitiatePurchase(productName);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        var product = args.purchasedProduct;

        if (product.definition.id == Coins_0)
        {
            print(2);
        }

        if (product.definition.id == Coins_1)
        {
            print(2);
        }

        if (product.definition.id == Coins_2)
        {
            print(2);
        }

        if (product.definition.id == Coins_3)
        {
            print(2);
        }
        if (product.definition.id == Coins_4)
        {

            print(2);
        }

        Debug.Log($"Purchase Complete - Product: {product.definition.id}");

        return PurchaseProcessingResult.Complete;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"In-App Purchasing initialize failed: {error}");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("In-App Purchasing successfully initialized");
        m_StoreController = controller;
    }
}
