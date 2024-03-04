using Architecture.Common;
using Architecture.Ui.Configs;
using Architecture.UI.Systems;
using UnityEngine;

namespace Architecture.UI
{
    public static class UIViewModel
    {
        static internal UISceneReferencesHolder UISceneReferencesHolder;
        static internal SceneReferencesHolder SceneReferencesHolder;

        static CameraConfig _cameraConfig;
        static UIConfig _uiConfig;

        public static void CustomStart() { }

        public static void CusotmUpdate() { }

        public static void CustomFixedUpdate() { }

        public static void CustomLateUpdate() { }

        public static void MenuOnEntry()
        {
            SceneReferencesHolder.GameplayCamera.transform.position = _cameraConfig.MainMenuCameraPosition;
            InputSystem.MainMenuInputs.EnableInput();
        }

        public static void MenuOnExit()
        {
            InputSystem.MainMenuInputs.DisableInput();
        }

        public static void GameplayOnEntry()
        {
            SceneReferencesHolder.GameplayCamera.transform.position = _cameraConfig.GameplayCameraPostion;
            InputSystem.GameplayInputs.EnableInput();
        }

        public static void GameplayOnExit()
        {
            InputSystem.GameplayInputs.DisableInput();
        }

        public static void BattleOnEntry()
        {
            SceneReferencesHolder.GameplayCamera.transform.position = _cameraConfig.BattleCameraPosition;
            InputSystem.BattleInputs.EnableInput();
        }

        public static void BattleOnExit()
        { 
            InputSystem.BattleInputs.DisableInput();
        }

        public static void OnCoreSceneLoad()
        {
            UISceneReferencesHolder = Object.FindFirstObjectByType<UISceneReferencesHolder>();
            SceneReferencesHolder = Object.FindFirstObjectByType<SceneReferencesHolder>();
;           InputSystem.Initialize();
        }

        internal static void MoveCamera(Vector2 v)
        {
            Vector3 movement = new Vector3(0, v.y * _cameraConfig.ScrollSensitivity, 0);
            SceneReferencesHolder.GameplayCamera.transform.Translate(movement, Space.World);
        }

        public static void CloseAllPopups()
        {
            if (PopupSystem.CurrentPopup == null)
                return;
            PopupSystem.CurrentPopup.Close();
        } 
    }
}