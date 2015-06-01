//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.Toasty.cs
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
    public class Toasty
    {
        /// <summary>
        ///     Pram 0 = deviceID
        /// </summary>
        private const string API_URL = "http://api.supertoasty.com/notify/{0}";

        /// <summary>
        ///     The provider name
        /// </summary>
        private const string ProviderName = "Toasty";

        /// <summary>
        ///     Pushes the notification.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The title.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public static async Task<string> PushNotification(string message, string title = null)
        {
            try
            {
                using (var client = new BetterWebClient())
                {
                    var values = new NameValueCollection();

                    if (!string.IsNullOrEmpty(title)) values["title"] = title;

                    if (!string.IsNullOrEmpty(message)) values["notification[long_message]"] = Encoding.UTF8.GetByteCount(message) <= 4000 ? message.Truncate(10000) : "Error: Message bigger then 4KB";

                    values["sender"] = "PushHub";
                    client.Headers[HttpRequestHeader.ContentEncoding] = "multipart/form-data";

                    var responseArray = await client.UploadValuesTaskAsync(new Uri(string.Format(API_URL, MySettings.Instance.Toasty_DeviceID)), values);
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