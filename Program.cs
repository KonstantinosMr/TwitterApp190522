﻿using System;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;

namespace TwitterApp190522
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var userCredentials = new TwitterCredentials("nN2yYQcMWlhsvaa8awvHo9PWF", "MDGDCAAhOaA3BSVMSz5HF2LElow39rdJlPJxdQO9z1E4pZ03b3", "1629692186-BimLBhF2MUQZ5ufDZ4G93ufBy7byABzijbZcNqQ", "hdY2py8hMvdSb7tU0a0wDxLmkKZrH7Gj24P7XL0SpAjTo");
            var userClient = new TwitterClient(userCredentials);

            // Create a simple stream containing only tweets with the keyword France

            var stream = userClient.Streams.CreateFilteredStream();
            stream.AddTrack("java");
            stream.AddTrack("python");
            stream.AddTrack("csharp");
            stream.AddTrack("javascript");

            stream.MatchingTweetReceived += (sender, eventReceived) =>
            {
                Console.WriteLine(eventReceived.Tweet);
            };

            await stream.StartMatchingAnyConditionAsync();
        }
    }
}
