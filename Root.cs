//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.Root.cs
// Copyright:  2015, Moreno Sint Hill - All rights reserved.
//  
// ALL CONTENTS IN THIS PROJECT ARE PROTECTED BY COPYRIGHT. EXCEPT AS SPECIFICALLY PERMITTED HEREIN, 
// NO PORTION OF THE INFORMATION IN THIS PROJECT MAY BE REPRODUCED IN ANY FORM, OR BY ANY MEANS, WITHOUT PRIOR WRITTEN PERMISSION FROM Mirabis <info@mirabis.nl>. 
// IT IS NOT PERMITTED TO MODIFY, DISTRIBUTE, PUBLISH, TRANSMIT OR CREATE DERIVATIVE WORKS OF ANY MATERIAL FOUND IN THIS PROJECT FOR ANY PUBLIC OR COMMERCIAL PURPOSES.
#region Usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BuddyPush.Externals;
using JetBrains.Annotations;
using PushHub.Externals;
using PushHub.Interface;
using PushHub.Providers;
using Styx;
using Styx.Common;
using Styx.CommonBot;
using Styx.Plugins;
using Styx.WoWInternals;

#endregion

namespace PushHub
{
    public class Root : HBPlugin
    {
        #region HBPlugin overrides

        private Form _newtempui;

        /// <summary>
        ///     Plugin Name
        /// </summary>
        public override string Name
        {
            get { return "PushHub"; }
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
            get { return new Version(2, 0, 3,7); }
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
            Logging.Write("[PushHub] -- Adding character name to Filter list");
            if (!Filter.Contains(StyxWoW.Me.Name))
            Filter.Add(StyxWoW.Me.Name);
            Logging.Write("[PushHub] -- Registering Event listeners");
            RegisterEvents();
            Logging.Write("[PushHub] Initialization complete!");
            Logging.Write("[PushHub] Visiting StatTracker for statistics, data will be removed every 30 days.");
            StatCounter();
            OldMapName = StyxWoW.Me.MapName;
        }

        /// <summary>
        ///     Shutdown type
        /// </summary>
        public override void OnDisable()
        {
            //Well cuz we aint sure they where hooked... not sure if causes problems
            LuaEventHandler.Shutdown();
            BotEvents.OnBotStopped -= OnStop;
            BotEvents.OnBotStarted -= OnStart;
            BotEvents.Player.OnPlayerDied -= OnDead;
            Chat.Emote -= EmoteMessage;
            BotEvents.Player.OnLevelUp -= OnLevel;
            BotEvents.Player.OnPlayerDied -= OnDead;
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
            BotEvents.Profile.OnNewProfileLoaded -= OnNewProfile;
            BotEvents.Profile.OnNewOuterProfileLoaded -= OnNewProfile;
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
                var statcounterDate = Utilities.ConvertToUnixTimestamp(DateTime.Now);

                // Compare this value against the last saved day in settings
                if (statcounterDate != MySettings.Instance.LastStatCounted)
                {
                    // Download the file, to increment the statcount
                    new BetterWebClient().DownloadDataAsync(
                        new Uri(Encoding.Unicode.GetString(Convert.FromBase64String("aAB0AHQAcAA6AC8ALwBjAC4AcwB0AGEAdABjAG8AdQBuAHQAZQByAC4AYwBvAG0ALwAxADAAMQA2ADQAMAAwADMALwAwAC8AZAA3ADEAYgA3AGMAZQBiAC8AMAAvAA=="))));

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
            if (_newtempui == null || _newtempui.IsDisposed || _newtempui.Disposing) _newtempui = new UI();
            if (_newtempui != null || _newtempui.IsDisposed) _newtempui.ShowDialog();
        }

        #endregion

        #region Hooks

        /// <summary>
        ///     Registers our BotEvents
        /// </summary>
        internal static void RegisterEvents()
        {
            if (ST.ON_ProfileChanged)
            {
                BotEvents.Profile.OnNewProfileLoaded += OnNewProfile;
                BotEvents.Profile.OnNewOuterProfileLoaded += OnNewProfile;
            }
            if (ST.ON_QuestAccepted) LuaEventHandler.Register("QUEST_ACCEPTED", OnQuestAccept);
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

            if (ST.ON_Bnet) LuaEventHandler.Register("CHAT_MSG_BN_WHISPER", BNetMessage);
            if (ST.ON_Achievement) LuaEventHandler.Register("ACHIEVEMENT_EARNED", AchievMessage);
            if (ST.ON_Gamemastermessage) LuaEventHandler.Register("GMRESPONSE_RECEIVED", GMMessage);
            if (ST.ON_Disconnect) LuaEventHandler.Register("DISCONNECTED_FROM_SERVER", OnDisconected);
        }

        /// <summary>
        ///     Resets all the Events
        /// </summary>
        internal static void RemoveEvents()
        {
            if (!ST.ON_ProfileChanged)
            {
                BotEvents.Profile.OnNewProfileLoaded -= OnNewProfile;
                BotEvents.Profile.OnNewOuterProfileLoaded -= OnNewProfile;
            }
            if (!ST.ON_QuestAccepted) LuaEventHandler.UnRegister("QUEST_ACCEPTED", OnQuestAccept);
            if (!ST.ON_MapChanged) BotEvents.Player.OnMapChanged -= OnMapChanged;
            if (!ST.ON_BGLeft) BotEvents.Battleground.OnBattlegroundLeft -= BgLeft;
            if (!ST.ON_BGJoined) BotEvents.Battleground.OnBattlegroundEntered -= BGEntered;
            if (!ST.ON_Stop) BotEvents.OnBotStopped -= OnStop;
            if (!ST.ON_Start) BotEvents.OnBotStarted -= OnStart;
            if (!ST.ON_Death) BotEvents.Player.OnPlayerDied -= OnDead;
            if (!ST.ON_Emote) Chat.Emote -= EmoteMessage;
            if (!ST.ON_Addonmessage) Chat.Addon -= ChatOnAddon;
            if (!ST.ON_LevelUp) BotEvents.Player.OnLevelUp -= OnLevel;
            if (!ST.ON_Trademessage) Chat.Channel -= TradeMessage;
            if (!ST.ON_SayMessage) Chat.Say -= SayMessage;
            if (!ST.ON_Whisper) Chat.Whisper -= WhisperMessage;
            if (!ST.ON_GuildMessage) Chat.Guild -= GuildMessage;
            if (!ST.ON_Raidmessage)
            {
                Chat.Raid -= RaidMessage;
                Chat.RaidLeader -= RaidMessage;
            }
            if (!ST.ON_Yellmessage) Chat.Yell -= YellMessage;
            if (!ST.ON_OfficerMessage) Chat.Officer -= OfficerMessage;
            if (!ST.ON_PartyMessage)
            {
                Chat.Party -= PartyMessage;
                Chat.PartyLeader -= PartyMessage;
            }
            if (!ST.ON_BGMessage)
            {
                Chat.BattlegroundLeader -= BGMessage;
                if (!StyxWoW.Me.IsAlliance) Chat.AllianceBattleground -= BGMessage;
                Chat.HordeBattleground -= BGMessage;
            }

            if (!ST.ON_Bnet) LuaEventHandler.UnRegister("CHAT_MSG_BN_WHISPER", BNetMessage);
            if (!ST.ON_Disconnect) LuaEventHandler.UnRegister("DISCONNECTED_FROM_SERVER", OnDisconected);
            if (!ST.ON_Achievement) LuaEventHandler.UnRegister("ACHIEVEMENT_EARNED", AchievMessage);
            if (!ST.ON_Gamemastermessage) LuaEventHandler.UnRegister("GMRESPONSE_RECEIVED", GMMessage);
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
        internal static List<string> Filter = new List<string> { "Bot", "Hack", "Honorbuddy", "Report" };

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

                var title = FormatIt( "{0} Says.", eg.Author);
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

                var title = FormatIt( "{0} Emotes.", eg.Author);
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
                var title = FormatIt( "Party message from {0}.", eg.Author);
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
                var title = FormatIt( "Officer message from {0}.", eg.Author);
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
                var title = FormatIt( "Guild message from {0}.", eg.Author);
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
                var title = FormatIt("Raid message from {0}.", eg.Author);
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
                var title = FormatIt( "Trade message from {0}.", eg.Author);
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
                var title = FormatIt("Whisper from {0}.", eg.Author);
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
                var title = FormatIt( "{0} Yelled!", eg.Author);
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
                var infos = Lua.GetReturnValues(FormatIt("return BNGetFriendInfoByID({0}))", args.Args[12]));
                var title =  FormatIt( "BNET Message from {0} ({1}).", infos[2],infos[4]);

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
                  string title = FormatIt( "Achievement Earned : {0}", args.EventName);
                  SendNotification(FormatIt("achievementID: {0} -- {1}", args.Args[0],args.EventName), title, string.Format("http://www.wowhead.com/achievement={0}", args.Args[0]));
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
                var title = FormatIt( "GameMaster ({0}) has sent you a message", args.Args[1]);
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
            var title = FormatIt( "{0}-Addon message from: {1}", args.Prefix, args.Sender);
            string message = FormatIt( "Type: {0} \r\n Message: {1}", args.Type, args.Message);
            SendNotification(message, title);
        }

        private static void OnNewProfile(BotEvents.Profile.NewProfileLoadedEventArgs args)
        {
            var title = FormatIt( "New Profile Loaded: {0}", args.NewProfile.Name);
            var message = FormatIt( "Your Honorbuddy instance has changed profile from {1} to {0}.", args.OldProfile.Name, args.NewProfile.Name);
            SendNotification(message, title);
        }


        private static void OnQuestAccept(object sender, LuaEventArgs args)
        {
            var quest = Quest.FromId((uint)(double)args.Args[1]);
            var title = FormatIt( "Quest Accepted: {0}", quest.Name);
            var message = FormatIt( "Description: {0}   \r\n  RequiredLevel: {1} \n  RewardMoney: {2} \n RewardXP: {3}.", quest.Description, quest.RequiredLevel, quest.RewardMoney, quest.RewardXp);
            var url = FormatIt( "http://www.wowhead.com/quest={0}", quest.Id);
            SendNotification(message, title, url);
        }

        private static string OldMapName;

        private static void OnMapChanged(BotEvents.Player.MapChangedEventArgs args)
        {
            var title = FormatIt( "Map Changed to {0}", args.NewMapName);
            string message = FormatIt("Your Honorbuddy instance has changed maps from {1} to {0}.", OldMapName, args.NewMapName);
            OldMapName = args.NewMapName;
            SendNotification(message, title);
        }

        private static void BGEntered(BattlegroundType type)
        {
            var title = FormatIt("Battleground ({0}) Entered", type);
            string message = FormatIt("Your Honorbuddy instance has joined a battleground on map: {0}.", StyxWoW.Me.MapName);
            SendNotification(message, title);
        }

        private static void BgLeft(EventArgs args)
        {
            const string title = "Battleground Left";
            const string message = "Your Honorbuddy instance has left a battleground.";
            SendNotification(message, title);
        }

        private static void OnDead()
        {
            const string title = "I have Died";
            const string message = "I've lost all my health.";
            SendNotification(message, title);
        }

        private static void OnDisconected(object sender, LuaEventArgs args)
        {
            const string title = "Character Disconnected";
            const string message = "You've been disconnected.";
            SendNotification(message, title);
        }

        private static void OnStop(EventArgs args)
        {
            const string title = "Honorbuddy Stopped";
            const string message = "Your Honorbuddy instance has stopped!";
            SendNotification(message, title);
        }

        private static void OnStart(EventArgs args)
        {
            const string title = "Honorbuddy Started";
            const string message = "Your Honorbuddy instance has started!";
            SendNotification(message, title);
        }

        private static void OnLevel(BotEvents.Player.LevelUpEventArgs args)
        {
            const string title = "I Leveled Up!";
            var message = FormatIt( "I Leveled up from {0} to {1}.", args.OldLevel, args.NewLevel);
            SendNotification(message, title);
        }

        #endregion

        #region Tiny'r

        private static MySettings ST
        {
            get { return MySettings.Instance; }
        }

        private static readonly CapacityQueue<string> LogQueue = new CapacityQueue<string>(2);

        internal static void SendNotification(string message, string title, string url = null)
        {
            title = string.Format("{0}::{1}", StyxWoW.Me.Name, title);
            if (LogQueue.Contains(string.Format("{0}-{1}", message,title)))
            {
                return;
            }

            LogQueue.Enqueue(string.Format("{0}-{1}", message, title));
            if (MySettings.Instance.Push_Boxcar2) new Task(() => BoxCar2.PushNotification(message, title, url)).Start();
            if (MySettings.Instance.Push_NMY) new Task(() => NotifyMyAndroid.PushNotification(message, title, url)).Start();
            if (MySettings.Instance.Push_Pushalot) new Task(() => Pushalot.PushNotification(message, title, url, title, MySettings.Instance.Pushalot_Silent, MySettings.Instance.Pushalot_Important)).Start();
            if (MySettings.Instance.Push_Prowl) new Task(() => Prowl.PushNotification(message, title, url)).Start();
            if (MySettings.Instance.Push_Pushover) new Task(() => Pushover.PushNotification(message, title, url, title)).Start();
            if (MySettings.Instance.Push_Pushbullet) new Task(() => PushBullet.PushNotification(message, title, url)).Start();
            if (MySettings.Instance.Push_Toasty) new Task(() => Toasty.PushNotification(message, title)).Start();
        }

        ///<summary>
        /// Use "string".FormatIt(...) instead of FormatIt( "string, ...)
        /// Use {nl} in text to insert Environment.NewLine 
        ///</summary>
        ///<exception cref="ArgumentNullException">If format is null</exception>
        [StringFormatMethod("format")]
        public static string FormatIt(string format, params object[] args)
        {
            try
            {
                return format == null ? "Something went wrong." : string.Format(format, args).Replace("\r\n",Environment.NewLine);
            }
            catch (Exception ex)
            {
                Logger.FailLog("Exception Thrown: Inner => {0}   Message=> {1}",ex.InnerException,ex.Message);
                return "Something went wrong.";
            }
           
        }

        #endregion
    }
}
