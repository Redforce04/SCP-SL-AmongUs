using Exiled.API.Features;
using Handlers = Exiled.Events.Handlers;

namespace AmongUs.API
{
    /// <summary>
    /// <para>
    /// Important API object to attach and detach events for the gamemode, while managing how it enables and disables.
    /// </para>
    /// <i>Note: Modify with caution!</i>
    /// </summary>
    public class GamemodeManager
    {
        /// <summary>
        /// Creates a new <see cref="GamemodeManager"/> object.
        /// </summary>
        internal GamemodeManager() => EventManager = new EventManager();

        /// <summary>
        /// The EventManager used for managing events.
        /// </summary>
        public EventManager EventManager { get; }

        /// <summary>
        /// Specifies if the gamemode is enabled or not. Also specifies if primary events are enabled.
        /// </summary>
        public bool Enabled { get; private set; } = false;
        /// <summary>
        /// Specifies if secondary events are enabled.
        /// </summary>
        public bool SecondaryEventsEnabled { get; private set; } = false;

        /// <summary>
        /// Specifies if the gamemode is waiting for players. Also specifies if player join and leave events are attached.
        /// </summary>
        public bool WaitingForPlayers { get; private set; } = false;
        /// <summary>
        /// Specifies if the gamemode has started.
        /// </summary>
        public bool Started { get; internal set; } = false;

        /// <summary>
        /// Enables or disables the gamemode for the next round.
        /// </summary>
        /// <param name="enable">Specifies whether to enable or disable the gamemode.</param>
        internal void EnableGamemode(bool enable = true) // dont touch
        {
            if (enable)
            {
                if (Enabled) { return; }

                EnablePrimaryEvents();
                
                Enabled = true;
            }
            else
            {
                if (!Enabled) { return; }

                EnablePrimaryEvents(false);

                Reset();
                
                Enabled = false;
            }
        }

        /// <summary>
        /// Enables or disables primary events.
        /// </summary>
        /// <param name="enable">Specifies whether to enable or disable primary events.</param>
        private void EnablePrimaryEvents(bool enable = true) // dont touch
        {
            if (enable)
            {
                Handlers.Server.WaitingForPlayers += EventManager.WaitingForPlayers;
                Handlers.Server.RoundStarted += EventManager.RoundStarted;
                Handlers.Server.RoundEnded += EventManager.RoundEnded;
                Handlers.Server.RestartingRound += EventManager.RestartingRound;
            }
            else
            {
                Handlers.Server.WaitingForPlayers -= EventManager.WaitingForPlayers;
                Handlers.Server.RoundStarted -= EventManager.RoundStarted;
                Handlers.Server.RoundEnded -= EventManager.RoundEnded;
                Handlers.Server.RestartingRound -= EventManager.RestartingRound;
            }
        }

        /// <summary>
        /// Enables or disables secondary events.
        /// </summary>
        /// <param name="enable">Specifies whether to enable or disable secondary events.</param>
        internal void EnableSecondaryEvents(bool enable = true) // dont touch
        {
            if (enable)
            {
                if (SecondaryEventsEnabled) { return; }

                Handlers.Server.RespawningTeam += EventManager.RespawningTeam;
                Handlers.Server.EndingRound += EventManager.EndingRound;

                SecondaryEventsEnabled = true;
            }
            else
            {
                if (!SecondaryEventsEnabled) { return; }

                Handlers.Server.RespawningTeam -= EventManager.RespawningTeam;
                Handlers.Server.EndingRound -= EventManager.EndingRound;

                SecondaryEventsEnabled = false;
            }
        }

        /// <summary>
        /// Toggles <see cref="WaitingForPlayers"/>. Also attaches / dettaches player join and leave events.
        /// </summary>
        /// <param name="enable"></param>
        internal void ToggleWaitingForPlayers(bool enable = true) // dont touch
        {
            if (enable)
            {
                if (WaitingForPlayers) { return; }

                Handlers.Player.Verified += EventManager.Verified;
                Handlers.Player.Destroying += EventManager.Destroying;

                WaitingForPlayers = true;
            }
            else
            {
                if (!WaitingForPlayers) { return; }

                Handlers.Player.Verified -= EventManager.Verified;
                Handlers.Player.Destroying -= EventManager.Destroying;

                AUPlayer.ClearList();

                WaitingForPlayers = false;
            }
        }

        /// <summary>
        /// Called when disabling the gamemode, resets some basic properties.
        /// </summary>
        private void Reset() // dont touch unless API changes.
        {
            Started = false;

            if (SecondaryEventsEnabled)
            {
                EnableSecondaryEvents(false);
            }

            if (WaitingForPlayers)
            {
                ToggleWaitingForPlayers(false);
            }
        }

        //
        // Primary events are events that enable and disable the gamemode,
        // while secondary events are called while the gamemode is active.
        //
        // Make sure you know the difference!
        //

        /// <summary>
        /// Called when the gamemode starts.
        /// </summary>
        internal void StartGamemode()
        {

            Log.Debug("Gamemode started!");
        }
    }
}
