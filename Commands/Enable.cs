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

        public string Description { get; } = "Enables the gamemode for the next round.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(sender, "amgus.enable"))
            {
                response = "You do not have permission to begin the event round.";
                return false;
            }
            if (API.API.Running)
            {
                response = "The round is already started.";
                return false;
            }
            API.API.StartRound();
            response = $"Starting Among Us Event Round, Made by {AmongUs.Singleton.Author}";
            return true;
        }
    }
}