using Exiled.API.Enums;
using Exiled.API.Features;
using System;

namespace AmongUs
{
    /// <summary>
    /// Main plugin class. Derives from the Exiled <see cref="Plugin{TConfig}"/> abstract class.
    /// </summary>
    public class AmongUs : Plugin<Config>
    {
        public override string Author => "Redforce04";
        public override string Name => "AmongUs";
        public override string Prefix => "among_us";
        public override PluginPriority Priority => PluginPriority.Default;
        public override Version RequiredExiledVersion => new Version(2, 10, 0);
        public override Version Version => new Version(1, 0, 0);

        public static AmongUs Singleton { get; private set; }

        public override void OnEnabled()
        {
            Singleton = this;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Singleton = null;

            base.OnDisabled();
        }
    }
}