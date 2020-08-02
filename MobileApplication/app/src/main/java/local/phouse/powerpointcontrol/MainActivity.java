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
import android.widget.EditText;

import java.util.regex.Matcher;
import java.util.regex.Pattern;

import local.phouse.powerpointcontrol.api.Network;

public class MainActivity extends Activity {

    public static final String EXTRA_URL = "local.phouse.powerpointcontrol.URL";
    public static final String EXTRA_USERNAME = "local.phouse.powerpointcontrol.USERNAME";

    private EditText server_editText;
    private EditText name_editText;
    private Button login_button;

    @SuppressLint("SourceLockedOrientationActivity")
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setRequestedOrientation(ActivityInfo.SCREEN_ORIENTATION_LANDSCAPE);
        getWindow().setFlags(WindowManager.LayoutParams.FLAG_FULLSCREEN, WindowManager.LayoutParams.FLAG_FULLSCREEN);
        setContentView(R.layout.activity_main);

        //Activity Elements
        server_editText = (EditText) findViewById(R.id.server_editText);
        name_editText = (EditText) findViewById(R.id.name_editText);
        login_button = (Button) findViewById(R.id.submit_button);
    }

    public void loginPressed(View view){
        if(!validURL(server_editText.getText().toString())) showInvalidURLFormatAlert(view);
        else if(!validName(name_editText.getText().toString())) showInvalidNameFormatAlert(view);
        else{
            boolean serverOnline = Network.testServerStatus(server_editText.getText().toString());
            if(serverOnline) showValidAlert(view);
            else showServerUnreachableAlert(view);
        }
    }

    private void showValidAlert(final View view){
        AlertDialog.Builder builder = new AlertDialog.Builder(view.getContext());
        builder.setMessage("URL is valid and Server is Online!\nClick OK to login.")
                .setCancelable(false)
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                        Intent intent = new Intent(view.getContext(), ControlActivity.class);
                        intent.putExtra(EXTRA_URL, server_editText.getText().toString());
                        intent.putExtra(EXTRA_USERNAME, name_editText.getText().toString());
                        startActivity(intent);
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();
    }

    private void showServerUnreachableAlert(final View view){
        AlertDialog.Builder builder = new AlertDialog.Builder(view.getContext());
        builder.setMessage("Cannot reach server: " + server_editText.getText().toString())
                .setCancelable(false)
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();
    }

    private void showInvalidURLFormatAlert(final View view){
        AlertDialog.Builder builder = new AlertDialog.Builder(view.getContext());
        builder.setMessage("The URL given is not in a valid URL format:\nExample: \"http://device.building.network\"")
                .setCancelable(false)
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();
    }

    private void showInvalidNameFormatAlert(final View view){
        AlertDialog.Builder builder = new AlertDialog.Builder(view.getContext());
        builder.setMessage("The Name given is not valid:\nCannot be empty or \"Name:\"")
                .setCancelable(false)
                .setPositiveButton("OK", new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
                        dialog.dismiss();
                    }
                });
        AlertDialog alert = builder.create();
        alert.show();
    }

    private boolean validURL(String name){
        String regex = "^(https?)://[-a-zA-Z0-9+&@#/%?=~_|!:,.;]*[-a-zA-Z0-9+&@#/%=~_|]";
        try {
            Pattern pattern = Pattern.compile(regex);
            Matcher matcher = pattern.matcher(name);
            return matcher.matches();
        } catch (RuntimeException e) {
            return false;
        }
    }

    private boolean validName(String name){
        return name != null && !name.equals("") && !name.equals("Name:");
    }
}
