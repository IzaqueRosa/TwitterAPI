using Twitter.Data.DTOs;

namespace Twitter.Domain.Interfaces.Services
{
    public interface ITwitterService
    {
        ResumeDto GetTweets();
    }
}
