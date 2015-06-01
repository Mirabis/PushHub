//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.Logger.cs
// Copyright:  2015, Moreno Sint Hill - All rights reserved.
//  
// ALL CONTENTS IN THIS PROJECT ARE PROTECTED BY COPYRIGHT. EXCEPT AS SPECIFICALLY PERMITTED HEREIN, 
// NO PORTION OF THE INFORMATION IN THIS PROJECT MAY BE REPRODUCED IN ANY FORM, OR BY ANY MEANS, WITHOUT PRIOR WRITTEN PERMISSION FROM Mirabis <info@mirabis.nl>. 
// IT IS NOT PERMITTED TO MODIFY, DISTRIBUTE, PUBLISH, TRANSMIT OR CREATE DERIVATIVE WORKS OF ANY MATERIAL FOUND IN THIS PROJECT FOR ANY PUBLIC OR COMMERCIAL PURPOSES.

#region Usings

using System;
using System.Windows.Media;
using JetBrains.Annotations;
using Styx.Common;

#endregion

namespace PushHub.Externals
{
    internal static class Logger
    {
        [StringFormatMethod("message")]
        internal static void FailLog(string message, params object[] args) { Output(LogLevel.Normal, Colors.DarkOrange, message, args); }

        private static void Output(LogLevel normal, Color darkOrange, string message, object[] args) { Logging.Write(normal, darkOrange, message, args); }

        [StringFormatMethod("message")]
        internal static void NormalLog(string message, params object[] args) { Output(LogLevel.Normal, Colors.White, message, args); }

        internal static String Truncate(this String input, int maxLength) { return input.Length > maxLength ? input.Substring(0, maxLength) : input; }
    }
}