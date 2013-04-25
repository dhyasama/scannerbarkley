using System;
using System.Collections.Generic;
using System.Linq;
using LinqToTwitter;
using ScannerDarkly.Helpers;

namespace ScannerDarkly.Models
{
    public class TwitterRepository
    {
        TwitterContext twitterCtx = null;
        string screenName = string.Empty;

        public TwitterRepository()
        {
            dynamic settings = ConfigurationSettings.TwitterSettings();

            // todo - validate

            screenName = settings.Screenname;

            var auth = new SingleUserAuthorizer
            {
                Credentials = new InMemoryCredentials
                {
                    ConsumerKey = settings.ConsumerKey,
                    ConsumerSecret = settings.ConsumerSecret,
                    OAuthToken = settings.OAuthToken,
                    AccessToken = settings.AccessToken
                }
            };

            twitterCtx = new TwitterContext(auth);
        }

        public List GetStatusList(string slug, ulong sinceId)
        {
            List statusList = new List();

            statusList =
                (from list in twitterCtx.List
                 where list.Type == ListType.Statuses &&
                       list.Count == 100 &&
                       list.OwnerScreenName == screenName &&
                       list.Slug == slug// &&     // name of list to get statuses for
                       //list.SinceID == sinceId  // get statuses newer than this id
                 select list)
                 .First();

            return statusList;
        }

        public List<String> GetListSlugs()
        {
            List<String> slugs = new List<String>();

            slugs =
                (from list in twitterCtx.List
                 where list.Type == ListType.Lists &&
                       list.ScreenName == screenName
                 select list.SlugResult)
                .ToList();

            return slugs;
        }
    }
}
