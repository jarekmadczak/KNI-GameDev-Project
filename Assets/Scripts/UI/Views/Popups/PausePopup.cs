using Architecture.Common;
using Architecture.Common.Signals;
using Architecture.Common.Systems;
using Architecture.UI.Enums;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.UI
{
    [DisallowMultipleComponent]
    class PausePopup : AbstractPopup
    {
        [SerializeField]
        Button _resumeButton;

        [SerializeField]
        Button _exitToMainMenuButton;
        PausePopup() : base(PopupType.Pause) { }

        internal override void Initialize()
        {
            base.Initialize();
            _resumeButton.onClick.AddListener(ResumeAction);
            _exitToMainMenuButton.onClick.AddListener(ExitToMainMenuAction);
        }
        void ResumeAction()
        {
            this.Close();
        }
        void ExitToMainMenuAction()
        {
            SignalProcessor.SendSignal(new ChangeGameStateSignal(GameState.MainMenu));
        }
    }
}