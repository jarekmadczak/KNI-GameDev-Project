using Architecture.Common.Signals;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Common.Systems
{
    public class GameStateSystem
    {
        internal static GameState CurrentGameState
        {
            get => _currentGameState;
            set
            {
                switch (value)
                {
                    case GameState.Boot:
                        var coreSceneLoad = SceneManager.LoadSceneAsync(Constants.CoreScene, LoadSceneMode.Additive);
                        var uiSceneLoad = SceneManager.LoadSceneAsync(Constants.UIScene, LoadSceneMode.Additive);

                        coreSceneLoad.completed += _ =>
                        {
                            SignalProcessor.SendSignal(new CoreSceneLoadedSignal());
                            var bootSceneUnload = SceneManager.UnloadSceneAsync(0);
                            bootSceneUnload.completed += _ => SignalProcessor.SendSignal(new ChangeGameStateSignal(GameState.MainMenu));
                        };
                        break;

                    case GameState.MainMenu:
                        var mainMenuSceneLoad = SceneManager.LoadSceneAsync(Constants.MainMenuScene, LoadSceneMode.Additive);
                        mainMenuSceneLoad.completed += _ => SignalProcessor.SendSignal(new MenuEntrySignal());

                        break;

                    case GameState.Gameplay:

                        var gameplaySceneLoad = SceneManager.LoadSceneAsync(Constants.GameplayScene, LoadSceneMode.Additive);
                        var mainMenuSceneUnload = SceneManager.UnloadSceneAsync(Constants.MainMenuScene);
                        mainMenuSceneUnload.completed += _ => SignalProcessor.SendSignal(new MenuExitSignal());
                        gameplaySceneLoad.completed += _ => SignalProcessor.SendSignal(new GameplayEntrySignal());
                        break;

                    case GameState.Level0:

                        break;

                    case GameState.Exit:
                        //Todo: Save Game
                        Application.Quit();
                        break;

                    default:
                        throw new Exception("Wrong game state value");
                }
                _currentGameState = value;
            }
        }
        static GameState _currentGameState = GameState.Boot;
    }
}
