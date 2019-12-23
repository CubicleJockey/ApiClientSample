using System;
using ApiClientSample.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using RestSharp;

namespace ApiClientSample
{
    [TestClass]
    public class Playground
    {
        [TestMethod]
        public void ThingSpeakSample()
        {
            var client = new RestClient("https://thingspeak.com");

            var request = new RestRequest("channels/472672/feeds.json", Method.GET);
            request.AddParameter("api_key", "ME44DYGVHDGVX6TB");


            IRestResponse response = client.Execute(request);
            var json = response.Content;

            //Console.WriteLine(json);

            var thinkSpeakResponse = JsonConvert.DeserializeObject<ThinkSpeakResponse>(json);

            if(thinkSpeakResponse == null)
            {
                Assert.Fail();
            }

            Console.WriteLine("Channel info: ");
            Console.WriteLine($"{nameof(thinkSpeakResponse.Channel.Latitude)} : {thinkSpeakResponse.Channel.Latitude}");
            Console.WriteLine($"{nameof(thinkSpeakResponse.Channel.Longitude)} : {thinkSpeakResponse.Channel.Longitude}");
            Console.WriteLine();


            foreach (var feed in thinkSpeakResponse.Feeds)
            {
                Console.WriteLine($"{nameof(feed.Field1)} : {feed.Field1}");
                Console.WriteLine($"{nameof(feed.Field2)} : {feed.Field2}");
                Console.WriteLine($"{nameof(feed.Field3)} : {feed.Field3}");
                Console.WriteLine($"{nameof(feed.Field4)} : {feed.Field4}");
                Console.WriteLine($"{nameof(feed.Field5)} : {feed.Field5}");
                Console.WriteLine($"{nameof(feed.Field6)} : {feed.Field6}");
                Console.WriteLine($"{nameof(feed.Field7)} : {feed.Field7}");
            }

            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
