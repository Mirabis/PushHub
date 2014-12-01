#region License
// Author: Moreno Sint Hill alias Mirabis
// Created on: 01/12/2014                
// Last Edited on: 01/12/2014
// Project: BuddyPush
// File: Pushover.cs
// Copyright:  2014, Moreno Sint Hill - All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are met:
// 
// 1. Redistributions of source code must retain the above copyright notice, this
//    list of conditions and the following disclaimer. 
// 2. Redistributions in binary form must reproduce the above copyright notice,
//    this list of conditions and the following disclaimer in the documentation
//    and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
// DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES
// (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
// LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND
// ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
// SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// 
// The views and conclusions contained in the software and documentation are those
// of the authors and should not be interpreted as representing official policies, 
// either expressed or implied, of the FreeBSD Project.
#endregion
namespace BuddyPush.Providers
{
    using System;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;

    using BuddyPush.Externals;

    using Styx.Common;

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
            try
            {
                string editedtitle = string.Format("{0}: {1}", "BuddyPush", title);

                using (var wc = new BetterWebClient())
                {
                    var parameters = new NameValueCollection { { "token", MySettings.Instance.Pushover_Token }, { "user", MySettings.Instance.Pushover_UserKey }, { "message", message } };
                    string device = MySettings.Instance.Pushover_Device;
                    if (!string.IsNullOrEmpty(device)) parameters.Add("device", device);
                    if (!string.IsNullOrEmpty(title)) parameters.Add("title", editedtitle);
                    if (!string.IsNullOrEmpty(url)) parameters.Add("url", url);
                    if (!string.IsNullOrEmpty(urlTitle)) parameters.Add("urlTitle", urlTitle);
                    NotificationPriority priority = MySettings.Instance.Pushover_Priority;
                    if ((int)priority != 0) parameters.Add("priority", ((int)priority).ToString(CultureInfo.InvariantCulture));
                    PushoverSound sound = MySettings.Instance.Pushover_Sound;
                    if (sound != PushoverSound.Pushover) parameters.Add("sound", sound.ToString().ToLower());

                    byte[] responseArray = await wc.UploadValuesTaskAsync(API_URL, parameters);
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