//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.Pushover.cs
// Copyright:  2015, Moreno Sint Hill - All rights reserved.
//  
// ALL CONTENTS IN THIS PROJECT ARE PROTECTED BY COPYRIGHT. EXCEPT AS SPECIFICALLY PERMITTED HEREIN, 
// NO PORTION OF THE INFORMATION IN THIS PROJECT MAY BE REPRODUCED IN ANY FORM, OR BY ANY MEANS, WITHOUT PRIOR WRITTEN PERMISSION FROM Mirabis <info@mirabis.nl>. 
// IT IS NOT PERMITTED TO MODIFY, DISTRIBUTE, PUBLISH, TRANSMIT OR CREATE DERIVATIVE WORKS OF ANY MATERIAL FOUND IN THIS PROJECT FOR ANY PUBLIC OR COMMERCIAL PURPOSES.

#region Usings

using System;
using System.Collections.Specialized;
using System.Globalization;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PushHub.Externals;
using Styx.Common;

#endregion

namespace PushHub.Providers
{
    public class Pushover
    {
        /// <summary>
        ///     https://pushover.net/api
        /// </summary>
        private const string API_URL = "https://api.pushover.net/1/messages.json";

        /// <summary>
        ///     The provider name
        /// </summary>
        private const string ProviderName = "Pushover";

        /// <summary>
        ///     Pushes the notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <param name="url">The URL.</param>
        /// <param name="urlTitle">The URL title.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static async Task<string> PushNotification(string message, string title = null, string url = null, string urlTitle = null)
        {
            string response = string.Empty;
            try
            {
                var editedtitle = string.Format("{0}: {1}", "PushHub", title);

                using (var wc = new BetterWebClient())
                {
                    var parameters = new NameValueCollection { { "token", MySettings.Instance.Pushover_Token }, { "user", MySettings.Instance.Pushover_UserKey }, { "message", message } };
                    var device = MySettings.Instance.Pushover_Device;
                    if (!string.IsNullOrEmpty(device)) parameters.Add("device", device);
                    if (!string.IsNullOrEmpty(title)) parameters.Add("title", editedtitle);
                    if (!string.IsNullOrEmpty(url) && Uri.IsWellFormedUriString(url, UriKind.Absolute)) parameters.Add("url", url);
                    if (!string.IsNullOrEmpty(urlTitle) && Uri.IsWellFormedUriString(url, UriKind.Absolute)) parameters.Add("urlTitle", urlTitle);
                    var priority = MySettings.Instance.Pushover_Priority;
                    if ((int)priority != 0) parameters.Add("priority", ((int)priority).ToString(CultureInfo.InvariantCulture));
                    var sound = MySettings.Instance.Pushover_Sound;
                    if (sound != PushoverSound.Pushover) parameters.Add("sound", sound.ToString().ToLower());

                    var responseArray = await wc.UploadValuesTaskAsync(API_URL, parameters);
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