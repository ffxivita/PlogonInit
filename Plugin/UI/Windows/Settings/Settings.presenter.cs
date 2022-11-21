using System;
using System.IO;
using CheapLoc;
using Dalamud.Interface.ImGuiFileDialog;
using Dalamud.Interface.Internal.Notifications;
using Plugin.Base;

namespace Plugin.UI.Windows.Settings
{
    public sealed class SettingsPresenter : IDisposable
    {
        public void Dispose() { }

#if DEBUG
        internal FileDialogManager DialogManager = new();

        /// <summary>
        ///     Handles the directory select event and saves the location to that directory.
        /// </summary>
        public static void OnDirectoryPicked(bool success, string path)
        {
            if (!success)
            {
                return;
            }

            var directory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory(path);
            Loc.ExportLocalizable();
            File.Copy(Path.Combine(path, "Plugin_Localizable.json"), Path.Combine(path, "en.json"), true);
            Directory.SetCurrentDirectory(directory);
            PluginService.PluginInterface.UiBuilder.AddNotification("Localization exported successfully.", PluginConstants.PluginName, NotificationType.Success);
        }
#endif
    }
}
