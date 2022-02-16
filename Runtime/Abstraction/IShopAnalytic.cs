namespace GameWrriors.AnalyticDomain.Abstraction
{
    public interface IShopAnalytic
    {
        void PurchaseShopPack(string packId);
        void ShopPackClick(string itemName, string location);
        void ShopOpen(string location);
        void PurchaseShopPack(string itemName, string purchaseId, string currencyId, float price, string location, string transactionId);
    }
}
