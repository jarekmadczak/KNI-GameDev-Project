using Architecture.Ui.Configs;
using Architecture.UI.Enums;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Architecture.UI.Systems
{
    static class InputSystem
    {
        static readonly UIConfig _config;
        internal static InputActionMap MainMenuInputs;
        internal static InputActionMap PopupInputs;
        internal static InputActionMap GameplayInputs;
        internal static InputActionMap BattleInputs;

        static InputActionMap CoreInput;

        const string Popup = "Popup";
        const string MainMenu = "MainMenu";
        const string Gameplay = "Gameplay";
        const string Battle = "Battle";

        const string Exit = "Exit";


        internal static void Initialize()
        {
            MainMenuInputs = _config.InputActionAsset.FindActionMap(MainMenu);
            PopupInputs = _config.InputActionAsset.FindActionMap(Popup);
            GameplayInputs = _config.InputActionAsset.FindActionMap(Gameplay);
            BattleInputs = _config.InputActionAsset.FindActionMap(Battle);
            InitializeMainMenuInputs();
            InitializePopupInputs();
            InitializeGameplayInputs();
            InitializeBattleInputs();
            CoreInput = MainMenuInputs;
        }
        static void InitializeMainMenuInputs()
        {
            MainMenuInputs.FindAction(Exit).performed += _ => Application.Quit();
        }
        static void InitializePopupInputs()
        {
            PopupInputs.FindAction(Exit).performed += _ => PopupSystem.CloseCurrentPopup();
        }
        static void InitializeGameplayInputs()
        {
            GameplayInputs.FindAction(Exit).performed += _ => PopupSystem.ShowPopup(PopupType.Pause);
            GameplayInputs.FindAction("Scroll").performed += move => UIViewModel.MoveCamera(move.ReadValue<Vector2>().normalized);
        }
        static void InitializeBattleInputs()
        {

        }

        internal static void EnableInput(this InputActionMap input)
        {
            if (input.name == MainMenu)
            {
                CoreInput = input;
            }
            else if (input.name == Popup)
            {
                CoreInput.DisableInput();
            }
            else if (input.name == Gameplay)
            {
                CoreInput = input;
            }
            else if (input.name == Battle)
            {
                CoreInput = input;
            }
            else
                throw new Exception("Unexpected input with name " + input.name);

            input.Enable();
        }

        internal static void DisableInput(this InputActionMap input)
        {
            if (input.name == MainMenu)
            {

            }
            else if (input.name == Popup)
            {
                CoreInput.EnableInput();
            }
            else if (input.name == Gameplay)
            {

            }
            else if (input.name == Battle)
            {

            }
            else
                throw new Exception("Unexpected input with name " + input.name);

            input.Disable();
        }

    }
}
