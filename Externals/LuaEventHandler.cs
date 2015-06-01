//  Author: Moreno Sint Hill alias Mirabis
// Created on: 01/06/2015 23:02
// Last Edited on:  01/06/2015 23:04
// File: PushHub.PushHub.LuaEventHandler.cs
// Copyright:  2015, Moreno Sint Hill - All rights reserved.
//  
// ALL CONTENTS IN THIS PROJECT ARE PROTECTED BY COPYRIGHT. EXCEPT AS SPECIFICALLY PERMITTED HEREIN, 
// NO PORTION OF THE INFORMATION IN THIS PROJECT MAY BE REPRODUCED IN ANY FORM, OR BY ANY MEANS, WITHOUT PRIOR WRITTEN PERMISSION FROM Mirabis <info@mirabis.nl>. 
// IT IS NOT PERMITTED TO MODIFY, DISTRIBUTE, PUBLISH, TRANSMIT OR CREATE DERIVATIVE WORKS OF ANY MATERIAL FOUND IN THIS PROJECT FOR ANY PUBLIC OR COMMERCIAL PURPOSES.

#region Usings

using System.Collections.Generic;
using System.Reflection;
using PushHub.Externals;
using Styx.WoWInternals;

#endregion

namespace BuddyPush.Externals
{
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
    }
}