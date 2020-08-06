package local.phouse.powerpointcontrol;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.os.Bundle;
import android.view.View;
import android.view.WindowManager;
import android.widget.Button;

import local.phouse.powerpointcontrol.api.PowerPoint;

public class ControlActivity extends Activity {
    //Network Elements
    private PowerPoint API = null;

    //Activity Elements
    private Button nextSlide_button;
    private Button previousSlide_button;
    private Button blackOut_button;
    private Button startSlideShow_button;
    private Button endSlideShow_button;

    @SuppressLint("SourceLockedOrientationActivity")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        setContentView(R.layout.activity_control);

        Bundle bundle = getIntent().getExtras();

        if(bundle.getString(MainActivity.EXTRA_URL) != null){
            this.API = new PowerPoint(bundle.getString(MainActivity.EXTRA_URL));
        }

        //Element Assignment
        nextSlide_button = (Button) findViewById(R.id.nextSlide_button);
        previousSlide_button = (Button) findViewById(R.id.previousSlide_button);
        blackOut_button = (Button) findViewById(R.id.blackOut_button);
        startSlideShow_button = (Button) findViewById(R.id.startSlideShow_button);
        endSlideShow_button = (Button) findViewById(R.id.endSlideShow_button);

        if(this.API == null){
            showServerUnreachableAlert(findViewById(android.R.id.content).getRootView());
        }
    }

    public void nextSlidePressed(View view){
        this.API.nextSlide();
    }

    public void previousSlidePressed(View view){
        this.API.previousSlide();
    }

    public void startSlideShowPressed(View view){
        this.API.startSlideShow();
    }

    public void endSlideShowPressed(View view){
        this.API.endSlideShow();
    }

    public void blackOutPressed(View view){
        this.API.blackOut();
    }

    private void showServerUnreachableAlert(final View view){
        AlertDialog.Builder builder = new AlertDialog.Builder(view.getContext());
        builder.setMessage("Could not establish API Object, Return to login screen")
                .setCancelable(false)
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                        Intent intent = new Intent(view.getContext(), MainActivity.class);
                        startActivity(intent);
                        finish();
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();
    }
}