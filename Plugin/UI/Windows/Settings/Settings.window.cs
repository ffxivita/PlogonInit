using System;
using System.Numerics;
using Dalamud.Interface.Windowing;
using ImGuiNET;
using Plugin.Localization;

namespace Plugin.UI.Windows.Settings
{
    public sealed class SettingsWindow : Window, IDisposable
    {
        internal SettingsPresenter Presenter;
        public SettingsWindow() : base(TWindowNames.Settings)
        {
            this.Size = new Vector2(400, 400);

            this.Presenter = new SettingsPresenter();
        }
        public void Dispose() => this.Presenter.Dispose();

        public override void Draw()
        {
            ImGui.TextWrapped("Hello, XIVITA Developer!");
            ImGui.TextWrapped("May your project be fruitful and your code be clean.");
        }
    }
}
