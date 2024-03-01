using Architecture.Common.Signals;
using Architecture.Common.Systems;
using System;

namespace Architecture.Boot
{
    static class SignalReceiver
    {
        internal static void ExecuteSignals()
        {
            if (SignalProcessor.Signals.Count == 0)
                return;

            for(int i = 0; i < SignalProcessor.Signals.Count; i++)
            {
                Type type = SignalProcessor.Signals[i].GetType();
                if (type.Equals(typeof(CoreSceneLoadedSignal)))
                    BootView.OnCoreSceneLoad();

                if (type.Equals(typeof(MenuEntrySignal)))
                    BootView.MenuOnEntry();

                if (type.Equals(typeof(MenuExitSignal)))
                    BootView.MenuOnExit();

                if (type.Equals(typeof(GameplayEntrySignal)))
                    BootView.GameplayOnEntry();

            }
            SignalProcessor.Signals.Clear();
        }
    }
}
