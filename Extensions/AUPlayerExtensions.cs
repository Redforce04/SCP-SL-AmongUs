using AmongUs.API;
using System.Collections.Generic;

namespace AmongUs.Extensions
{
    public static class AUPlayerExtensions
    {
        public static List<AUPlayer> GetCrewmates(this List<AUPlayer> list)
        {
            List<AUPlayer> retlist = new List<AUPlayer>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Role == AURole.Crewmate)
                {
                    retlist.Add(list[i]);
                }
            }

            return retlist;
        }

        public static List<AUPlayer> GetImposters(this List<AUPlayer> list)
        {
            List<AUPlayer> retlist = new List<AUPlayer>();

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Role == AURole.Imposter)
                {
                    retlist.Add(list[i]);
                }
            }

            return retlist;
        }

        public static int GetCrewmatesCount(this List<AUPlayer> list)
        {
            int retint = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Role == AURole.Crewmate)
                {
                    retint += 1;
                }
            }

            return retint;
        }

        public static int GetImpostersCount(this List<AUPlayer> list)
        {
            int retint = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Role == AURole.Imposter)
                {
                    retint += 1;
                }
            }

            return retint;
        }
    }
}
