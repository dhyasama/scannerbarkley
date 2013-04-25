using System;
using System.Collections.Generic;

namespace ScannerDarkly.Models
{
    public class Tweet
    {
        public string tweetId { get; set; }

        public string text { get; set; }

        public DateTime timestamp { get; set; }

        public string name { get; set; }

        public string screenName { get; set; }
    }
}
