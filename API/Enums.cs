using Exiled.API.Features;
namespace AmongUs.API
{
    /// <summary>
    /// Specifies the role of a player.
    /// </summary>
    public enum AURole
    {
        None = -1,
        Crewmate,
        Imposter
    }

    /// <summary>
    /// Main imposter class for the main imposter dictionary.
    /// </summary>
    public class PlayerInfo
    {
        /// <summary>
        /// The UserId of the player.
        /// This is required, and everything else depends on this.
        /// </summary>
        public string UserId;
        /// <summary>
        /// The Nickname of the player
        /// </summary>
        public string Nickname => Player.Nickname;
        /// <summary>
        /// The <seealso cref="Exiled.API.Features.Player">Exiled Player</seealso> reference of the user.
        /// </summary>
        public Player Player => Player.Get(UserId);
        /// <summary>
        /// The <seealso cref="AURole">Among Us Role</seealso> of the user.
        /// </summary>
        public AURole Role;

    }
}