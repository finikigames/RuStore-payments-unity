using JetBrains.Annotations;
using UnityEngine;

namespace RuStore.Billing {
    public class PurchaseUseCase {
        private AndroidJavaObject _purchaseObject;
    
        public PurchaseUseCase(AndroidJavaObject ruStoreObject) {
            _purchaseObject = ruStoreObject.Call<AndroidJavaObject>("getPurchases");
        }

        public void PurchaseProduct(string productId, [CanBeNull] string orderId, int? quantity, [CanBeNull] string payload) {
            using AndroidJavaClass activityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject context = activityClass.GetStatic<AndroidJavaObject>("currentActivity");

            _purchaseObject.Call("purchaseProduct", context, productId, orderId, quantity, payload);
        }
    }
}