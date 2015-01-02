#region License

// Author: Moreno Sint Hill alias Mirabis
// Created on: 23/08/2014                
// Last Edited on: 22/11/2014
// Project: Greedy
// File: LuaEventHandler.cs
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
    using System.Collections.Generic;
    using System.Reflection;

    using PushHub.Externals;

    using Styx.WoWInternals;

    /// <summary>
    ///     Wrapper for Lua.Event.Attach/Detach
    /// </summary>
    internal class LuaEventHandler
    {
        #region Static Fields

        /// <summary>
        ///     Dictionary of our EventHandlers
        /// </summary>
        private static readonly Dictionary<string, List<LuaEventHandlerDelegate>> EventHandlers = new Dictionary<string, List<LuaEventHandlerDelegate>>();

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Registers the EventHandlers
        /// </summary>
        /// <param name="eventname">Eventname we are registering too</param>
        /// <param name="handler">Handler to call on an event</param>
        /// <param name="log"></param>
        public static void Register(string eventname, LuaEventHandlerDelegate handler, bool log = true)
        {
            try
            {
                List<LuaEventHandlerDelegate> handlers;
                if (!EventHandlers.TryGetValue(eventname, out handlers))
                {
                    EventHandlers.Add(eventname, new List<LuaEventHandlerDelegate> { handler });
                    Lua.Events.AttachEvent(eventname, handler);
                    if (log) Logger.NormalLog("LuaEventHandler: Attaching {0} to {1}", handler.GetMethodInfo().Name, eventname);
                }
                else
                {
                    handlers.Add(handler);
                    Lua.Events.AttachEvent(eventname, handler);
                    if (log) Logger.NormalLog("LuaEventHandler: Attaching {0} to {1}", handler.GetMethodInfo().Name, eventname);
                }
            }
                // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // Root.HandleException(ex);
            }
        }

        /// <summary>
        ///     unregistered the EventHandlers
        /// </summary>
        /// <param name="eventname">Eventname we are detaching from</param>
        /// <param name="handler">Handler to remove from event</param>
        /// <param name="log"></param>
        /// &gt;
        public static void UnRegister(string eventname, LuaEventHandlerDelegate handler, bool log = true)
        {
            List<LuaEventHandlerDelegate> handlers;

            if (!EventHandlers.TryGetValue(eventname, out handlers)) return;

            // Remove
            try
            {
                EventHandlers[eventname].Remove(handler);
                Lua.Events.DetachEvent(eventname, handler);
                if (log) Logger.NormalLog("LuaEventHandler: Detaching {0} from {1}", handler.GetMethodInfo().Name, eventname);
            }
                // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // Root.HandleException(ex);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Cleanly exits the LuaEvents by removing all
        /// </summary>
        internal static void Shutdown()
        {
            try
            {
                foreach (var col in EventHandlers)
                {
                    foreach (var handler in col.Value)
                    {
                        Lua.Events.DetachEvent(col.Key, handler);
                        col.Value.Remove(handler);
                    }
                }
            }
                // ReSharper disable once EmptyGeneralCatchClause
            catch
            {
                // Greedy.HandleException(ex);
            }
        }

        #endregion
    }
}