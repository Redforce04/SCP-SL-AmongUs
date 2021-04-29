using Exiled.API.Features;
using Exiled.Events.EventArgs;
using System.Collections.Generic;

namespace AmongUs.API
{
    /// <summary>
    /// Custom player class to implement functions, features, and changes regarding players.
    /// </summary>
    public class AUPlayer
    {
        /// <summary>
        /// <para>
        /// Creates a new <see cref="AUPlayer"/> object.
        /// </para>
        /// <i>Note: This is declared as internal to prevent outside issues.</i>
        /// </summary>
        /// <param name="ply">The Exiled player associated with this object.</param>
        internal AUPlayer(Player ply) => Player = ply;

        /// <summary>
        /// The Exiled Player associated with this object.
        /// </summary>
        public Player Player { get; }
        /// <summary>
        /// The players current role.
        /// </summary>
        public AURole Role { get; } = AURole.None;

        /// <summary>
        /// The list of all <see cref="AUPlayer"/> objects.
        /// </summary>
        public static List<AUPlayer> List { get; } = new List<AUPlayer>();

        /// <summary>
        /// Gets a <see cref="AUPlayer"/> object from their assigned <see cref="Exiled.API.Features.Player"/> object.
        /// </summary>
        /// <param name="player">The player to find.</param>
        /// <returns>The <see cref="AUPlayer"/> found, or <see langword="null"/> if not found.</returns>
        public static AUPlayer Get(Player player)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].Player == player)
                {
                    return List[i];
                }
            }

            return null;
        }
        /// <summary>
        /// Gets a <see cref="AUPlayer"/> object from their assigned <see cref="Exiled.API.Features.Player"/> object.
        /// </summary>
        /// <param name="player">The player to find.</param>
        /// <param name="ply">The <see cref="AUPlayer"/> found, or <see langword="null"/> if not found.</param>
        /// <returns><see langword="bool"/> specifying if the <see cref="AUPlayer"/> object was found.</returns>
        public static bool Get(Player player, out AUPlayer ply)
        {
            for (int i = 0; i < List.Count; i++)
            {
                if (List[i].Player == player)
                {
                    ply = List[i];
                    return true;
                }
            }

            ply = null;
            return false;
        }


        /// <summary>
        /// Called as player is verified, before they are added to the list.
        /// </summary>
        /// <returns>The <see cref="AUPlayer"/> instance that called this method.</returns>
        internal AUPlayer Verified(VerifiedEventArgs ev)
        {
            // Do stuff when they join.

            return this;
        }

        /// <summary>
        /// Called before a player is destroyed, before they are removed from list.
        /// </summary>
        /// <returns>The <see cref="AUPlayer"/> instance that called this method.</returns>
        internal AUPlayer Destroying(DestroyingEventArgs ev)
        {
            // Do stuff when they leave.

            return this;
        }

        /// <summary>
        /// Clears the <see cref="AUPlayer"/> list.
        /// </summary>
        internal static void ClearList()
        {
            List.Clear();
        }
    }
}