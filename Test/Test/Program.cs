using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace Test
{
    class Program
    {
        static int TWEET_LIMIT = 120;

        static void Main(string[] args)
        {
            TwitterCredentials.ApplicationCredentials = TwitterCredentials.CreateCredentials(
                "3004124297-RR9ZNwofkwnt7ATF3fefQllHtDGgNH3u442QUWo",
                "0XymIsK4bTDvzmz2xw4snubmLlvHp9oHeZa8EapWEVL9S",
                "dQPcIhiNdtHAchfx7ZbsjeDAW",
                "V53RXnrRhpq6ReHa6qtRKi5J5IhLz5HzYCyXAJP031krCzreur");

            Console.Write("PollName: ");
            string pollName = Console.ReadLine();
            Console.Write("Options: ");
            string[] options = Console.ReadLine().Split(',');
            int amountPer = options.Length / TWEET_LIMIT;
            int amount = TWEET_LIMIT % options.Length;
            for (int i = 0; i < TWEET_LIMIT; i++)
            {
                string text = "@TwitPollPP #" + pollName + " ";
                for (int j = 0; j < i / options.Length; j++)
                {
                    text = text + " ";
                }
                text = text + options[i % options.Length];
                var tweet = Tweet.PublishTweet(text);
            }
            Console.ReadKey();
        }
    }
}
