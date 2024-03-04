using Architecture.Common.Signals;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Architecture.Common.Systems
{
    public class GameStateSystem
    {
        static AsyncOperation _currentLoad;
        internal static GameState CurrentGameState
        {
            get => _currentGameState;
            set
            {
                if (value == _currentGameState)
                    throw new Exception("Unexpected game state change, cant go from game state: " + _currentGameState + " to " + value);

                //Handle entering game state
                switch (value)
                {
                    case GameState.Boot:
                        _currentLoad = SceneManager.LoadSceneAsync(Constants.CoreScene, LoadSceneMode.Additive);
                        var uiSceneLoad = SceneManager.LoadSceneAsync(Constants.UIScene, LoadSceneMode.Additive);

                        _currentLoad.completed += _ =>
                        {
                            SignalProcessor.SendSignal(new CoreSceneLoadedSignal());
                            SignalProcessor.SendSignal(new ChangeGameStateSignal(GameState.MainMenu));
                        };
                        break;

                    case GameState.MainMenu:
                        var mainMenuSceneLoad = SceneManager.LoadSceneAsync(Constants.MainMenuScene, LoadSceneMode.Additive);
                        mainMenuSceneLoad.completed += _ => SignalProcessor.SendSignal(new MenuEntrySignal());
                        break;

                    case GameState.Gameplay:
                        var gameplaySceneLoad = SceneManager.LoadSceneAsync(Constants.GameplayScene, LoadSceneMode.Additive);
                        gameplaySceneLoad.completed += _ => SignalProcessor.SendSignal(new GameplayEntrySignal());
                        break;

                    case GameState.Battle:
                        var battleSceneLoad = SceneManager.LoadSceneAsync(Constants.BattleScene, LoadSceneMode.Additive);
                        battleSceneLoad.completed += _ => SignalProcessor.SendSignal(new BattleEntrySignal());
                        break;

                    case GameState.Exit:
                        //Todo: Save Game
                        Application.Quit();
                        break;

                    default:
                        throw new Exception("Wrong game state value");
                }

                //Handle exiting game state
                switch (_currentGameState)
                {
                    case GameState.Boot:
                        var bootSceneUnload = SceneManager.UnloadSceneAsync(0);
                        break;
                    case GameState.MainMenu:
                        var mainMenuSceneUnload = SceneManager.UnloadSceneAsync(Constants.MainMenuScene);
                        mainMenuSceneUnload.completed += _ => SignalProcessor.SendSignal(new MenuExitSignal());
                        break;
                    case GameState.Gameplay:
                        var gameplaySceneUnload = SceneManager.UnloadSceneAsync(Constants.GameplayScene);
                        gameplaySceneUnload.completed += _ => SignalProcessor.SendSignal(new GameplayExitSignal());
                        break;
                    case GameState.Battle:
                        var battleSceneUnload = SceneManager.UnloadSceneAsync(Constants.BattleScene);
                        battleSceneUnload.completed += _ => SignalProcessor.SendSignal(new BattleExitSignal());
                        break;
                }
                Injector.InjectMonoBehaviourConfigs();
                _currentGameState = value;
            }
        }
        static GameState _currentGameState = GameState.Undefined;
    }
}