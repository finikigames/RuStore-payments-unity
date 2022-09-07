using UnityEngine;
using Object = UnityEngine.Object;

namespace RuStore.Billing {
    public class RuStoreBilling : MonoBehaviour {
        private static IRuStoreBillingClient s_billing;
        private static bool s_isInitialized;
        private static readonly object s_syncRoot = new Object();

        [SerializeField] private string ApplicationId;
        [SerializeField] private string ConsoleApplicationId;
        [SerializeField] private string DeeplinkPrefix;

        public static IRuStoreBillingClient Instance
        {
            get
            {
                if (s_billing == null)
                {
                    lock (s_syncRoot) {
#if UNITY_ANDROID
                        if (s_billing == null && Application.platform == RuntimePlatform.Android) {
                            s_billing = new RuStoreBillingClient();
                        }
#endif
                        if (s_billing == null) {
                            s_billing = new RuStoreBillingClientDummy();
                        }
                    }
                }

                return s_billing;
            }
        }

        private void Awake() {
            if (!s_isInitialized)
            {
                s_isInitialized = true;
                DontDestroyOnLoad(gameObject);
                SetupBilling();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void SetupBilling() {
            RuStoreBillingConfig configuration = new RuStoreBillingConfig
            {
                ApplicationId = ApplicationId,
                ConsoleApplicationId = ConsoleApplicationId,
                DeeplinkPrefix = DeeplinkPrefix
            };
            
            Instance.Init(configuration);
        }
    }
}