using Tweetinvi;
using Tweetinvi.Models;

namespace MVCTwitterSearcher.Services;

public interface ITwitterService
{
    public Task<ITweet[]> GetTweetsAsync(string username, TwitterClient? client = null);
    public Task<ITweet[]> GetTweetsAsync(IUser user, TwitterClient? client = null);
    public Task<IUser?> GetUserAsync(string username, TwitterClient? client = null);
}