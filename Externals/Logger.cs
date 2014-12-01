#region License
// Author: Moreno Sint Hill alias Mirabis
// Created on: 01/12/2014                
// Last Edited on: 01/12/2014
// Project: BuddyPush
// File: Logger.cs
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
namespace BuddyPush.Externals
{
    using System;
    using System.Windows.Media;

    using JetBrains.Annotations;

    using Styx.Common;

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