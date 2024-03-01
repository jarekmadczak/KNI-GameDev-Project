using Architecture.Common;
using Architecture.Common.Systems;
using Architecture.UI.Controllers;
using Architecture.UI.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Architecture.UI
{
    public static class UIViewModel
    {
        static SceneReferencesHolder _sceneReferences;
        static CameraView _camera; 
        public static void CustomStart() { }

        public static void CusotmUpdate()
        {   
            _camera.UpdateCameraPosition();
        }

        public static void CustomFixedUpdate() { }

        public static void CustomLateUpdate() { }

        public static void MenuOnEntry()
        {
            Button startButton = GameObject.Find("StartButton").GetComponent<Button>();
            Button loadButton = GameObject.Find("LoadButton").GetComponent<Button>();
            Button settingsButton = GameObject.Find("SettingsButton").GetComponent<Button>();
            Button exitButton = GameObject.Find("ExitButton").GetComponent<Button>();

            startButton.onClick.AddListener(() => MainMenuController.StartClick());
            loadButton.onClick.AddListener(() => MainMenuController.LoadClick());
            settingsButton.onClick.AddListener(() => MainMenuController.SettingsClick());
            exitButton.onClick.AddListener(() => MainMenuController.ExitClick());
        }

        public static void MenuOnExit() { }

        public static void GameplayOnEntry()
        {
            _camera.FocusOnGameObject(GameObject.Find("SampleGO"));
        }

        public static void GameplayOnExit() { }

        public static void BattleOnEntry() { }

        public static void BattleOnExit() { }

        public static void OnCoreSceneLoad()
        {
            _sceneReferences = GameObject.Find("SceneReferencesHolder").GetComponent<SceneReferencesHolder>();
            _camera = _sceneReferences.GameplayCamera.GetComponent<CameraView>();
            _camera.Initialize();
            _camera.FocusOnGameObject(_sceneReferences.gameObject);
        }
    }
}