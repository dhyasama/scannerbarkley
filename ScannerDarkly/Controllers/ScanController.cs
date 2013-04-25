using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScannerDarkly.Mailers;
using ScannerDarkly.Models;

namespace ScannerDarkly.Controllers
{
    public class ScanController : ApiController
    {
        private static readonly TwitterRepository _twitter = new TwitterRepository();
        private static readonly TwilioRepository _twilio = new TwilioRepository();
        private static readonly IUserMailer _mailer = new UserMailer();

        // POST api/scan
        public void Get() // this will be post, but set to GET for easy testing
        {
            // get list of twitter lists
            List<String> slugs = _twitter.GetListSlugs();

            // loop through each
            // if not already being scanned, pull back tweets
            foreach (string slug in slugs)
            {
                // todo - check status, skip if already processing
                // todo - mark list as processing
                // todo - get sinceId

                var statusList = _twitter.GetStatusList(slug, 0);

                foreach (var status in statusList.Statuses)
                {
                    // check each username/text pair against our database of customers and keywords
                    CrossCheck(status.User.Identifier.ScreenName, status.Text);
                }

                // todo - mark list as done
                // todo - save most recent tweet id for next time
            }
        }

        private void CrossCheck(string screenname, string text)
        {
            Dictionary<string, Dictionary<string, List<string>>> searchMap = GetSearchMap();

            if (searchMap.ContainsKey(screenname))
            {
                Dictionary<string, List<string>> customerKeywords = searchMap[screenname];

                foreach (string key in customerKeywords.Keys)
                {
                    List<string> keywords = customerKeywords[key];

                    foreach (string keyword in keywords)
                    {
                        if (text.ToUpper().Contains(keyword.ToUpper()))
                        {
                            // todo - log to database
                            // todo - check if user wants email or text notifications
                            // todo - check if user wants immediate alert or daily digest

                            //_twilio.SendSms("2079396565", "2079396565", screenname + "'s Tweet contains " + keyword);

                            //bool sent = _mailer.Alert("dhyasama@gmail.com", screenname + "'s Tweet contains " + keyword);
                        }
                    }
                }
            }
        }

        private Dictionary<string, Dictionary<string, List<string>>> GetSearchMap()
        {
            // This is just for testing; real data would come from mongo;

            Dictionary<string, Dictionary<string, List<string>>> searchMap = new Dictionary<string, Dictionary<string, List<string>>>();
            List<string> keywords = new List<string>();
            Dictionary<string, List<string>> customerKeywords = new Dictionary<string, List<string>>();

            // user dhyasama@gmail.com is watching javalemcgee34 for these keywords
            //keywords.Add("disgust");
            //keywords.Add("my pic");
            //customerKeywords.Add("dhyasama@gmail.com", keywords);

            //// user jason@rallyverse.com is watching javalemcgee34 for these keywords
            //keywords.Clear();
            //keywords.Add("#denvernuggets");
            //keywords.Add("@kendricklamar");
            //customerKeywords.Add("jason@rallyverse.com", keywords);

            //searchMap.Add("javalemcgee34", customerKeywords);
            
            // user jason@bubbleheads.com is watching aa000g9 for these keywords
            customerKeywords.Clear();
            keywords.Clear();
            keywords.Add("chuck");
            keywords.Add("shoot");
            customerKeywords.Add("jason@bubbleheadsnyc.com", keywords);

            searchMap.Add("aa000G9", customerKeywords);

            return searchMap;
        }
    }
}