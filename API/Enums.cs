using Exiled.API.Features;
using System;

namespace AmongUs.API
{
    /// <summary>
    /// Specifies the role of a player.
    /// </summary>
    public enum AURole
    {
        /// <summary>
        /// Role is unassigned.
        /// </summary>
        None = -1,
        /// <summary>
        /// Crewmate role.
        /// </summary>
        Crewmate,
        /// <summary>
        /// Imposter role.
        /// </summary>
        Imposter
    }

    [Obsolete("Need to migrate to new API.")]
    /// <summary>
    /// Main imposter class for the main imposter dictionary.
    /// </summary>
    public class PlayerInfo
    {
        [Obsolete("Need to migrate to new API.")]
        /// <summary>
        /// The UserId of the player.
        /// This is required, and everything else depends on this.
        /// </summary>
        public string UserId;
        [Obsolete("Need to migrate to new API.")]
        /// <summary>
        /// The Nickname of the player
        /// </summary>
        public string Nickname => Player.Nickname;
        [Obsolete("Need to migrate to new API.")]
        /// <summary>
        /// The <seealso cref="Exiled.API.Features.Player">Exiled Player</seealso> reference of the user.
        /// </summary>
        public Player Player => Player.Get(UserId);
        [Obsolete("Need to migrate to new API.")]
        /// <summary>
        /// The <seealso cref="AURole">Among Us Role</seealso> of the user.
        /// </summary>
        public AURole Role;

    }
}