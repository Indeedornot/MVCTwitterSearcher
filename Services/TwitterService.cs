using Tweetinvi;
using Tweetinvi.Models;

namespace MVCTwitterSearcher.Services
{
    public class TwitterService : ITwitterService
    {
        private static readonly TwitterClient TwitterClient = new("BTc4TngFEGfx40usrxnrULc38", "HQzQMmacjLQnPUBaL9EUVqX7d6WnmAFbjhEWYpJtbLVhyOb6S9", "1244033863292260361-xosszqpiQNZ5STofDOeE1w2JGVLmxl", "0nWgwwrswAa20ccNQTubvJHKtMFVjjk4WVDSlzGarS9cw");
        public async Task<ITweet[]> GetTweetsAsync(string username, TwitterClient? client = null)
        {
            client ??= TwitterClient;
            
            if (!validUsername(username)) return Array.Empty<ITweet>();

            var user = await GetUserAsync(username);
            if (user is null) return Array.Empty<ITweet>();
            var userTimeLine = await client.Timelines.GetUserTimelineAsync(user);
            return userTimeLine ?? Array.Empty<ITweet>();
        }

        public async Task<ITweet[]> GetTweetsAsync(IUser user, TwitterClient? client = null)
        {
            client ??= TwitterClient;
            
            var userTimeLine = await client.Timelines.GetUserTimelineAsync(user);
            return userTimeLine ?? Array.Empty<ITweet>();
        }

        
        public async Task<IUser?> GetUserAsync(string username, TwitterClient? client = null)
        {
            client ??= TwitterClient;

            if (!validUsername(username)) return null;

            var user = (await client.Search.SearchUsersAsync(username)).FirstOrDefault();
            return user;
        }
        
        public bool validUsername(string username) => !string.IsNullOrEmpty(username) && username.Length is >= 4 and <= 50;
    }
}
