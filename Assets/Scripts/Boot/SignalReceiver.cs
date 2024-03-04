using Architecture.Common;
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

                SignalType type = SignalProcessor.Signals[i].GetSignalType();
                switch (type)
                {
                    case SignalType.CoreSceneLoaded:
                        BootView.OnCoreSceneLoad();
                        break;
                    case SignalType.MenuEntry:
                        BootView.MenuOnEntry();
                        break;
                    case SignalType.MenuExit:
                        BootView.MenuOnExit();
                        break;
                    case SignalType.GameplayEntry:
                        BootView.GameplayOnEntry();
                        break;
                    case SignalType.GameplayExit:
                        BootView.GameplayOnExit();
                        break;
                    case SignalType.BattleEntry:
                        BootView.BattleOnEntry();
                        break;
                    case SignalType.BattleExit:
                        BootView.BattleOnExit();
                        break;
                    case SignalType.ChangeGameState:
                        break;
                    case SignalType.None:
                        throw new Exception("Undefined signal: " + SignalProcessor.Signals[i].GetType() + " please check if your signal return signal type in GetSignalType method in SignalReceiver");
                }
            }
            SignalProcessor.Signals.Clear();
        }

        static SignalType GetSignalType(this AbstractSignal signal)
        {
            Type type = signal.GetType();

            if (type.Equals(typeof(CoreSceneLoadedSignal)))
                return SignalType.CoreSceneLoaded;

            if (type.Equals(typeof(MenuEntrySignal)))
                return SignalType.MenuEntry;

            if (type.Equals(typeof(MenuExitSignal)))
                return SignalType.MenuExit;

            if (type.Equals(typeof(GameplayEntrySignal)))
                return SignalType.GameplayEntry;

            if (type.Equals(typeof(GameplayExitSignal)))
                return SignalType.GameplayExit;

            if(type.Equals(typeof(BattleEntrySignal)))
                return SignalType.BattleEntry;

            if (type.Equals(typeof(BattleExitSignal)))
                return SignalType.BattleExit;

            if(type.Equals(typeof(ChangeGameStateSignal)))
                return SignalType.ChangeGameState;

            return SignalType.None;
        }
    }
}
