using CommandSystem;
using System;
using Exiled.Permissions.Extensions;
using Exiled.API.Features;
using AmongUs.API;

namespace AmongUs.Commands
{
    /// <summary>
    /// Subcommand that enables the among us gamemode for the next round.
    /// </summary>
    class RemoveImposter : ICommand
    {
        public string Command { get; } = "removeimposter";

        public string[] Aliases { get; } = { "remimp", "rimposter" };

        public string Description { get; } = "Removes a player from the imposter role.";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!Permissions.CheckPermission(sender, "amgus.modify"))
            {
                response = "You do not have permission to modify the event round.";
                return false;
            }
            if(arguments.Count != 1)
            {
                response = "Missing Arguments. Usage: amongus removeimposter (player)";
                return false;
            }
            if(arguments.At(0) == "*")
            {
                foreach(PlayerInfo Imposter in API.API.ImposterList.Values)
                    Imposter.Player.TryRemoveImposter();
                response = "Removed all imposters.";
                return true;
            }
            Player ply = Player.Get(arguments.At(0));
            if(ply is null)
            {
                response = $"Could not find player {arguments.At(0)}. Please try again with the player's username.";
                return false;
            }
            ply.TryRemoveImposter();
            response = $"Removed {ply.Nickname} from Imposter.";
            return true;
        }
    }
}