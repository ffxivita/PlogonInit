using CheapLoc;
using Plugin.Base;

namespace Plugin.Localization
{
    /// <summary>
    ///     A collection of translatable command help strings.
    /// </summary>
    internal sealed class TCommandHelp
    {
        public static string ExampleHelp => Loc.Localize("ExampleHelp", "This is an example help string.");
    }
    /// <summary>
    ///     A collection of translatable window strings.
    /// </summary>
    internal sealed class TWindowNames
    {
        public static string Settings => string.Format(Loc.Localize("Window.Settings", "{0} - Settings"), PluginConstants.PluginName);
    }
}
