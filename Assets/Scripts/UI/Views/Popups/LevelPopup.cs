using Architecture.Common;
using Architecture.Common.Signals;
using Architecture.Common.Systems;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.UI
{
    [DisallowMultipleComponent]
    class LevelPopup : AbstractPopup
    {
        LevelPopup() : base(PopupType.Level) { }

        [SerializeField]
        Button _fightButton;

        [SerializeField]
        Button _settingsButton;

        [SerializeField]
        Button _info1Button;

        [SerializeField]
        Button _info2Button;

        [SerializeField]
        TextMeshProUGUI _levelText;

        internal override void Initialize()
        {
            base.Initialize();
            _fightButton.onClick.AddListener(FightAction);
            _settingsButton.onClick.AddListener(SettingsAction);
            _info1Button.onClick.AddListener(Info1Action);
            _info2Button.onClick.AddListener(Info2Action);
            _levelText.text = "Level-"+UIViewModel.SelectedLevel;
        }

        void FightAction()
        {
            SignalProcessor.SendSignal(new ChangeGameStateSignal(GameState.Battle));
        }

        void SettingsAction()
        {

        }

        void Info1Action()
        {

        }

        void Info2Action()
        {

        }
    }
}
