//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.BoxCar2.cs
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
    public class BoxCar2
    {
        /// <summary>
        ///     https://pushover.net/api
        /// </summary>
        private const string API_URL = "https://new.boxcar.io/api/notifications";

        /// <summary>
        ///     The provider name
        /// </summary>
        private const string ProviderName = "BoxCar2";

        /// <summary>
        ///     Pushes the notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="url">The URL.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static async Task<string> PushNotification(string message, string title = null, string url = null)
        {
            try
            {
                using (var client = new BetterWebClient())
                {
                    var values = new NameValueCollection();
                    values["user_credentials"] = MySettings.Instance.BoxCar2_Token;

                    values["notification[source_name]"] = "PushHub";

                    if (!string.IsNullOrEmpty(title)) values["notification[title]"] = title.Truncate(255);

                    if (!string.IsNullOrEmpty(message)) values["notification[long_message]"] = Encoding.UTF8.GetByteCount(message) <= 4000 ? message.Truncate(10000) : "Error: Message bigger then 4KB";

                    if (!string.IsNullOrEmpty(url)) values["url"] = url.Truncate(2000);

                    var sound = MySettings.Instance.BoxCar2_Sound;
                    values["notification[sound]"] = sound.ToString().Replace('_', '-').ToLower();

                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    var responseArray = await client.UploadValuesTaskAsync(API_URL, values);
                    return Encoding.ASCII.GetString(responseArray);
                }
            }
            catch (WebException e)
            {
                if (e.Status == WebExceptionStatus.NameResolutionFailure) Logger.FailLog("{0}:Bad domain name", ProviderName);
                if (e.Status == WebExceptionStatus.ProtocolError) Logger.FailLog("{0} Notification failed, Status Code: {1}. Description:  {2}", ProviderName, ((HttpWebResponse)e.Response).StatusCode, ((HttpWebResponse)e.Response).StatusDescription);
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