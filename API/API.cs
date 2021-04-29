using Exiled.API.Extensions;
using Exiled.API.Features;
using System;
using System.Collections.Generic;

namespace AmongUs.API
{
    [Obsolete("Need to migrate to new API.")]
    /// <summary>
    /// The Main API
    /// </summary>
    public static class API
    {
        [Obsolete("Need to migrate to new API.")]
        public static Dictionary<string, PlayerInfo> ImposterList = new Dictionary<string, PlayerInfo>();
        [Obsolete("Need to migrate to new API.")]
        public static bool Running = false;
        [Obsolete("Need to migrate to new API.")]
        public static void StartRound()
        {

        }
        [Obsolete("Need to migrate to new API.")]
        public static void StopRound()
        {

        }
        [Obsolete("Need to migrate to new API.")]
        public static void SetImposter(this Player ply)
        {
            PlayerInfo plyinfo = new PlayerInfo
            {
                UserId = ply.UserId,
                Role = AURole.Imposter
            };
            // Server thinks imposters are still class d
            // Send client fake syncvar to make themself a chaos insurgency
            MirrorExtensions.SendFakeSyncVar(ply, ply.ReferenceHub.networkIdentity, typeof(CharacterClassManager), nameof(CharacterClassManager.NetworkCurClass), (sbyte)RoleType.ChaosInsurgency);
            

            foreach (PlayerInfo imposterinfo in ImposterList.Values)
            {
                // Make new imposter see current imposters
                MirrorExtensions.SendFakeSyncVar(ply, imposterinfo.Player.ReferenceHub.networkIdentity, typeof(CharacterClassManager), nameof(CharacterClassManager.NetworkCurClass), (sbyte)RoleType.ChaosInsurgency);
                imposterinfo.Player.SetPlayerInfoForTargetOnly(ply, "<color=red>Imposter</color>");

                // Make current inmposters see new imposter
                MirrorExtensions.SendFakeSyncVar(imposterinfo.Player, ply.ReferenceHub.networkIdentity, typeof(CharacterClassManager), nameof(CharacterClassManager.NetworkCurClass), (sbyte)RoleType.ChaosInsurgency);
                ply.SetPlayerInfoForTargetOnly(imposterinfo.Player, "<color=red>Imposter</color>");
            }
            // Add to imposter list after appearences have been changed, to prevent from sending fake syncvar to self
            if (ImposterList.ContainsKey(ply.UserId))
                ImposterList[ply.UserId] = plyinfo;
            else
                ImposterList.Add(ply.UserId, plyinfo);
        }
        [Obsolete("Need to migrate to new API.")]
        public static void TryRemoveImposter(this Player ply) => ImposterList.Remove(ply.UserId);
        [Obsolete("Need to migrate to new API.")]
        public static bool IsImposter(this Player ply) => ImposterList.ContainsKey(ply.UserId) && (ImposterList[ply.UserId].Role == AURole.Imposter);
    }
}
