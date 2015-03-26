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
            Console.Write("Votes for each: ");
            String[] voteNumS = Console.ReadLine().Split(',');
            int[] voteNum = new int[voteNumS.Length];
            for (int i = 0; i < voteNum.Length; i++)
            {
                voteNum[i] = Convert.ToInt32(voteNumS[i]);
            }
            int[] count = new int[options.Length];
            for (int i = 0; i < options.Length; i++ )
            {
                count[i] = 0;
            }
            while (voteNum.Sum() != 0)
            {
                for (int i = 0; i < voteNum.Length; i++)
                {
                    Console.WriteLine("here");
                    if (voteNum[i] != 0)
                    {
                        string text = "@TwitPollPP #" + pollName + " ";
                        for (int j = 0; j < voteNum[i]; j++)
                        {
                            text = text + " ";
                        }
                        text = text + options[i];
                        var tweet = Tweet.CreateTweet(text);
                        tweet.Publish();
                        if (tweet.IsTweetPublished)
                        {
                            count[i] = count[i] + 1;
                        }
                        voteNum[i] = voteNum[i] - 1;
                    }
                }
            }
            foreach(int i in count){
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
