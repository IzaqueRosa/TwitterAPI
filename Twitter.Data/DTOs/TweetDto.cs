
namespace Twitter.Data.DTOs
{
    public class TweetDto
    {
        public Data data { get; set; }
    }

    public class Annotation
    {
        public int start { get; set; }
        public int end { get; set; }
        public double probability { get; set; }
        public string type { get; set; }
        public string normalized_text { get; set; }
    }

    public class Data
    {
        public List<string> edit_history_tweet_ids { get; set; }
        public Entities entities { get; set; }
        public string id { get; set; }
        public string text { get; set; }
    }

    public class Entities
    {
        public List<Annotation> annotations { get; set; }
        public List<Hashtag> hashtags { get; set; }
        public List<Mention> mentions { get; set; }
        public List<Url> urls { get; set; }
    }

    public class Hashtag
    {
        public int start { get; set; }
        public int end { get; set; }
        public string tag { get; set; }
    }

    public class Mention
    {
        public int start { get; set; }
        public int end { get; set; }
        public string username { get; set; }
        public string id { get; set; }
    }

    public class Url
    {
        public int start { get; set; }
        public int end { get; set; }
        public string url { get; set; }
        public string expanded_url { get; set; }
        public string display_url { get; set; }
        public string media_key { get; set; }
    }


}
