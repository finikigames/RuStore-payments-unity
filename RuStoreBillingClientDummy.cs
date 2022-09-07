namespace RuStore.Billing {
    // For unity editor
    public class RuStoreBillingClientDummy : IRuStoreBillingClient {
        public void Init(RuStoreBillingConfig config) {
            
        }

        public void PurchaseProduct(string productId, string orderId, int quantity, string payload = null) {
            
        }
    }
}