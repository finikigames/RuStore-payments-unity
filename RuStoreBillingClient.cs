using UnityEngine;

namespace RuStore.Billing {
    #if UNITY_ANDROID
    public class RuStoreBillingClient : IRuStoreBillingClient {
        private readonly AndroidJavaObject _ruStoreObject = new AndroidJavaObject("ru.rustore.sdk.billingclient.RuStoreBillingClient");

        private PurchaseUseCase _purchaseUseCase;
        
        public void Init(RuStoreBillingConfig config) {
            using AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject context = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        
            Debug.Log(_ruStoreObject);
            _ruStoreObject.Call("init", 
                context, 
                config.ApplicationId, 
                config.ConsoleApplicationId, 
                config.DeeplinkPrefix);
        }

        public void PurchaseProduct(string productId, 
                                    string orderId, 
                                    int quantity, 
                                    string payload = null) {
            CheckPurchaseInitialize();

            _purchaseUseCase.PurchaseProduct(productId, orderId, quantity, payload);
        }

        private void CheckPurchaseInitialize() {
            if (_purchaseUseCase != null) return;

            _purchaseUseCase = new PurchaseUseCase(_ruStoreObject);
        }
    }
    #endif
}