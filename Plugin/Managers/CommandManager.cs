using System;
using Dalamud.Game.Command;
using Dalamud.Logging;
using Plugin.Base;
using Plugin.Localization;
using Plugin.UI.Windows.Settings;

namespace Plugin.Managers
{
    /// <summary>
    ///     Initializes and manages all commands and command-events for the plugin.
    /// </summary>
    public sealed class CommandManager : IDisposable
    {
        private const string SampleCommand = "/comando-esempio";

        /// <summary>
        ///     Initializes the CommandManager and its resources.
        /// </summary>
        public CommandManager()
        {
            PluginLog.Debug("CommandManager(Constructor): Initializing...");

            PluginService.Commands.AddHandler(SampleCommand, new CommandInfo(this.OnCommand) { HelpMessage = TCommandHelp.ExampleHelp });

            PluginLog.Debug("CommandManager(Constructor): Initialization complete.");
        }

        /// <summary>
        ///     Dispose of the PluginCommandManager and its resources.
        /// </summary>
        public void Dispose()
        {
            PluginService.Commands.RemoveHandler(SampleCommand);

            PluginLog.Debug("CommandManager(Dispose): Successfully disposed.");
        }

        /// <summary>
        ///     Event handler for when a command is issued by the user.
        /// </summary>
        private void OnCommand(string command, string args)
        {
            var windowSystem = PluginService.WindowManager.WindowSystem;
            switch (command)
            {
                case SampleCommand:
                    if (windowSystem.GetWindow(TWindowNames.Settings) is SettingsWindow settingsWindow)
                    {
                        settingsWindow.IsOpen = !settingsWindow.IsOpen;
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
