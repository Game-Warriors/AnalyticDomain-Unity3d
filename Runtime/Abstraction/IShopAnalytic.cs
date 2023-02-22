namespace GameWarriors.AnalyticDomain.Abstraction
{
    public interface IShopAnalytic
    {

        void ShopOpen(string placement);
        void PurchaseStartSuccess(string sku, string packName, string currency, double price, string orderId);
        void PurchaseStartFailed(string sku, string packName, string reason);
        void PurchaseSuccessResult(string sku, string packName, string currency, double price, string orderId);
        void PurchaseFailedResult(string sku, string packName, string currency, double price, string orderId, string reason);
        void PurchaseComplete(string sku, string packName, string currency, double price, string orderId);
        void ShopPackClick(string sku, string packName);
    }
}
