namespace RuStore.Billing {
    public interface IRuStoreBillingClient {
        void Init(RuStoreBillingConfig config);
        void PurchaseProduct(string productId, string orderId, int quantity, string payload = null);
    }
}