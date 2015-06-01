//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.PushBullet.cs
// Copyright:  2015, Moreno Sint Hill - All rights reserved.
//  
// ALL CONTENTS IN THIS PROJECT ARE PROTECTED BY COPYRIGHT. EXCEPT AS SPECIFICALLY PERMITTED HEREIN, 
// NO PORTION OF THE INFORMATION IN THIS PROJECT MAY BE REPRODUCED IN ANY FORM, OR BY ANY MEANS, WITHOUT PRIOR WRITTEN PERMISSION FROM Mirabis <info@mirabis.nl>. 
// IT IS NOT PERMITTED TO MODIFY, DISTRIBUTE, PUBLISH, TRANSMIT OR CREATE DERIVATIVE WORKS OF ANY MATERIAL FOUND IN THIS PROJECT FOR ANY PUBLIC OR COMMERCIAL PURPOSES.

#region Usings

using System;
using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PushHub.Externals;
using Styx.Common;

#endregion

namespace PushHub.Providers
{
    public class PushBullet
    {
        /// <summary>
        ///     https://pushover.net/api
        /// </summary>
        private const string API_URL = "https://api.pushbullet.com/v2/pushes";

        /// <summary>
        ///     The provider name
        /// </summary>
        private const string ProviderName = "PushBullet";

        /// <summary>
        ///     Pushes the notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="url">The URL.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static async Task<string> PushNotification(string message, string title = null, string url = null)
        {
            string response = string.Empty;
            try
            {
             
                using (var client = new BetterWebClient())
                {
                    var values = new NameValueCollection();

                    var authEncoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(MySettings.Instance.Pushbullet_Token + ":"));
                    values["AuthorizationToken"] = MySettings.Instance.Pushbullet_Token;
                    values["type"] = Uri.IsWellFormedUriString(url, UriKind.Absolute) ? "link" : "note"; // Title, url and body
                    string device = MySettings.Instance.Pushbullet_Device;

                    if (!string.IsNullOrEmpty(device)) values["device_iden"] = device.Truncate(250);


                    if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute)) values["url"] = url.Truncate(1000);

                    if (!string.IsNullOrEmpty(title)) values["title"] = title.Truncate(250);

                    if (!string.IsNullOrEmpty(message)) values["body"] = message;

                    client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", authEncoded);
                    client.Headers[HttpRequestHeader.Accept] = "application/json";
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    byte[] responseArray = await client.UploadValuesTaskAsync(API_URL, values);
                    response = Encoding.ASCII.GetString(responseArray);
                }
                return response;
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.NameResolutionFailure) Logger.FailLog("{0}:Bad domain name", ProviderName);
                if (e.Status == WebExceptionStatus.ProtocolError) Logger.FailLog("{0} Notification failed, Status Code: {1}. Description:  {2}  - Response:{3}", ProviderName, ((HttpWebResponse)e.Response).StatusCode, ((HttpWebResponse)e.Response).StatusDescription, response);
                return null;
            }
            catch (Exception ex)
            {
                Logging.WriteException(LogLevel.Normal, ex);
                return null;
            }
        }
    }
}