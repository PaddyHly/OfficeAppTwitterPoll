using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using Tweetinvi;
using Tweetinvi.Core.Interfaces.Models;
using powerpollService.DataObjects;
using Newtonsoft.Json;

namespace powerpollService.Controllers
{
    public class TwitterController : ApiController
    {
        public ApiServices Services { get; set; }

        // GET api/Twitter
        public string Get(string hashtag, string keywords)
        {
            //this stuff is here until we find somewhere better
            TwitterCredentials.SetCredentials(
                "Access_Token",
                "Access_Token_Secret",
                "Consumer_Key",
                "Consumer_Secret");
            TwitterCredentials.SetCredentials(
                "3004124297-zzToru8oHmIGxJAOyWojqeRP2fxgzx25irOO4de",
                "Sa8CerPNMZfOh3hiWQ30gu9pxADnfnOAAAUGN4dlENKhd",
                "dQPcIhiNdtHAchfx7ZbsjeDAW",
                "V53RXnrRhpq6ReHa6qtRKi5J5IhLz5HzYCyXAJP031krCzreur");

            string[] keywordArr = keywords.Split(',');
            Result[] results = new Result[keywordArr.Length];
            hashtag = hashtag.ToLowerInvariant();
            for (int i = 0; i < results.Length; i++)
            {
                results[i] = new Result(keywordArr[i].ToLowerInvariant());
            }
            var user = Tweetinvi.User.GetLoggedUser();
            
            foreach (var mention in user.GetMentionsTimeline())
            {
                var hashtags = mention.Hashtags.ToArray();
                //check if mention contains the hashtag, mention may have more than one
                foreach (var hash in hashtags)
                {
                    if (hash.Text.ToLowerInvariant().Equals(hashtag))
                    {
                        //check to see if the mention contains any keywords
                        foreach (var result in results)
                        {
                            //needs cleaning up, will count every keyword in the tweet
                            if (mention.Text.ToLowerInvariant().Contains(result.keyword))
                            {
                                result.count++;
                            }
                        }
                    }
                }
            }

            return JsonConvert.SerializeObject(results);
        }

        public class Result
        {
            public string keyword;
            public int count;

            public Result(string keyword){
                this.keyword = keyword;
                count = 0;
            }
        }

    }
}
