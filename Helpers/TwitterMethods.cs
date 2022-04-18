using Tweetinvi;
using Tweetinvi.Models;

namespace MVCTwitterScraper.Helpers
{
    public static class TwitterMethods
    {
        private static readonly TwitterClient TwitterClient = new("BTc4TngFEGfx40usrxnrULc38", "HQzQMmacjLQnPUBaL9EUVqX7d6WnmAFbjhEWYpJtbLVhyOb6S9", "1244033863292260361-xosszqpiQNZ5STofDOeE1w2JGVLmxl", "0nWgwwrswAa20ccNQTubvJHKtMFVjjk4WVDSlzGarS9cw");
        public static async Task<ITweet[]> RequestUserTweets(string username, TwitterClient? client = null)
        {
            if (string.IsNullOrEmpty(username)) return Array.Empty<ITweet>();
            if (client == null) client = TwitterClient;
            var user = (await client.Search.SearchUsersAsync(username))[0];
            var userTimeLine = await client.Timelines.GetUserTimelineAsync(user);
            return userTimeLine;
        }
    }
}
