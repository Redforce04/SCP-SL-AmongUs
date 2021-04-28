using CommandSystem;
using System;

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
            throw new NotImplementedException();
        }
    }
}