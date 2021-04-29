using CommandSystem;
using System;

namespace AmongUs.Commands
{
    /// <summary>
    /// Parent command for among us gamemode commands.
    /// </summary>
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    [CommandHandler(typeof(GameConsoleCommandHandler))]
    class AmongUsCmds : ParentCommand
    {
        public AmongUsCmds() => LoadGeneratedCommands();
        public override string Command { get; } = "amongus";

        public override string[] Aliases { get; } = {  };

        public override string Description { get; } = "Parent command for among us gamemode commands.";

        public override void LoadGeneratedCommands()
        {
            RegisterCommand(new Enable());
            RegisterCommand(new Disable());
        }

        protected override bool ExecuteParent(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            response = $"Incorrect usage. Proper command usage: amongus (enable/disable/list/setimposter/removeimposter/revive)";
            return false;
        }
    }
}