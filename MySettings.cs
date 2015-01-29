#region License

// Author: Moreno Sint Hill alias Mirabis
// Created on: 27/10/2013                
// Last Edited on: 01/12/2014
// Project: PushHub
// File: MySettings.cs
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

using DefaultValue = Styx.Helpers.DefaultValueAttribute;

namespace PushHub
{
    using System.ComponentModel;
    using System.IO;

    using PushHub.Externals;

    using Styx.Common;
    using Styx.Helpers;

    internal class MySettings : Settings
    {
        [Setting, Browsable(false), DefaultValue(true)]
        public bool CheckTriggerList { get; set; }

        #region Default

        private static MySettings _instance;

        public MySettings() : base(Path.Combine(Path.Combine(Utilities.AssemblyDirectory, "Settings"), string.Format("PushHub.xml"))) { }

        public static MySettings Instance
        {
            get { return _instance ?? (_instance = new MySettings()); }
        }

        #endregion

        #region PushoverSettings

        [Setting, DefaultValue(false), Category("Pushover"), DisplayName("Enable"), Description("Use this provider to send push notifications")]
        public bool Push_Pushover { get; set; }

        [Setting, DefaultValue(false), Category("Pushalot"), DisplayName("Enable"), Description("Use this provider to send push notifications")]
        public bool Push_Pushalot { get; set; }

        [Setting, DefaultValue(false), Category("PushBullet"), DisplayName("Enable"), Description("Use this provider to send push notifications")]
        public bool Push_Pushbullet { get; set; }

        [Setting, DefaultValue(false), Category("Toasty"), DisplayName("Enable"), Description("Use this provider to send push notifications")]
        public bool Push_Toasty { get; set; }

        [Setting, DefaultValue(false), Category("Prowl"), DisplayName("Enable"), Description("Use this provider to send push notifications")]
        public bool Push_Prowl { get; set; }

        [Setting, DefaultValue(false), Category("NotifyMyAndroid"), DisplayName("Enable"), Description("Use this provider to send push notifications")]
        public bool Push_NMY { get; set; }

        [Setting, DefaultValue(false), Category("BoxCar2"), DisplayName("Enable"), Description("Use this provider to send push notifications")]
        public bool Push_Boxcar2 { get; set; }

        [Setting, DefaultValue(""), Category("BoxCar2"), DisplayName("Access Token"), Description("The Authentication token you can retrieve from http://help.boxcar.io/knowledgebase/articles/314474-how-to-get-my-boxcar-access-token")]
        public string BoxCar2_Token { get; set; }

        [Setting, DefaultValue(""), Category("BoxCar2"), DisplayName("Device Token"), Description("For iOS, this is the device token. For Android, this is the device registration ID.")]
        public string BoxCar2_Device { get; set; }

        [Setting, DefaultValue(BoxCarSound.no_sound), Category("BoxCar2"), DisplayName("Sound"), Description("Sound to use for the notifications.")]
        public BoxCarSound BoxCar2_Sound { get; set; }

        [Setting, DefaultValue(PushoverSound.Pushover), Category("Pushover"), DisplayName("Sound"), Description("Sound to use for the notifications.")]
        public PushoverSound Pushover_Sound { get; set; }

        [Setting, DefaultValue(""), Category("Pushalot"), DisplayName("API Key"), Description("The authentication key.")]
        public string Pushalot_Token { get; set; }

        [Setting, DefaultValue(false), Category("Pushalot"), DisplayName("Important"), Description("Should the message be sent as Important/High Priority?")]
        public bool Pushalot_Important { get; set; }

        [Setting, DefaultValue(false), Category("Pushalot"), DisplayName("Silent"), Description("Should the message be sent silently, no sound?")]
        public bool Pushalot_Silent { get; set; }

        [Setting, DefaultValue(""), Category("NotifyMyAndroid"), DisplayName("API Key"), Description("The authentication key.")]
        public string NMY_Token { get; set; }

        [Setting, DefaultValue(NotificationPriority.Normal), Category("NotifyMyAndroid"), DisplayName("Priority"), Description("The priority of the messages.")]
        public NotificationPriority NMY_Priority { get; set; }

        [Setting, DefaultValue(NotificationPriority.Normal), Category("Pushover"), DisplayName("Priority"), Description("The priority of the messages.")]
        public NotificationPriority Pushover_Priority { get; set; }

        [Setting, DefaultValue(NotificationPriority.Normal), Category("Prowl"), DisplayName("Priority"), Description("The priority of the messages.")]
        public NotificationPriority Prowl_Priority { get; set; }

        [Setting, DefaultValue(""), Category("PushBullet"), DisplayName("API Key"), Description("The authentication key.")]
        public string Pushbullet_Token { get; set; }

        [Setting, DefaultValue(""), Category("Toasty"), DisplayName("Device"), Description("The device to send it to.")]
        public string Toasty_DeviceID { get; set; }

        [Setting, DefaultValue(""), Category("Prowl"), DisplayName("API Key"), Description("The authentication key.")]
        public string Prowl_Token { get; set; }

        [Setting, DefaultValue(""), Category("Prowl"), DisplayName("Provider Key"), Description("(optional)Mostly for developers.")]
        public string Prowl_ProviderKey { get; set; }

        [Setting, DefaultValue(""), Category("PushBullet"), DisplayName("Device_iden"), Description("Send the push to a specific device. Appears as target_device_iden on the push. You can find this using the /v2/devices call.")]
        public string Pushbullet_Device { get; set; }

        [Setting, DefaultValue(""), Category("Pushover"), DisplayName("Application Token"), Description("The application Token/Key.")]
        public string Pushover_Token { get; set; }

        [Setting, DefaultValue(""), Category("Pushover"), DisplayName("User Key"), Description("The authentication key.")]
        public string Pushover_UserKey { get; set; }

        [Setting, DefaultValue(""), Category("Pushover"), DisplayName("Device"), Description("our user's device name to send the message directly to that device, rather than all of the user's devices")]
        public string Pushover_Device { get; set; }

        #endregion

        #region  Bot Events

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Start { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Stop { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_MapChanged { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_QuestAccepted { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_ProfileChanged { get; set; }

        #endregion

        #region  Player Events

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_LevelUp { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Death { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Achievement { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_BGLeft { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_BGJoined { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Emote { get; set; }

        #endregion

        #region  Chat Events

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Whisper { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Bnet { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_GuildMessage { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_SayMessage { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_PartyMessage { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_BGMessage { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_OfficerMessage { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Gamemastermessage { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Disconnect { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Trademessage { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Raidmessage { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Yellmessage { get; set; }

        [Setting, DefaultValue(true), Browsable(false)]
        public bool ON_Addonmessage { get; set; }

        [Setting, Browsable(false)]
        public long LastStatCounted { get; set; }

        #endregion
    }
}