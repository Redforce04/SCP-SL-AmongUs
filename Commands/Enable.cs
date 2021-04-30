using CommandSystem;
using System;
using Exiled.Permissions.Extensions;

namespace AmongUs.Commands
{
    /// <summary>
    /// Subcommand that enables the among us gamemode for the next round.
    /// </summary>
    class Enable : ICommand
    {
        public string Command { get; } = "enable";

        public string[] Aliases { get; } = { "en" };

        public string Description { get; } = "Enables the gamemode for the next round. (Round restart required)";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("amgus.start"))
            {
                response = "Missing permissions.";
                return false;
            }

            if (AmongUs.Singleton.GamemodeManager.Started)
            {
                response = "The among us gamemode has already started.";
                return false;
            }
            if (AmongUs.Singleton.GamemodeManager.Enabled)
            {
                response = "The among us gamemode is already enabled.";
                return false;
            }
            AmongUs.Singleton.GamemodeManager.EnableGamemode();
            response = "The among us gamemode has been enabled for the next round.";
            return true;

            // Need to migrate to new API!
            //
            //if (!Permissions.CheckPermission(sender, "amgus.enable"))
            //{
            //    response = "You do not have permission to begin the event round.";
            //    return false;
            //}
            //if (API.API.Running)
            //{
            //    response = "The round is already started.";
            //    return false;
            //}
            //API.API.StartRound();
            //response = $"Starting Among Us Event Round, Made by {AmongUs.Singleton.Author}";
            //return true;
        }
    }
}