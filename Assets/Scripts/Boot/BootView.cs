using Architecture.Common;
using Architecture.Common.Signals;
using Architecture.Common.Systems;
using Architecture.Presentation;
using Architecture.UI;
using UnityEngine;

namespace Architecture.Boot
{
    class BootView : MonoBehaviour
    {

        static bool _isCoreSceneLoaded;
        void Awake()
        {
            _isCoreSceneLoaded = false;
            DontDestroyOnLoad(this);
            DontDestroyOnLoad(GameObject.Find("EventSystem"));
            Injector.InjectNonMonoBehaviourConfigs();
            SignalProcessor.SendSignal(new ChangeGameStateSignal(GameState.Boot));
        }

        #region Custom MonoBehaviour Methods
        void Start()
        {
            UIViewModel.CustomStart();
            PresentationViewModel.CustomStart();
        }

        void Update()
        {
            SignalReceiver.ExecuteSignals();

            if (!_isCoreSceneLoaded)
                return;

            UIViewModel.CusotmUpdate();
            PresentationViewModel.CusotmUpdate();
        }

        void FixedUpdate()
        {
            if (!_isCoreSceneLoaded)
                return;

            UIViewModel.CustomFixedUpdate();
            PresentationViewModel.CustomFixedUpdate();
        }

        void LateUpdate()
        {
            if (!_isCoreSceneLoaded)
                return;

            UIViewModel.CustomLateUpdate();
            PresentationViewModel.CustomLateUpdate();
        }
        #endregion
        public static void OnCoreSceneLoad()
        {
            _isCoreSceneLoaded = true;
            UIViewModel.OnCoreSceneLoad();
            PresentationViewModel.OnCoreSceneLoad();
        }
        public static void MenuOnEntry()
        {
            UIViewModel.MenuOnEntry();
            PresentationViewModel.MenuOnEntry();
        }
        public static void MenuOnExit()
        {
            UIViewModel.MenuOnExit();
            PresentationViewModel.MenuOnExit();
        }

        public static void GameplayOnEntry()
        {
            UIViewModel.GameplayOnEntry();
            PresentationViewModel.GameplayOnEntry();
        }

        public static void GameplayOnExit()
        {
            UIViewModel.GameplayOnExit();
            PresentationViewModel.GameplayOnExit();
        }

        public static void BattleOnEntry()
        {
            UIViewModel.BattleOnEntry();
            PresentationViewModel.BattleOnEntry();
        }

        public static void BattleOnExit()
        {
            UIViewModel.BattleOnExit();
            PresentationViewModel.BattleOnExit();
        }
    }
}
