using System;
using System.Collections.Generic;
using System.Linq;
using Dalamud.Interface.Windowing;
using Dalamud.Logging;
using Plugin.Base;
using Plugin.Localization;
using Plugin.UI.Windows.Settings;

namespace Plugin.Managers
{
    /// <summary>
    ///     Initializes and manages all windows and window-events for the plugin.
    /// </summary>
    internal sealed class WindowManager : IDisposable
    {
        /// <summary>
        ///     The windowing system service provided by Dalamud.
        /// </summary>
        public readonly WindowSystem WindowSystem = new(PluginConstants.PluginName);

        /// <summary>
        ///     All windows managed by the WindowManager.
        /// </summary>
        private readonly List<Window> windows = new()
        {
            new SettingsWindow(),
        };

        /// <summary>
        ///     Initializes the WindowManager and associated resources.
        /// </summary>
        internal WindowManager()
        {
            PluginLog.Debug("WindowManager(Constructor): Initializing...");


            foreach (var window in this.windows)
            {
                PluginLog.Debug($"WindowManager(Constructor): Registering window: {window.GetType().Name}");
                this.WindowSystem.AddWindow(window);
            }

            PluginService.PluginInterface.UiBuilder.Draw += this.OnDrawUI;
            PluginService.PluginInterface.UiBuilder.OpenConfigUi += this.OnOpenConfigUI;
            PluginService.ClientState.Logout += this.OnLogout;

            PluginLog.Debug("WindowManager(Constructor): Successfully initialized.");
        }

        /// <summary>
        ///     Draws all windows for the draw event.
        /// </summary>
        private void OnDrawUI() => this.WindowSystem.Draw();

        /// <summary>
        ///     Opens/Closes the plugin configuration window.
        /// </summary>
        private void OnOpenConfigUI()
        {
            if (this.WindowSystem.GetWindow(TWindowNames.Settings) is SettingsWindow window)
            {
                window.IsOpen = !window.IsOpen;
            }
        }

        /// <summary>
        ///    Handles the OnLogout event.
        /// </summary>
        public void OnLogout(object? e, EventArgs args)
        {
            foreach (var window in this.windows)
            {
                window.IsOpen = false;
            }
        }

        /// <summary>
        ///     Disposes of the WindowManager and associated resources.
        /// </summary>
        public void Dispose()
        {
            PluginService.PluginInterface.UiBuilder.Draw -= this.OnDrawUI;
            PluginService.PluginInterface.UiBuilder.OpenConfigUi -= this.OnOpenConfigUI;

            foreach (var window in this.windows.OfType<IDisposable>())
            {
                PluginLog.Debug($"WindowManager(Dispose): Disposing of {window.GetType().Name}...");
                window.Dispose();
            }

            this.WindowSystem.RemoveAllWindows();

            PluginLog.Debug("WindowManager(Dispose): Successfully disposed.");
        }
    }
}
