package local.phouse.powerpointcontrol.api;

import android.util.Log;

import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;

public class PowerPoint {
    private String url;
    public PowerPoint(String URL){
        this.url = URL;
    }

    public void nextSlide() {
        final String local_url = this.url;
        final String endpoint = "/internal/nextslide";
        Thread t = new Thread(new Runnable() {
            @Override
            public void run() {
                HttpURLConnection connection = null;
                try{
                    URL url = new URL(local_url+endpoint);
                    connection = (HttpURLConnection) url.openConnection();
                    connection.setRequestMethod("POST");
                    int code = connection.getResponseCode();
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
    }

    public void previousSlide() {
        final String local_url = this.url;
        final String endpoint = "/internal/previousslide";
        Thread t = new Thread(new Runnable() {
            @Override
            public void run() {
                HttpURLConnection connection = null;
                try{
                    URL url = new URL(local_url+endpoint);
                    connection = (HttpURLConnection) url.openConnection();
                    connection.setRequestMethod("POST");
                    int code = connection.getResponseCode();
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
    }

    public void startSlideShow() {
        final String local_url = this.url;
        final String endpoint = "/internal/startslideshow";
        Thread t = new Thread(new Runnable() {
            @Override
            public void run() {
                HttpURLConnection connection = null;
                try{
                    URL url = new URL(local_url+endpoint);
                    connection = (HttpURLConnection) url.openConnection();
                    connection.setRequestMethod("POST");
                    int code = connection.getResponseCode();
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
    }

    public void endSlideShow() {
        final String local_url = this.url;
        final String endpoint = "/internal/endslideshow";
        Thread t = new Thread(new Runnable() {
            @Override
            public void run() {
                HttpURLConnection connection = null;
                try{
                    URL url = new URL(local_url+endpoint);
                    connection = (HttpURLConnection) url.openConnection();
                    connection.setRequestMethod("POST");
                    int code = connection.getResponseCode();
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
