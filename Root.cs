#region License
// Author: Moreno Sint Hill alias Mirabis
// Created on: 27/10/2013                
// Last Edited on: 01/12/2014
// Project: BuddyPush
// File: Root.cs
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
namespace BuddyPush
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    using BuddyPush.Externals;
    using BuddyPush.Interface;
    using BuddyPush.Providers;

    using Styx;
    using Styx.Common;
    using Styx.CommonBot;
    using Styx.Plugins;
    using Styx.WoWInternals;

    public class Root : HBPlugin
    {
        #region HBPlugin overrides

        internal static BetterWebClient Sessionclient = new BetterWebClient();

        private Form _newtempui;

        /// <summary>
        ///     Plugin Name
        /// </summary>
        public override string Name
        {
            get { return "BuddyPush"; }
        }

        /// <summary>
        ///     Plugin Author
        /// </summary>
        public override string Author
        {
            get { return "Mirabis"; }
        }

        /// <summary>
        ///     Version (Major, minor, build, revision);
        /// </summary>
        public override Version Version
        {
            get { return new Version(2, 0, 0); }
        }

        public override bool WantButton
        {
            get { return true; }
        }

        /// <summary>
        ///     Initializes the plugin
        /// </summary>
        public override void OnEnable()
        {
            Logging.Write("[BuddyPush] -- Adding character name to Filter list");
            Filter.Add(StyxWoW.Me.Name);
            Logging.Write("[BuddyPush] -- Registering Event listeners");
            RegisterEvents();
            Logging.Write("[BuddyPush] Initialization complete!");
            Logging.Write("[BuddyPush] Visiting StatTracker for statistics, data will be removed every 30 days.");
            StatCounter();
        }

        /// <summary>
        ///     Shutdown type
        /// </summary>
        public override void OnDisable()
        {
            //Well cuz we aint sure they where hooked... not sure if causes problems
            RemoveEvents();
            BotEvents.OnBotStopped -= OnStop;
            BotEvents.OnBotStarted -= OnStart;
            BotEvents.Player.OnPlayerDied -= OnDead;
            Chat.Emote -= EmoteMessage;
            BotEvents.Player.OnLevelUp -= OnLevel;
            BotEvents.Player.OnPlayerDied -= OnDead;
            BotEvents.Player.OnLevelUp -= OnLevel;
            Chat.Channel -= TradeMessage;
            Chat.Say -= SayMessage;
            Chat.Whisper -= WhisperMessage;
            Chat.Guild -= GuildMessage;
            Chat.Raid -= RaidMessage;
            Chat.RaidLeader -= RaidMessage;
            Chat.Yell -= YellMessage;
            Chat.Officer -= OfficerMessage;
            Chat.Party -= PartyMessage;
            Chat.PartyLeader -= PartyMessage;
            Chat.BattlegroundLeader -= BGMessage;
            Chat.AllianceBattleground -= BGMessage;
            Chat.HordeBattleground -= BGMessage;
            Lua.Events.DetachEvent("CHAT_MSG_BN_WHISPER", BNetMessage);
            Lua.Events.DetachEvent("ACHIEVEMENT_EARNED", AchievMessage);
            Lua.Events.DetachEvent("GMRESPONSE_RECEIVED", GMMessage);

            BotEvents.Profile.OnNewProfileLoaded -= OnNewProfile;
            BotEvents.Profile.OnNewOuterProfileLoaded -= OnNewProfile;
            BotEvents.Questing.OnQuestAccepted -= OnQuestAccept;
            BotEvents.Player.OnMapChanged -= OnMapChanged;
            BotEvents.Battleground.OnBattlegroundLeft -= BgLeft;
            BotEvents.Battleground.OnBattlegroundEntered -= BGEntered;
            Chat.Addon -= ChatOnAddon;
        }

        public override void Pulse()
        {
            //Fix Pulse Errors
        }

        private static void StatCounter()
        {
            try
            {
                // To support multiple calendars
                int statcounterDate = Utilities.ConvertToUnixTimestamp(DateTime.Now);

                // Compare this value against the last saved day in settings
                if (statcounterDate != MySettings.Instance.LastStatCounted)
                {
                    // Download the file, to increment the statcount
                    Sessionclient.DownloadDataAsync(new Uri(Encoding.Unicode.GetString(Convert.FromBase64String("aAB0AHQAcAA6AC8ALwBjAC4AcwB0AGEAdABjAG8AdQBuAHQAZQByAC4AYwBvAG0ALwAxADAAMQA2ADQAMAAwADMALwAwAC8AZAA3ADEAYgA3AGMAZQBiAC8AMAAvAA=="))));

                    // Once the Parallel.Invoke is finished, continue
                    // Update the LastStatCounted to prevent it from re-running on the same day
                    MySettings.Instance.LastStatCounted = statcounterDate;

                    // Save the last date, incase they never change their settings
                    MySettings.Instance.Save();
                }
            }
            catch
            {
                /* Catch all errors */
            }
        }

        /// <summary>
        ///     Called when the button for this CC is pressed.
        /// </summary>
        public override void OnButtonPress()
        {
            //Settings.Instance.Load();
            if (this._newtempui == null || this._newtempui.IsDisposed || this._newtempui.Disposing) this._newtempui = new UI();
            if (this._newtempui != null || this._newtempui.IsDisposed) this._newtempui.ShowDialog();
        }

        #endregion

        #region Hooks

        /// <summary>
        ///     Registers our BotEvents
        /// </summary>
        private static void RegisterEvents()
        {
            if (ST.ON_ProfileChanged)
            {
                BotEvents.Profile.OnNewProfileLoaded += OnNewProfile;
                BotEvents.Profile.OnNewOuterProfileLoaded += OnNewProfile;
            }
            if (ST.ON_QuestAccepted) BotEvents.Questing.OnQuestAccepted += OnQuestAccept;
            if (ST.ON_MapChanged) BotEvents.Player.OnMapChanged += OnMapChanged;
            if (ST.ON_BGLeft) BotEvents.Battleground.OnBattlegroundLeft += BgLeft;
            if (ST.ON_BGJoined) BotEvents.Battleground.OnBattlegroundEntered += BGEntered;
            if (ST.ON_Stop) BotEvents.OnBotStopped += OnStop;
            if (ST.ON_Start) BotEvents.OnBotStarted += OnStart;
            if (ST.ON_Death) BotEvents.Player.OnPlayerDied += OnDead;
            if (ST.ON_Emote) Chat.Emote += EmoteMessage;
            if (ST.ON_Addonmessage) Chat.Addon += ChatOnAddon;
            if (ST.ON_LevelUp) BotEvents.Player.OnLevelUp += OnLevel;
            if (ST.ON_Trademessage) Chat.Channel += TradeMessage;
            if (ST.ON_SayMessage) Chat.Say += SayMessage;
            if (ST.ON_Whisper) Chat.Whisper += WhisperMessage;
            if (ST.ON_GuildMessage) Chat.Guild += GuildMessage;
            if (ST.ON_Raidmessage)
            {
                Chat.Raid += RaidMessage;
                Chat.RaidLeader += RaidMessage;
            }
            if (ST.ON_Yellmessage) Chat.Yell += YellMessage;
            if (ST.ON_OfficerMessage) Chat.Officer += OfficerMessage;
            if (ST.ON_PartyMessage)
            {
                Chat.Party += PartyMessage;
                Chat.PartyLeader += PartyMessage;
            }
            if (ST.ON_BGMessage)
            {
                Chat.BattlegroundLeader += BGMessage;
                if (StyxWoW.Me.IsAlliance) Chat.AllianceBattleground += BGMessage;
                Chat.HordeBattleground += BGMessage;
            }
            if (ST.ON_Bnet) Lua.Events.AttachEvent("CHAT_MSG_BN_WHISPER", BNetMessage);
            if (ST.ON_Achievement) Lua.Events.AttachEvent("ACHIEVEMENT_EARNED", AchievMessage);
            if (ST.ON_Gamemastermessage) Lua.Events.AttachEvent("GMRESPONSE_RECEIVED", GMMessage);
        }

        /// <summary>
        ///     Resets all the Events
        /// </summary>
        private static void RemoveEvents()
        {
            if (ST.ON_ProfileChanged)
            {
                BotEvents.Profile.OnNewProfileLoaded -= OnNewProfile;
                BotEvents.Profile.OnNewOuterProfileLoaded -= OnNewProfile;
            }
            if (ST.ON_QuestAccepted) BotEvents.Questing.OnQuestAccepted -= OnQuestAccept;
            if (ST.ON_MapChanged) BotEvents.Player.OnMapChanged -= OnMapChanged;
            if (ST.ON_BGLeft) BotEvents.Battleground.OnBattlegroundLeft -= BgLeft;
            if (ST.ON_BGJoined) BotEvents.Battleground.OnBattlegroundEntered -= BGEntered;
            if (ST.ON_Stop) BotEvents.OnBotStopped -= OnStop;
            if (ST.ON_Start) BotEvents.OnBotStarted -= OnStart;
            if (ST.ON_Death) BotEvents.Player.OnPlayerDied -= OnDead;
            if (ST.ON_Emote) Chat.Emote -= EmoteMessage;
            if (ST.ON_Addonmessage) Chat.Addon -= ChatOnAddon;
            if (ST.ON_LevelUp) BotEvents.Player.OnLevelUp -= OnLevel;
            if (ST.ON_Trademessage) Chat.Channel -= TradeMessage;
            if (ST.ON_SayMessage) Chat.Say -= SayMessage;
            if (ST.ON_Whisper) Chat.Whisper -= WhisperMessage;
            if (ST.ON_GuildMessage) Chat.Guild -= GuildMessage;
            if (ST.ON_Raidmessage)
            {
                Chat.Raid -= RaidMessage;
                Chat.RaidLeader -= RaidMessage;
            }
            if (ST.ON_Yellmessage) Chat.Yell -= YellMessage;
            if (ST.ON_OfficerMessage) Chat.Officer -= OfficerMessage;
            if (ST.ON_PartyMessage)
            {
                Chat.Party -= PartyMessage;
                Chat.PartyLeader -= PartyMessage;
            }
            if (ST.ON_BGMessage)
            {
                Chat.BattlegroundLeader -= BGMessage;
                if (StyxWoW.Me.IsAlliance) Chat.AllianceBattleground -= BGMessage;
                Chat.HordeBattleground -= BGMessage;
            }
            if (ST.ON_Bnet) Lua.Events.DetachEvent("CHAT_MSG_BN_WHISPER", BNetMessage);
            if (ST.ON_Achievement) Lua.Events.DetachEvent("ACHIEVEMENT_EARNED", AchievMessage);
            if (ST.ON_Gamemastermessage) Lua.Events.DetachEvent("GMRESPONSE_RECEIVED", GMMessage);
        }

        /// <summary>
        ///     Resets all the hooks
        /// </summary>
        public static void Reset()
        {
            RemoveEvents();
            RegisterEvents();
        }

        #endregion

        #region Filter

        /// <summary>
        ///     Lists to check if exist, editable
        /// </summary>
        internal static List<string> Filter = new List<string> { "Bot", "Hack", "Honorbuddy", "Report", };

        private static bool Filtered(string eg)
        {
            if (MySettings.Instance.CheckTriggerList) return eg.Split(' ').Any(word => Filter.Any(a => a.Like(word)));
            return true;
            // Logging.Write(eg);;
        }

        #endregion

        #region Messages

        #region Message:  Chat

        /// <summary>
        ///     Sends Chat Messages
        /// </summary>
        /// <param name="e"></param>
        private static void SayMessage(Chat.ChatLanguageSpecificEventArgs eg)
        {
            try
            {
                if (!Filtered(eg.Message)) return; //Skip

                string title = string.Format("{0} Says ", eg.Author);
                SendNotification(eg.Message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message : Emote

        /// <summary>
        ///     Sends Chat Messages
        /// </summary>
        /// <param name="e"></param>
        private static void EmoteMessage(Chat.ChatAuthoredEventArgs eg)
        {
            try
            {
                if (!Filtered(eg.Message)) return; //Skip

                string title = string.Format("{0} Emotes ", eg.Author);
                SendNotification(eg.Message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Battleground

        /// <summary>
        ///     Sends Battleground Messages
        /// </summary>
        /// <param name="e"></param>
        private static void BGMessage(Chat.ChatSimpleMessageEventArgs eg)
        {
            try
            {
                if (!Filtered(eg.Message)) return; //Skip

                const string title = "Battleground message";
                SendNotification(eg.Message, ST.Pushover_Device, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Party

        /// <summary>
        ///     Sends Battleground Messages
        /// </summary>
        /// <param name="e"></param>
        private static void PartyMessage(Chat.ChatLanguageSpecificEventArgs eg)
        {
            try
            {
                if (!Filtered(eg.Message)) return; //Skip
                string title = string.Format("Party message from {0}", eg.Author);
                SendNotification(eg.Message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Officer

        /// <summary>
        ///     Sends Officer Messages
        /// </summary>
        /// <param name="e"></param>
        private static void OfficerMessage(Chat.ChatLanguageSpecificEventArgs eg)
        {
            try
            {
                if (!Filtered(eg.Message)) return; //Skip
                string title = string.Format("Officer message from {0}", eg.Author);
                SendNotification(eg.Message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Guild

        /// <summary>
        ///     Sends Guild Messages
        /// </summary>
        /// <param name="e"></param>
        private static void GuildMessage(Chat.ChatGuildEventArgs eg)
        {
            try
            {
                if (!Filtered(eg.Message)) return; //Skip
                string title = string.Format("Guild message from {0}", eg.Author);
                SendNotification(eg.Message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Raid

        /// <summary>
        ///     Sends Raid Messages
        /// </summary>
        /// <param name="e"></param>
        private static void RaidMessage(Chat.ChatLanguageSpecificEventArgs eg)
        {
            try
            {
                if (!Filtered(eg.Message)) return; //Skip
                string title = string.Format("Raid message from {0}", eg.Author);
                SendNotification(eg.Message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Trade

        /// <summary>
        ///     Sends Trade Messages
        /// </summary>
        /// <param name="e"></param>
        private static void TradeMessage(Chat.ChatChannelSpecificEventArgs eg)
        {
            try
            {
                if (!Filtered(eg.Message)) return; //Skip
                string title = string.Format("Trade message from {0}", eg.Author);
                SendNotification(eg.Message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Whisper

        /// <summary>
        ///     Sends Whisper Messages
        /// </summary>
        /// <param name="e"></param>
        private static void WhisperMessage(Chat.ChatWhisperEventArgs eg)
        {
            try
            {
                //if (!Filtered(eg.Message)) return; //Skip
                string title = string.Format("Whisper from {0}", eg.Author);
                SendNotification(eg.Message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Yell

        /// <summary>
        ///     Sends Yell Messages
        /// </summary>
        /// <param name="e"></param>
        private static void YellMessage(Chat.ChatLanguageSpecificEventArgs eg)
        {
            try
            {
                if (!Filtered(eg.Message)) return; //Skip
                string title = string.Format("{0} Yelled!", eg.Author);
                SendNotification(eg.Message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Bnet

        /// <summary>
        ///     Sends Bnet Messages
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void BNetMessage(object sender, LuaEventArgs args)
        {
            try
            {
                var message = (string)args.Args[0];
                string title = string.Format("BNET Message from {0}", args.Args[1]);

                SendNotification(message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  Achievements

        /// <summary>
        ///     Sends Achievements Messages
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void AchievMessage(object sender, LuaEventArgs args)
        {
            try
            {
                //   string title = string.Format("{0} Earned", e.SourceName);
                // SendNotification(eg.Message,  title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #region Message:  GM

        /// <summary>
        ///     Sends Game Master Messages
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private static void GMMessage(object sender, LuaEventArgs args)
        {
            try
            {
                string title = string.Format("GameMaster {0} has sent u a message", args.Args[1]);
                var message = (string)args.Args[0];

                SendNotification(message, title);
            }
            catch (Exception ex)
            {
                Logging.WriteException(ex);
            }
        }

        #endregion

        #endregion

        #region Events

        private static void ChatOnAddon(Chat.ChatAddonEventArgs args)
        {
            if (!Filtered(args.Message)) return; //Skip
            string title = string.Format("{0}-Addon message from: {1}", args.Prefix, args.Sender);
            string message = string.Format("Type: {0} \n Message: {1}", args.Type, args.Message);
            SendNotification(message, title);
        }

        private static void OnNewProfile(BotEvents.Profile.NewProfileLoadedEventArgs args)
        {
            string title = string.Format("New Profile Loaded: {0}", args.NewProfile);
            string message = string.Format("Ur Honorbuddy instance has changed profile from {0} to {1}.", args.OldProfile, args.NewProfile);
            SendNotification(message, title);
        }

        private static void OnQuestAccept(Quest quest)
        {
            string title = string.Format("Quest Accepted: {0}", quest.Name);
            string message = string.Format("Description: {0}   \n  RequiredLevel: {1} \n  RewardMoney: {2} \n RewardXP: {3}.", quest.Description, quest.RequiredLevel, quest.RewardMoney, quest.RewardXp);
            string url = string.Format("http://www.wowhead.com/quest={0}", quest.Id);
            SendNotification(message, title, url);
        }

        private static void OnMapChanged(BotEvents.Player.MapChangedEventArgs args)
        {
            string title = string.Format("Map Changed to {0}", args.NewMapName);
            const string message = "Ur Honorbuddy instance has changed maps.";
            SendNotification(message, title);
        }

        private static void BGEntered(BattlegroundType type)
        {
            string title = string.Format("Battleground ({0}) Entered", type);
            const string message = "Ur Honorbuddy instance has joined a battleground.";
            SendNotification(message, title);
        }

        private static void BgLeft(EventArgs args)
        {
            const string title = "Battleground Left";
            const string message = "Ur Honorbuddy instance has left a battleground.";
            SendNotification(message, title);
        }

        private static void OnDead()
        {
            const string title = "I Died";
            const string message = "I've lost all my health";
            SendNotification(message, title);
        }

        private static void OnStop(EventArgs args)
        {
            const string title = "Honorbuddy Stopped";
            const string message = "Ur Honorbuddy instance has stopped";
            SendNotification(message, title);
        }

        private static void OnStart(EventArgs args)
        {
            const string title = "Honorbuddy Started";
            const string message = "Ur Honorbuddy instance has started";
            SendNotification(message, title);
        }

        private static void OnLevel(BotEvents.Player.LevelUpEventArgs args)
        {
            const string title = "Level Up";
            string message = string.Format("Leveled up from {0} to {1}", args.OldLevel, args.NewLevel);
            SendNotification(message, title);
        }

        #endregion

        #region Tiny'r

        private static MySettings ST
        {
            get { return MySettings.Instance; }
        }

        internal static void SendNotification(string message, string title, string url = "")
        {
            if (MySettings.Instance.Push_Boxcar2) new Task(() => BoxCar2.PushNotification(message, title, url)).Start();
            if (MySettings.Instance.Push_NMY) new Task(() => NotifyMyAndroid.PushNotification(message, title, url)).Start();
            if (MySettings.Instance.Push_Pushalot) new Task(() => Pushalot.PushNotification(message, title, url, title, (int)MySettings.Instance.Pushover_Priority, MySettings.Instance.Pushalot_Silent, MySettings.Instance.Pushalot_Important)).Start();
            if (MySettings.Instance.Push_Prowl) new Task(() => Prowl.PushNotification(message, title, url)).Start();
            if (MySettings.Instance.Push_Pushover) new Task(() => Pushover.PushNotification(message, title, url, title)).Start();
            if (MySettings.Instance.Push_Pushbullet) new Task(() => PushBullet.PushNotification(message, title, url)).Start();
            if (MySettings.Instance.Push_Toasty) new Task(() => Toasty.PushNotification(message, title)).Start();
        }

        #endregion
    }
}