using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.Events.EventArgs;
using AmongUs.API;

namespace AmongUs.Handlers
{
    public class Player
    {
        public void OnKill(DyingEventArgs ev)
        {
            if (!ev.Killer.IsImposter())
                ev.IsAllowed = false;
            //Todo: Check if imposters are still alive.

        }
    }
}
