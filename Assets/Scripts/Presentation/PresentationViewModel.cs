using Architecture.Common;
using UnityEngine;

namespace Architecture.Presentation
{
    public static class PresentationViewModel
    {
        static SceneReferencesHolder _sceneReferences;
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
    }
}
