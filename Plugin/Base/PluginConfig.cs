using System;
using Dalamud.Configuration;

namespace Plugin.Base
{
    /// <summary>
    ///     Provides access to and determines the Plugin configuration.
    /// </summary>
    [Serializable]
    internal sealed class Configuration : IPluginConfiguration
    {
        /// <summary>
        ///     The current configuration version, incremented on breaking changes.
        /// </summary>
        public int Version { get; set; }

        /// <summary>
        ///     Saves the current configuration (and any modifications) to the config file.
        /// </summary>
        internal void Save() => PluginService.PluginInterface.SavePluginConfig(this);
    }
}
