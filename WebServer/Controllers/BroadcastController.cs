using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Http;

namespace WebServer.Controllers
{
    public class BroadcastController : ApiController
    {
        private string GetClientIp(HttpRequestMessage request = null) {
            request = request ?? Request;

            if (request.Properties.ContainsKey("MS_HttpContext")) {
                return ((HttpContextWrapper)request.Properties["MS_HttpContext"]).Request.UserHostAddress;
            }
            else if (request.Properties.ContainsKey(RemoteEndpointMessageProperty.Name)) {
                RemoteEndpointMessageProperty prop = (RemoteEndpointMessageProperty)this.Request.Properties[RemoteEndpointMessageProperty.Name];
                return prop.Address;
            }
            else if (HttpContext.Current != null) {
                return HttpContext.Current.Request.UserHostAddress;
            }
            else {
                return null;
            }
        }

        public void LocalEvent_Subscribed(HttpRequestMessage request = null)
        {
            string ip = GetClientIp(request);
            WebApiApplication.SUBSCRIBERS.Add(ip);
        }

        public void NetworkEvent_SlideShowStart()
        {
            foreach(string ip in WebApiApplication.SUBSCRIBERS) {
                RestClient client = new RestClient("http://"+ip+"/");
                RestRequest request = new RestRequest("event/startslideshow");
                IRestResponse response = client.Post(request);
            }
        }

        public void NetworkEvent_SlideShowEnd()
        {
            foreach (string ip in WebApiApplication.SUBSCRIBERS) {
                RestClient client = new RestClient("http://" + ip + "/");
                RestRequest request = new RestRequest("event/endslideshow");
                IRestResponse response = client.Post(request);
            }
        }

        public void NetworkEvent_SlideChange()
        {
            foreach (string ip in WebApiApplication.SUBSCRIBERS) {
                RestClient client = new RestClient("http://" + ip + "/");
                RestRequest request = new RestRequest("event/slidechange");
                IRestResponse response = client.Post(request);
            }
        }
    }
}