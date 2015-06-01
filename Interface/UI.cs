//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.UI.cs
// Copyright:  2015, Moreno Sint Hill - All rights reserved.
//  
// ALL CONTENTS IN THIS PROJECT ARE PROTECTED BY COPYRIGHT. EXCEPT AS SPECIFICALLY PERMITTED HEREIN, 
// NO PORTION OF THE INFORMATION IN THIS PROJECT MAY BE REPRODUCED IN ANY FORM, OR BY ANY MEANS, WITHOUT PRIOR WRITTEN PERMISSION FROM Mirabis <info@mirabis.nl>. 
// IT IS NOT PERMITTED TO MODIFY, DISTRIBUTE, PUBLISH, TRANSMIT OR CREATE DERIVATIVE WORKS OF ANY MATERIAL FOUND IN THIS PROJECT FOR ANY PUBLIC OR COMMERCIAL PURPOSES.

#region Usings

using System;
using System.ComponentModel;
using System.Windows.Forms;
using PushHub.Properties;

#endregion

namespace PushHub.Interface
{
    public partial class UI : Form
    {
        public UI()
        {
            InitializeComponent();
            LoadOldSettings();
            tbChangelog.Text = Resources.Changelog;
            tbChangelog.ReadOnly = true;
            Closing += OnClosing;
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs)
        {
            MySettings.Instance.Save();
            Root.RemoveEvents();
            Root.RegisterEvents();
        }

        private void addTrigger_Click(object sender, EventArgs e)
        {
            var trigger = tbField.Text;

            if (!String.IsNullOrEmpty(trigger))
            {
                Root.Filter.Add(trigger);
                tbFilter.DataSource = null;
                tbFilter.DataSource = Root.Filter;
                tbFilter.Refresh();
            }
            //Can remove in future
            rmTrigger.Enabled = true;
        }

        private void rmTrigger_Click(object sender, EventArgs e)
        {
            // The Remove button was clicked.
            var selectedIndex = tbFilter.SelectedIndex;

            try
            {
                // Remove the item in the List.
                Root.Filter.RemoveAt(selectedIndex);
            }
            catch {}

            tbFilter.DataSource = null;
            tbFilter.DataSource = Root.Filter;
            tbFilter.Refresh();

            if (tbFilter.Items.Count == 0) rmTrigger.Enabled = false;
        }

        private void LoadOldSettings()
        {
            MySettings.Instance.Load();
            sGrid.SelectedObject = MySettings.Instance;
            ON_Disconnect.Checked = MySettings.Instance.ON_Disconnect;
            tbFilter.DataSource = Root.Filter;
            ON_Filtering.Checked = MySettings.Instance.CheckTriggerList;
            ON_RaidMessage.Checked = MySettings.Instance.ON_Raidmessage;
            ON_Addon.Checked = MySettings.Instance.ON_Addonmessage;
            ON_Yell.Checked = MySettings.Instance.ON_Yellmessage;
            ON_LevelUp.Checked = MySettings.Instance.ON_LevelUp;
            ON_Whisper.Checked = MySettings.Instance.ON_Whisper;
            ON_BnetMessage.Checked = MySettings.Instance.ON_Bnet;
            ON_GuildMessage.Checked = MySettings.Instance.ON_GuildMessage;
            ON_Say.Checked = MySettings.Instance.ON_SayMessage;
            ON_PartyMessage.Checked = MySettings.Instance.ON_PartyMessage;
            ON_BGMessage.Checked = MySettings.Instance.ON_BGMessage;
            ON_Officer.Checked = MySettings.Instance.ON_OfficerMessage;
            ON_GameMaster.Checked = MySettings.Instance.ON_Gamemastermessage;
            ON_TradeMessage.Checked = MySettings.Instance.ON_Trademessage;
            ON_Death.Checked = MySettings.Instance.ON_Death;
            ON_Achiev.Checked = MySettings.Instance.ON_Achievement;
            ON_BGLeft.Checked = MySettings.Instance.ON_BGLeft;
            ON_BGJoined.Checked = MySettings.Instance.ON_BGJoined;
            ON_Start.Checked = MySettings.Instance.ON_Start;
            ON_Stop.Checked = MySettings.Instance.ON_Stop;
            ON_MapChanged.Checked = MySettings.Instance.ON_MapChanged;
            ON_QuestAccepted.Checked = MySettings.Instance.ON_QuestAccepted;
            ON_ProfileChanged.Checked = MySettings.Instance.ON_ProfileChanged;
        }

        private void TestBtn_Click(object sender, EventArgs e) { Root.SendNotification("This is a test notification", "PushHub Test", ""); }
        private void ON_LevelUp_CheckedChanged(object sender) { MySettings.Instance.ON_LevelUp = ON_LevelUp.Checked; }
        private void ON_Whisper_CheckedChanged(object sender) { MySettings.Instance.ON_Whisper = ON_Whisper.Checked; }
        private void ON_BnetMessage_CheckedChanged(object sender) { MySettings.Instance.ON_Bnet = ON_BnetMessage.Checked; }
        private void ON_GuildMessage_CheckedChanged(object sender) { MySettings.Instance.ON_GuildMessage = ON_GuildMessage.Checked; }
        private void ON_Say_CheckedChanged(object sender) { MySettings.Instance.ON_SayMessage = ON_Say.Checked; }
        private void ON_PartyMessage_CheckedChanged(object sender) { MySettings.Instance.ON_PartyMessage = ON_PartyMessage.Checked; }
        private void ON_BGMessage_CheckedChanged(object sender) { MySettings.Instance.ON_BGMessage = ON_BGMessage.Checked; }
        private void ON_Officer_CheckedChanged(object sender) { MySettings.Instance.ON_OfficerMessage = ON_Officer.Checked; }
        private void ON_GameMaster_CheckedChanged(object sender) { MySettings.Instance.ON_Gamemastermessage = ON_GameMaster.Checked; }
        private void ON_TradeMessage_CheckedChanged(object sender) { MySettings.Instance.ON_Trademessage = ON_TradeMessage.Checked; }
        private void ON_Death_CheckedChanged(object sender) { MySettings.Instance.ON_Death = ON_Death.Checked; }
        private void ON_Achiev_CheckedChanged(object sender) { MySettings.Instance.ON_Achievement = ON_Achiev.Checked; }
        private void ON_BGLeft_CheckedChanged(object sender) { MySettings.Instance.ON_BGLeft = ON_BGLeft.Checked; }
        private void ON_BGJoined_CheckedChanged(object sender) { MySettings.Instance.ON_BGJoined = ON_BGJoined.Checked; }
        private void ON_Start_CheckedChanged(object sender) { MySettings.Instance.ON_Start = ON_Start.Checked; }
        private void ON_Stop_CheckedChanged(object sender) { MySettings.Instance.ON_Stop = ON_Stop.Checked; }
        private void ON_MapChanged_CheckedChanged(object sender) { MySettings.Instance.ON_MapChanged = ON_MapChanged.Checked; }
        private void ON_QuestAccepted_CheckedChanged(object sender) { MySettings.Instance.ON_QuestAccepted = ON_QuestAccepted.Checked; }
        private void ON_ProfileChanged_CheckedChanged(object sender) { MySettings.Instance.ON_ProfileChanged = ON_ProfileChanged.Checked; }
        private void chromeCheckbox1_CheckedChanged(object sender) { MySettings.Instance.ON_Raidmessage = ON_RaidMessage.Checked; }
        private void chromeCheckbox1_CheckedChanged_1(object sender) { MySettings.Instance.ON_Yellmessage = ON_Yell.Checked; }
        private void ON_Addon_CheckedChanged(object sender) { MySettings.Instance.ON_Addonmessage = ON_Addon.Checked; }
        private void ON_Filtering_CheckedChanged(object sender) { MySettings.Instance.CheckTriggerList = ON_Filtering.Checked; }
        private void ON_Disconnect_CheckedChanged(object sender) { MySettings.Instance.ON_Disconnect = ON_Disconnect.Checked; }
    }
}