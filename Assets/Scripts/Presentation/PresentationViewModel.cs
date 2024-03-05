using Architecture.Common;
using Architecture.Common.Signals;
using Architecture.Common.Systems;
using Architecture.Presentation.Data;
using UnityEngine;

namespace Architecture.Presentation
{
    public static class PresentationViewModel
    {
        static SceneReferencesHolder _sceneReferences;
        public static int SelectedLevel;

        public static void CustomStart() { }

        public static void CusotmUpdate() { }

        public static void CustomFixedUpdate() { }

        public static void CustomLateUpdate() { }

        public static void MenuOnEntry() { }

        public static void MenuOnExit() { }

        public static void GameplayOnEntry() { }

        public static void GameplayOnExit() { }

        public static void BattleOnEntry() { }

        public static void BattleOnExit() { }

        public static void OnCoreSceneLoad()
        {
           _sceneReferences = GameObject.Find("SceneReferencesHolder").GetComponent<SceneReferencesHolder>();
        }

        //Todo rework signals system so they can call all function with react attribute
        internal static void LevelClickHandler(LevelData data) => SignalProcessor.SendSignal(new ShowLevelPopupSignal());
    }
}