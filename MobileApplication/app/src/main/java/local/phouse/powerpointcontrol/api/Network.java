package local.phouse.powerpointcontrol.api;

import android.util.Log;

import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;

public class Network {
    public static boolean testServerStatus(final String str_url) {
        final Result result = new Result();
        result.set(false);
        Thread t = new Thread(new Runnable() {
            @Override
            public void run() {
                HttpURLConnection connection = null;
                try{
                    URL url = new URL(str_url);
                    connection = (HttpURLConnection) url.openConnection();
                    connection.setRequestMethod("GET");
                    int code = connection.getResponseCode();
                    if(code == 200) {
                        result.set(true);
                    }
                } catch (IOException ex){
                    Log.d("INFO", ex.getMessage());
                } finally {
                    if (connection != null){
                        connection.disconnect();
                    }
                }
            }
        });
        t.start();
        try {
            t.join();
        } catch (InterruptedException e) {
            //Do nothing
        }
        return result.get();
    }


    public static class Result{
        private boolean res = false;

        public Result(){
            this.res = false;
        }

        public void set(boolean value){
            this.res = value;
        }

        public boolean get() {
            return this.res;
        }
    }
}
