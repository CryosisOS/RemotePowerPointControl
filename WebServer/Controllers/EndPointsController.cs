using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Http;
using RestSharp;

namespace WebServer.Controllers
{
    public class EndPointsController : ApiController
    {
        public IHttpActionResult StartSlideShow()
        {
            RestClient client = new RestClient(WebApiApplication.BASE_URL);
            RestRequest request = new RestRequest("Action/StartSlideShow");
            IRestResponse response = client.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok();
            else
                return NotFound();
        }

        //EndSlideShow
        public IHttpActionResult EndSlideShow()
        {
            RestClient client = new RestClient(WebApiApplication.BASE_URL);
            RestRequest request = new RestRequest("Action/EndSlideShow");
            IRestResponse response = client.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok();
            else
                return NotFound();
        }

        //NextSlide
        public IHttpActionResult NextSlide()
        {
            RestClient client = new RestClient(WebApiApplication.BASE_URL);
            RestRequest request = new RestRequest("Action/NextSlide");
            IRestResponse response = client.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok();
            else
                return NotFound();
        }

        //PreviousSlide
        public IHttpActionResult PreviousSlide()
        {   
            RestClient client = new RestClient(WebApiApplication.BASE_URL);
            RestRequest request = new RestRequest("Action/PreviousSlide");
            IRestResponse response = client.Post(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return Ok();
            else
                return NotFound();
        }
    }
}