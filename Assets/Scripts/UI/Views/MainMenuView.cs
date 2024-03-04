using Architecture.Common;
using Architecture.Common.Signals;
using Architecture.Common.Systems;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.UI.Views
{
    class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        Button _startButton;

        [SerializeField]
        Button _loadButton;

        [SerializeField]
        Button _settingsButton;

        [SerializeField]
        Button _exitButton;
        void Awake()
        {
            _startButton.onClick.AddListener(StartAction);
            _loadButton.onClick.AddListener(LoadAction);
            _settingsButton.onClick.AddListener(SettingsAction);
            _exitButton.onClick.AddListener(ExitAction);
        }

        static void StartAction() => SignalProcessor.SendSignal(new ChangeGameStateSignal(GameState.Gameplay));

        static void LoadAction() { }

        static void SettingsAction() { }

        static void ExitAction() => SignalProcessor.SendSignal(new ChangeGameStateSignal(GameState.Exit));
    }
}
