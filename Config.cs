using Exiled.API.Interfaces;
using System.ComponentModel;

namespace AmongUs
{
    /// <summary>
    /// Main plugin config. Derives from the Exiled <see cref="IConfig"/> interface.
    /// </summary>
    public class Config : IConfig
    {
        [Description("Enables the plugin.")]
        public bool IsEnabled { get; set; } = true;
    }
}
