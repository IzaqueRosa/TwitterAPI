using Newtonsoft.Json;
using Twitter.Data.DTOs;
using Twitter.Domain.Interfaces.Services;
using Microsoft.Extensions.Configuration;

namespace Twitter.Domain.Services
{
    public class TwitterService : ITwitterService
    {
        private readonly IConfiguration _config;

        public TwitterService(IConfiguration config)
        {
            _config = config;
        }

        public ResumeDto GetTweets()
        {
            #region parameters
            var token = _config.GetSection("APITwitterIntegration")["Token"];
            var url = _config.GetSection("APITwitterIntegration")["URL"];
            var optionalValue = _config.GetSection("APITwitterIntegration")["OptionalValue"];
            #endregion

            #region objects
            TweetDto tweet = new ();
            ResumeDto resumeDto = new();
            List<TweetDto> lstTweet = new();
            List<Hashtag> lstHashtasg = new();
            #endregion

            using (var client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(60);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Add("User-Agent", "v2SampleStreamC#");

                var stream = client.GetStreamAsync(url + optionalValue).Result;

                using (StreamReader sr = new(stream))
                {
                    while (lstTweet.Count < 1000)
                    {
                        tweet = JsonConvert.DeserializeObject<TweetDto>(sr.ReadLine());
                        lstTweet.Add(tweet);
                    }

                    sr.Close();
                }
            }

            foreach (var _tweetDto in lstTweet)
            {
                if (_tweetDto != null)
                {
                    if (_tweetDto.data.entities != null)
                    {
                        if (_tweetDto.data.entities.hashtags != null)
                        {
                            foreach (var _hashtag in _tweetDto.data.entities.hashtags)
                            {
                                lstHashtasg.Add(_hashtag);
                            }
                        }
                    }
                }
            }

            var mostUsedHashtags = lstHashtasg.GroupBy(g => g.tag).OrderByDescending(d => d.Count()).Take(10);

            resumeDto.TotalTweets = lstTweet.Count;
            resumeDto.Tag = mostUsedHashtags.Select(s => s.Key).ToList();

            return resumeDto;
        }
    }
}
