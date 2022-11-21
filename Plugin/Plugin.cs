using Dalamud.IoC;
using Dalamud.Plugin;
using Plugin.Base;

namespace Plugin
{
    internal sealed class Plugin : IDalamudPlugin
    {
        /// <summary>
        ///     The plugin name, fetched from PluginConstants.
        /// </summary>
        public string Name => PluginConstants.PluginName;

        /// <summary>
        ///     The plugin's main entry point.
        /// </summary>
        public Plugin([RequiredVersion("1.0")] DalamudPluginInterface pluginInterface)
        {
            pluginInterface.Create<PluginService>();
            PluginService.Initialize();
        }

        public void Dispose() => PluginService.Dispose();
    }
}
