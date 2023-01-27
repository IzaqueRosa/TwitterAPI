using Microsoft.AspNetCore.Mvc;
using Twitter.Domain.Interfaces.Services;

namespace TwitterAPI.Controllers
{
    [Route("api/twitter")]
    public class TwitterController : Controller
    {

        private readonly ITwitterService _twitterService;

        /// <summary>
        /// Retrieve a 1% random sample of publicly available Tweets in real time.
        /// </summary>
        public TwitterController(ITwitterService twitterService)
        {
            _twitterService = twitterService;
        }

        [HttpGet]
        public ActionResult GetTweets()
        {
            return Ok(_twitterService.GetTweets());
        }
    }
}
