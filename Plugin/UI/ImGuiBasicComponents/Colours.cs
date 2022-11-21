using System.Numerics;
using ImGuiNET;

namespace Plugin.UI.ImGuiBasicComponents
{
    /// <summary>
    ///     Components and constants for colours.
    /// </summary>
    internal static class Colours
    {
        /// <summary>
        ///     Creates a ImGui.TextWrapped() with the given text and colour.
        /// </summary>
        /// <param name="colour"> The colour to show the text in. </param>
        /// <param name="text"> The text to show. </param>
        public static void TextWrappedColoured(Vector4 colour, string text)
        {
            ImGui.PushStyleColor(ImGuiCol.Text, colour);
            ImGui.TextWrapped(text);
            ImGui.PopStyleColor();
        }
    }
}
