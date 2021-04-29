using CommandSystem;
using System;
using Exiled.Permissions.Extensions;

namespace AmongUs.Commands
{
    /// <summary>
    /// Subcommand that enables the among us gamemode for the next round.
    /// </summary>
    class List : ICommand
    {
        public string Command { get; } = "list";

        public string[] Aliases { get; } = {  };

        public string Description { get; } = "Lists subcommands for the amongus command.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = $"Usage: amongus (enable/disable/list/setimposter/removeimposter/revive) (player)";
            return true;
        }
    }
}