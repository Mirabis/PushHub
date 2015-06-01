//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.BetterWebClient.cs
// Copyright:  2015, Moreno Sint Hill - All rights reserved.
//  
// ALL CONTENTS IN THIS PROJECT ARE PROTECTED BY COPYRIGHT. EXCEPT AS SPECIFICALLY PERMITTED HEREIN, 
// NO PORTION OF THE INFORMATION IN THIS PROJECT MAY BE REPRODUCED IN ANY FORM, OR BY ANY MEANS, WITHOUT PRIOR WRITTEN PERMISSION FROM Mirabis <info@mirabis.nl>. 
// IT IS NOT PERMITTED TO MODIFY, DISTRIBUTE, PUBLISH, TRANSMIT OR CREATE DERIVATIVE WORKS OF ANY MATERIAL FOUND IN THIS PROJECT FOR ANY PUBLIC OR COMMERCIAL PURPOSES.

#region Usings

using System;
using System.Net;
using System.Net.Cache;

#endregion

namespace PushHub.Externals
{
    internal class BetterWebClient : WebClient
    {
        private readonly Random _random = new Random();

        private readonly string[] _userAgents =
            {
                @"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_6_8) AppleWebKit/535.19 (KHTML, like Gecko) Chrome/18.0.1025.45 Safari/535.19",
                @"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_3) AppleWebKit/535.20 (KHTML, like Gecko) Chrome/19.0.1036.7 Safari/535.20",
                @"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_7_3) AppleWebKit/534.55.3 (KHTML, like Gecko) Version/5.1.3 Safari/534.53.10",
                @"Mozilla/5.0 (iPad; CPU OS 5_1 like Mac OS X) AppleWebKit/534.46 (KHTML, like Gecko ) Version/5.1 Mobile/9B176 Safari/7534.48.3",
                @"Mozilla/5.0 (Windows; U; Windows NT 6.1; tr-TR) AppleWebKit/533.20.25 (KHTML, like Gecko) Version/5.0.4 Safari/533.20.27",
                @"Mozilla/5.0 (Windows; U; Windows NT 6.1; sv-SE) AppleWebKit/533.19.4 (KHTML, like Gecko) Version/5.0.3 Safari/533.19.4",
                @"Mozilla/5.0 (Windows; U; Windows NT 6.1; zh-HK) AppleWebKit/533.18.1 (KHTML, like Gecko) Version/5.0.2 Safari/533.18.5",
                @"Mozilla/5.0 (Windows; U; Windows NT 6.1; rv:2.2) Gecko/20110201", @"Mozilla/5.0 (Windows; U; Windows NT 5.0; en-US; rv:1.9.2a1pre) Gecko",
                @"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.6 (KHTML, like Gecko) Chrome/20.0.1092.0 Safari/536.6",
                @"Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1063.0 Safari/536.3",
                @"Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_0) AppleWebKit/536.3 (KHTML, like Gecko) Chrome/19.0.1063.0 Safari/536.3", @"Opera/9.00 (Windows NT 5.1; U; en)",
                @"Opera/8.5 (Macintosh; PPC Mac OS X; U; en)", @"Opera/7.60 (Windows NT 5.2; U) [en] (IBM EVV/3.0/EAK01AG9/LE)",
                @"Opera/9.80 (Windows NT 6.1; WOW64; U; ru) Presto/2.10.229 Version/11.64", @"Opera/9.80 (Windows NT 6.1; U; es-ES) Presto/2.9.181 Version/12.00",
                @"Opera/9.80 (X11; Linux i686; U; ru) Presto/2.8.131 Version/11.11", @"Mozilla/5.0 (Windows NT 6.0; U; ja; rv:1.9.1.6) Gecko/20091201 Firefox/3.5.6 Opera 11.00",
                @"Opera/9.70 (Linux ppc64 ; U; en) Presto/2.2.1"
            };

        public bool Refer = true;
        public BetterWebClient(bool refer = false) { Refer = refer; }

        /// <summary>
        ///     Returns a <see cref="T:System.Net.WebRequest" /> object for the specified resource.
        /// </summary>
        /// <param name="address">A <see cref="T:System.Uri" /> that identifies the resource to request.</param>
        /// <returns>A new <see cref="T:System.Net.WebRequest" /> object for the specified resource.</returns>
        protected override WebRequest GetWebRequest(Uri address)
        {
            //    var Logger = Stopwatch.StartNew();
            ServicePointManager.FindServicePoint(address).Expect100Continue = false; // Save 2- 8 seconds
            var request = base.GetWebRequest(address) as HttpWebRequest;
            if (request != null)
            {
                request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
                request.UserAgent = GetRandomUserAgent();
                request.Headers["Accept-Encoding"] = "gzip";
                if (Refer) request.Referer = "http://www.google.com";
                request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.CacheIfAvailable);
              //  request.ContentType = "application/x-www-form-urlencoded";
                //   Console.WriteLine(@"WebRequest took {0}", Logger.Elapsed);
                return request;
            }
            return null;
        }

        internal string GetRandomUserAgent()
        {
            if (MySettings.Instance == null) return _userAgents[_random.Next(0, _userAgents.Length - 1)];
            return _userAgents[_random.Next(0, _userAgents.Length - 1)];
        }
    }
}