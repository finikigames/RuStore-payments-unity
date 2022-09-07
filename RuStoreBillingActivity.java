package ru.rustore;

import android.content.Intent;
import com.unity3d.player.UnityPlayerActivity;
import ru.rustore.sdk.billingclient.RuStoreBillingClient;

public class RuStoreBillingActivity extends UnityPlayerActivity {
    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        RuStoreBillingClient.INSTANCE.onNewIntent(intent);
    }
}