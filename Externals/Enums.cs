//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.Enums.cs
// Copyright:  2015, Moreno Sint Hill - All rights reserved.
//  
// ALL CONTENTS IN THIS PROJECT ARE PROTECTED BY COPYRIGHT. EXCEPT AS SPECIFICALLY PERMITTED HEREIN, 
// NO PORTION OF THE INFORMATION IN THIS PROJECT MAY BE REPRODUCED IN ANY FORM, OR BY ANY MEANS, WITHOUT PRIOR WRITTEN PERMISSION FROM Mirabis <info@mirabis.nl>. 
// IT IS NOT PERMITTED TO MODIFY, DISTRIBUTE, PUBLISH, TRANSMIT OR CREATE DERIVATIVE WORKS OF ANY MATERIAL FOUND IN THIS PROJECT FOR ANY PUBLIC OR COMMERCIAL PURPOSES.
namespace PushHub.Externals
{
    internal enum ChatTypes
    {
        Raid,

        Party,

        Guild,

        Officer,

        Battleground,

        Say,

        Whisper,

        BattleNet,

        Dummy,

        Channel
    }

    /// <summary>
    ///     Enum BoxCarSound
    /// </summary>
    public enum BoxCarSound
    {
        /// <summary>
        ///     The no_sound
        /// </summary>
        no_sound,

        /// <summary>
        ///     The beep_crisp
        /// </summary>
        beep_crisp,

        /// <summary>
        ///     The beep_soft
        /// </summary>
        beep_soft,

        /// <summary>
        ///     The bell_modern
        /// </summary>
        bell_modern,

        /// <summary>
        ///     The bell_one_tone
        /// </summary>
        bell_one_tone,

        /// <summary>
        ///     The bell_simple
        /// </summary>
        bell_simple,

        /// <summary>
        ///     The bell_triple
        /// </summary>
        bell_triple,

        /// <summary>
        ///     The bird_1
        /// </summary>
        bird_1,

        /// <summary>
        ///     The bird_2
        /// </summary>
        bird_2,

        /// <summary>
        ///     The boing
        /// </summary>
        boing,

        /// <summary>
        ///     The cash
        /// </summary>
        cash,

        /// <summary>
        ///     The clanging
        /// </summary>
        clanging,

        /// <summary>
        ///     The detonator_charge
        /// </summary>
        detonator_charge,

        /// <summary>
        ///     The digital_alarm
        /// </summary>
        digital_alarm,

        /// <summary>
        ///     The done
        /// </summary>
        done,

        /// <summary>
        ///     The echo
        /// </summary>
        echo,

        /// <summary>
        ///     The flourish
        /// </summary>
        flourish,

        /// <summary>
        ///     The harp
        /// </summary>
        harp,

        /// <summary>
        ///     The light
        /// </summary>
        light,

        /// <summary>
        ///     The magic_chime
        /// </summary>
        magic_chime,

        /// <summary>
        ///     The magic_coin
        /// </summary>
        magic_coin,

        /// <summary>
        ///     The notifier_1
        /// </summary>
        notifier_1,

        /// <summary>
        ///     The notifier_2
        /// </summary>
        notifier_2,

        /// <summary>
        ///     The notifier_3
        /// </summary>
        notifier_3,

        /// <summary>
        ///     The orchestral_long
        /// </summary>
        orchestral_long,

        /// <summary>
        ///     The orchestral_short
        /// </summary>
        orchestral_short,

        /// <summary>
        ///     The score
        /// </summary>
        score,

        /// <summary>
        ///     The success
        /// </summary>
        success,

        /// <summary>
        ///     Up
        /// </summary>
        up
    }

    /// <summary>
    ///     the name of one of the sounds supported by device clients to override the user's default sound choice
    /// </summary>
    public enum PushoverSound
    {
        /// <summary>
        ///     The pushover
        /// </summary>
        Pushover,

        /// <summary>
        ///     The bike
        /// </summary>
        Bike,

        /// <summary>
        ///     The bugle
        /// </summary>
        Bugle,

        /// <summary>
        ///     The cash register
        /// </summary>
        CashRegister,

        /// <summary>
        ///     The classical
        /// </summary>
        Classical,

        /// <summary>
        ///     The cosmic
        /// </summary>
        Cosmic,

        /// <summary>
        ///     The falling
        /// </summary>
        Falling,

        /// <summary>
        ///     The gamelan
        /// </summary>
        Gamelan,

        /// <summary>
        ///     The incoming
        /// </summary>
        Incoming,

        /// <summary>
        ///     The intermission
        /// </summary>
        Intermission,

        /// <summary>
        ///     The magic
        /// </summary>
        Magic,

        /// <summary>
        ///     The mechanical
        /// </summary>
        Mechanical,

        /// <summary>
        ///     The piano bar
        /// </summary>
        PianoBar,

        /// <summary>
        ///     The siren
        /// </summary>
        Siren,

        /// <summary>
        ///     The space aalarm
        /// </summary>
        SpaceAalarm,

        /// <summary>
        ///     The tug boat
        /// </summary>
        TugBoat,

        /// <summary>
        ///     The none
        /// </summary>
        None
    }

    /// <summary>
    ///     Supports Prowl, NotifyMyAndroid and Pushover
    /// </summary>
    public enum NotificationPriority
    {
        /// <summary>
        ///     The very low
        /// </summary>
        VeryLow = -2,

        /// <summary>
        ///     The moderate
        /// </summary>
        Moderate = -1,

        /// <summary>
        ///     The normal
        /// </summary>
        Normal = 0,

        /// <summary>
        ///     The high
        /// </summary>
        High = 1,

        /// <summary>
        ///     The emergency
        /// </summary>
        Emergency = 2
    }
}