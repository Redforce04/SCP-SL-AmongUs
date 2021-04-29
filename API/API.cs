using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Extensions;

namespace AmongUs.API
{
    /// <summary>
    /// The Main API
    /// </summary>
    public static class API
    {
        public static Dictionary<string, PlayerInfo> ImposterList = new Dictionary<string, PlayerInfo>();
        public static bool Running = false;
        public static void StartRound()
        {

        }
        public static void StopRound()
        {

        }
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
        public static void TryRemoveImposter(this Player ply) => ImposterList.Remove(ply.UserId);
        public static bool IsImposter(this Player ply) => ImposterList.ContainsKey(ply.UserId) && (ImposterList[ply.UserId].Role == AURole.Imposter);
    }
}
