using CommandSystem;
using System;

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
            throw new NotImplementedException();
        }
    }
}