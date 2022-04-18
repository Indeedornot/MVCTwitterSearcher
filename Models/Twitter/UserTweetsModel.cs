
using Tweetinvi.Models;

namespace MVCTwitterScraper.Models.Twitter
{
    public class UserTweetsModel
    {
        public string Username { get; }

        public ITweet[] Tweets { get; }

        private UserTweetsModel(string username, ITweet[] tweets)
        {
            Username = username;
            Tweets = tweets;
        }

        public static async Task<UserTweetsModel?> CreateModel(string? username)
        {
            if (username is null || username.Length is < 4 or > 50) return null;
            var tweets = await Helpers.TwitterMethods.RequestUserTweets(username);
            var model = new UserTweetsModel(username, tweets);
            return model;
        }
    }
}
