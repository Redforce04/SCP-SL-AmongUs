using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace AmongUs.API
{
    /// <summary>
    /// EventManager class. Handles all events in the plugin, passing info where needed.
    /// </summary>
    public class EventManager
    {
        // Note: All event handlers should be declared as their exact event name, for clarity.

        /// <summary>
        /// <para>
        /// <b>Primary Event</b>
        /// </para>
        /// <para>
        /// Called when waiting for players.
        /// </para>
        /// <i>Note: Dont touch unless game breaking updates or API changes.</i>
        /// </summary>
        internal void WaitingForPlayers()
        {
            AmongUs.Singleton.GamemodeManager.ToggleWaitingForPlayers(true);
            AmongUs.Singleton.GamemodeManager.EnableSecondaryEvents();
        }

        /// <summary>
        /// <para>
        /// <b>Primary Event</b>
        /// </para>
        /// <para>
        /// Called when round started.
        /// </para>
        /// <i>Note: Dont touch unless game breaking updates or API changes.</i>
        /// </summary>
        internal void RoundStarted()
        {
            if (!AmongUs.Singleton.GamemodeManager.WaitingForPlayers) { return; }

            AmongUs.Singleton.GamemodeManager.Started = true;

            AmongUs.Singleton.GamemodeManager.StartGamemode();
        }

        /// <summary>
        /// <para>
        /// <b>Primary Event</b>
        /// </para>
        /// <para>
        /// Called when round ended.
        /// </para>
        /// <i>Note: Dont touch unless game breaking updates or API changes.</i>
        /// </summary>
        internal void RoundEnded(RoundEndedEventArgs ev)
        {
            if (!AmongUs.Singleton.GamemodeManager.Started) { return; }

            AmongUs.Singleton.GamemodeManager.EnableGamemode(false);
        }

        /// <summary>
        /// <para>
        /// <b>Primary Event</b>
        /// </para>
        /// <para>
        /// Called when restarting the round.
        /// </para>
        /// <i>Note: Dont touch unless game breaking updates or API changes.</i>
        /// </summary>
        internal void RestartingRound()
        {
            if (!AmongUs.Singleton.GamemodeManager.Started) { return; }

            AmongUs.Singleton.GamemodeManager.EnableGamemode(false);
        }


        /// <summary>
        /// Called when player is verified.
        /// </summary>
        /// <param name="ev">Argument passed by Exiled.</param>
        internal void Verified(VerifiedEventArgs ev)
        {
            AUPlayer.List.Add(new AUPlayer(ev.Player).Verified(ev));
            Log.Debug("Added player to list.");
        }

        /// <summary>
        /// Called before a player is destroyed.
        /// </summary>
        /// <param name="ev">Argument passed by Exiled.</param>
        internal void Destroying(DestroyingEventArgs ev)
        {
            AUPlayer.List.Remove(AUPlayer.Get(ev.Player).Destroying(ev));
            Log.Debug("Removed player from list.");
        }
    }
}