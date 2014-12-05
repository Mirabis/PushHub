#region License
// Author: Moreno Sint Hill alias Mirabis
// Created on: 01/12/2014                
// Last Edited on: 01/12/2014
// Project: PushHub
// File: UI.cs
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
namespace PushHub.Interface
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;

    using PushHub.Properties;

    public partial class UI : Form
    {
        public UI()
        {
            this.InitializeComponent();
            this.LoadOldSettings();
            this.tbChangelog.Text = Resources.Changelog;
            this.tbChangelog.ReadOnly = true;
            this.Closing += OnClosing;
        }

        private void OnClosing(object sender, CancelEventArgs cancelEventArgs) { MySettings.Instance.Save(); }

        private void addTrigger_Click(object sender, EventArgs e)
        {
            string trigger = this.tbField.Text;

            if (!String.IsNullOrEmpty(trigger))
            {
                Root.Filter.Add(trigger);
                this.tbFilter.DataSource = null;
                this.tbFilter.DataSource = Root.Filter;
                this.tbFilter.Refresh();
            }
            //Can remove in future
            this.rmTrigger.Enabled = true;
        }

        private void rmTrigger_Click(object sender, EventArgs e)
        {
            // The Remove button was clicked.
            int selectedIndex = this.tbFilter.SelectedIndex;

            try
            {
                // Remove the item in the List.
                Root.Filter.RemoveAt(selectedIndex);
            }
            catch {}

            this.tbFilter.DataSource = null;
            this.tbFilter.DataSource = Root.Filter;
            this.tbFilter.Refresh();

            if (this.tbFilter.Items.Count == 0) this.rmTrigger.Enabled = false;
        }

        private void LoadOldSettings()
        {
            MySettings.Instance.Load();
            this.sGrid.SelectedObject = MySettings.Instance;
            this.tbFilter.DataSource = Root.Filter;
            this.ON_Filtering.Checked = MySettings.Instance.CheckTriggerList;
            this.ON_RaidMessage.Checked = MySettings.Instance.ON_Raidmessage;
            this.ON_Addon.Checked = MySettings.Instance.ON_Addonmessage;
            this.ON_Yell.Checked = MySettings.Instance.ON_Yellmessage;
            this.ON_LevelUp.Checked = MySettings.Instance.ON_LevelUp;
            this.ON_Whisper.Checked = MySettings.Instance.ON_Whisper;
            this.ON_BnetMessage.Checked = MySettings.Instance.ON_Bnet;
            this.ON_GuildMessage.Checked = MySettings.Instance.ON_GuildMessage;
            this.ON_Say.Checked = MySettings.Instance.ON_SayMessage;
            this.ON_PartyMessage.Checked = MySettings.Instance.ON_PartyMessage;
            this.ON_BGMessage.Checked = MySettings.Instance.ON_BGMessage;
            this.ON_Officer.Checked = MySettings.Instance.ON_OfficerMessage;
            this.ON_GameMaster.Checked = MySettings.Instance.ON_Gamemastermessage;
            this.ON_TradeMessage.Checked = MySettings.Instance.ON_Trademessage;
            this.ON_Death.Checked = MySettings.Instance.ON_Death;
            this.ON_Achiev.Checked = MySettings.Instance.ON_Achievement;
            this.ON_BGLeft.Checked = MySettings.Instance.ON_BGLeft;
            this.ON_BGJoined.Checked = MySettings.Instance.ON_BGJoined;
            this.ON_Start.Checked = MySettings.Instance.ON_Start;
            this.ON_Stop.Checked = MySettings.Instance.ON_Stop;
            this.ON_MapChanged.Checked = MySettings.Instance.ON_MapChanged;
            this.ON_QuestAccepted.Checked = MySettings.Instance.ON_QuestAccepted;
            this.ON_ProfileChanged.Checked = MySettings.Instance.ON_ProfileChanged;
        }

        private void TestBtn_Click(object sender, EventArgs e) { Root.SendNotification("This is a test notification", "PushHub Test", ""); }

        private void ON_LevelUp_CheckedChanged(object sender) { MySettings.Instance.ON_LevelUp = this.ON_LevelUp.Checked; }

        private void ON_Whisper_CheckedChanged(object sender) { MySettings.Instance.ON_Whisper = this.ON_Whisper.Checked; }

        private void ON_BnetMessage_CheckedChanged(object sender) { MySettings.Instance.ON_Bnet = this.ON_BnetMessage.Checked; }

        private void ON_GuildMessage_CheckedChanged(object sender) { MySettings.Instance.ON_GuildMessage = this.ON_GuildMessage.Checked; }

        private void ON_Say_CheckedChanged(object sender) { MySettings.Instance.ON_SayMessage = this.ON_Say.Checked; }

        private void ON_PartyMessage_CheckedChanged(object sender) { MySettings.Instance.ON_PartyMessage = this.ON_PartyMessage.Checked; }

        private void ON_BGMessage_CheckedChanged(object sender) { MySettings.Instance.ON_BGMessage = this.ON_BGMessage.Checked; }

        private void ON_Officer_CheckedChanged(object sender) { MySettings.Instance.ON_OfficerMessage = this.ON_Officer.Checked; }

        private void ON_GameMaster_CheckedChanged(object sender) { MySettings.Instance.ON_Gamemastermessage = this.ON_GameMaster.Checked; }

        private void ON_TradeMessage_CheckedChanged(object sender) { MySettings.Instance.ON_Trademessage = this.ON_TradeMessage.Checked; }

        private void ON_Death_CheckedChanged(object sender) { MySettings.Instance.ON_Death = this.ON_Death.Checked; }

        private void ON_Achiev_CheckedChanged(object sender) { MySettings.Instance.ON_Achievement = this.ON_Achiev.Checked; }

        private void ON_BGLeft_CheckedChanged(object sender) { MySettings.Instance.ON_BGLeft = this.ON_BGLeft.Checked; }

        private void ON_BGJoined_CheckedChanged(object sender) { MySettings.Instance.ON_BGJoined = this.ON_BGJoined.Checked; }


        private void ON_Start_CheckedChanged(object sender) { MySettings.Instance.ON_Start = this.ON_Start.Checked; }

        private void ON_Stop_CheckedChanged(object sender) { MySettings.Instance.ON_Stop = this.ON_Stop.Checked; }

        private void ON_MapChanged_CheckedChanged(object sender) { MySettings.Instance.ON_MapChanged = this.ON_MapChanged.Checked; }

        private void ON_QuestAccepted_CheckedChanged(object sender) { MySettings.Instance.ON_QuestAccepted = this.ON_QuestAccepted.Checked; }

        private void ON_ProfileChanged_CheckedChanged(object sender) { MySettings.Instance.ON_ProfileChanged = this.ON_ProfileChanged.Checked; }

        private void chromeCheckbox1_CheckedChanged(object sender) { MySettings.Instance.ON_Raidmessage = this.ON_RaidMessage.Checked; }

        private void chromeCheckbox1_CheckedChanged_1(object sender) { MySettings.Instance.ON_Yellmessage = this.ON_Yell.Checked; }

        private void ON_Addon_CheckedChanged(object sender) { MySettings.Instance.ON_Addonmessage = this.ON_Addon.Checked; }

        private void ON_Filtering_CheckedChanged(object sender) { MySettings.Instance.CheckTriggerList = this.ON_Filtering.Checked; }
    }
}