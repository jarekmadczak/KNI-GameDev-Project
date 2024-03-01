using Architecture.Common;
using Architecture.Common.Signals;
using Architecture.Common.Systems;

namespace Architecture.UI.Controllers
{
    static class MainMenuController
    {
        internal static void StartClick() => SignalProcessor.SendSignal(new ChangeGameStateSignal(GameState.Gameplay));

        internal static void LoadClick() {}

        internal static void SettingsClick() {}

        internal static void ExitClick() => SignalProcessor.SendSignal(new ChangeGameStateSignal(GameState.Exit));
    }
}
