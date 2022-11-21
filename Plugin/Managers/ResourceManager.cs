using System;
using System.IO;
using CheapLoc;
using Dalamud.Logging;
using Plugin.Base;

namespace Plugin.Managers
{
    /// <summary>
    ///     Sets up and manages the plugin's resources and localization.
    /// </summary>
    internal sealed class ResourceManager : IDisposable
    {
        /// <summary>
        ///     Initializes the ResourceManager and associated resources.
        /// </summary>
        internal ResourceManager()
        {
            PluginLog.Debug("ResourceManager(Constructor): Initializing...");

            this.Setup(PluginService.PluginInterface.UiLanguage);
            PluginService.PluginInterface.LanguageChanged += this.Setup;

            PluginLog.Debug("ResourceManager(Constructor): Initialization complete.");
        }

        /// <summary>
        //      Disposes of the ResourceManager and associated resources.
        /// </summary>
        public void Dispose()
        {
            PluginService.PluginInterface.LanguageChanged -= this.Setup;

            PluginLog.Debug("ResourceManager(Dispose): Successfully disposed.");
        }

        /// <summary>
        ///     Sets up the plugin's resources.
        /// </summary>
        private void Setup(string language)
        {
            PluginLog.Information($"ResourceManager(Setup): Setting up resources for language {language}...");

            try
            { Loc.Setup(File.ReadAllText($"{PluginConstants.PluginlocalizationDir}{language}.json")); }
            catch { Loc.SetupWithFallbacks(); }

            PluginLog.Information("ResourceManager(Setup): Resources setup.");
        }
    }
}
