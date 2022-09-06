using UnityEngine;

namespace RuStore.Billing {
    public class RuStoreBillingClient : IRuStoreBillingClient {
        private readonly AndroidJavaObject _ruStoreClass = new AndroidJavaObject("ru.rustore.sdk.billingclient.RuStoreBillingClient");
        
        public void Init(RuStoreBillingConfig config)
        {
            using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject playerActivity = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
        
                Debug.Log(_ruStoreClass);
                _ruStoreClass.Call("init", 
                    playerActivity, 
                               config.ApplicationId, 
                               config.ConsoleApplicationId, 
                               config.DeeplinkPrefix);
            }
        }
    }
}