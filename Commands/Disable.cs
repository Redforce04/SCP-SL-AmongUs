﻿using CommandSystem;
using System;
using Exiled.Permissions.Extensions;

namespace AmongUs.Commands
{
    /// <summary>
    /// Subcommand that disables the among us gamemode from starting, if it hasn't already started.
    /// </summary>
    class Disable : ICommand
    {
        public string Command { get; } = "disable";

        public string[] Aliases { get; } = { "dis" };

        public string Description { get; } = "Disables the among us gamemode";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(sender, "amgus.stop"))
            {
                response = "You do not have permission to stop the event round.";
                return false;
            }
            if (!API.API.Running)
            {
                response = "The round has not been started, or has been stopped.";
                return false;
            }
            API.API.StopRound();
            response = $"Stopping Among Us Event Round, Made by {AmongUs.Singleton.Author}";
            return true;
        }
    }
}