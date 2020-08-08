package local.phouse.powerpointcontrol.api;

import android.util.Log;

import org.java_websocket.client.WebSocketClient;

import java.net.URISyntaxException;

import io.socket.client.IO;
import io.socket.client.Socket;
import io.socket.emitter.Emitter;

public class ServerEvents {
    private Socket socket;

    public ServerEvents(String serverUrl){
        ConnectToWebSocket(serverUrl);
    }

    private void ConnectToWebSocket(String url) {
        try{
            socket = IO.socket("http://url");
            socket.on(Socket.EVENT_CONNECT, new Emitter.Listener() {

                @Override
                public void call(Object... args) {
                    socket.emit("foo", "hi");
                    socket.disconnect();
                }

            }).on(Socket.EVENT_DISCONNECT, new Emitter.Listener() {
                @Override
                public void call(Object... args) {
                    //do code
                }
            });
            socket.connect();
        }
        catch(URISyntaxException ex){
            //DO nothing
        }
    }

    private void instantiateEndPoints(){
        socket.on("START_SLIDE_SHOW", new Emitter.Listener() {
            @Override
            public void call(Object... args) {
                Log.i("SERVER_EVENT", "Received event 'START_SLIDE_SHOW'");
            }
        });

        socket.on("SLIDE_CHANGE", new Emitter.Listener() {
            @Override
            public void call(Object... args) {
                Log.i("SERVER_EVENT", "Received event 'SLIDE_CHANGE'");
                //do code
            }
        });

        socket.on("END_SLIDE_SHOW", new Emitter.Listener() {
            @Override
            public void call(Object... args) {
                Log.i("SERVER_EVENT", "Received event 'END_SLIDE_SHOW'");
                //do code
            }
        });
    }
}

