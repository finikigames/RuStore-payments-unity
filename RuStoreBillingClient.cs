using UnityEngine;

namespace RuStore.Billing {
    public class RuStoreBillingClient : IRuStoreBillingClient {
        private readonly AndroidJavaClass _ruStoreClass = new AndroidJavaClass("ru.rustore.sdk.billingclient.RuStoreBillingClient");
        
        public void Init(RuStoreBillingConfig config)
        {
            using (AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                AndroidJavaObject playerActivityContext = activityClass.GetStatic<AndroidJavaObject>("currentActivity");
                _ruStoreClass.CallStatic("Init", 
                               playerActivityContext, 
                               config.ApplicationId, 
                               config.ConsoleApplicationId, 
                               config.DeeplinkPrefix);
            }
        }
    }
}