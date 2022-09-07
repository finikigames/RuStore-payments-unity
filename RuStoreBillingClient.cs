using UnityEngine;

namespace RuStore.Billing {
    #if UNITY_ANDROID
    public class RuStoreBillingClient : IRuStoreBillingClient {
        private readonly AndroidJavaObject _ruStoreObject = new AndroidJavaObject("ru.rustore.sdk.billingclient.RuStoreBillingClient");
        
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
                                    string payload) {
            using AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject context = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

            //var field = _ruStoreObject.Call("getPurchases")
        }
    }
    #endif
}