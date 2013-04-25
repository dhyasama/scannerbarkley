using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ScannerDarkly.Mailers;

namespace ScannerDarkly.Controllers
{
    public class DigestController : ApiController
    {
        private static readonly IUserMailer _mailer = new UserMailer();

        // POST api/digest
        public void Get() // this will be post, but set to GET for easy testing
        {
            // get alerts from db and compile into emails
        }
    }
}