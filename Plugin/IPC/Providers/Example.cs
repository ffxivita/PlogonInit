using Dalamud.Logging;
using Plugin.IPC.Interfaces;

namespace Plugin.IPC.Providers
{
    /// <summary>
    ///     Provider for Example
    /// </summary>
    public sealed class ExampleIPC : IIPCProvider
    {
        public IPCProviders ID { get; } = IPCProviders.Example;

        public void Enable() => PluginLog.Debug("ExampleIPC(Enable): Example IPC provider enabled.");

        public void Dispose() => PluginLog.Debug("ExampleIPC(Dispose): Example IPC provider disposed.");
    }
}
