namespace Architecture.Common
{
    public enum GameState
    {
        Boot = 0,
        MainMenu = 1,
        Gameplay = 2,
        Battle = 3,
        Exit = 999,
        Undefined = -1,
    }
    public enum PopupType
    {
        Start = 0,
        Load = 1,
        Settings = 2,
        //Placeholder for more settings popups
        Close = 5,
        Pause = 6,
        Level = 7,
    }
    public enum SignalType
    {
        CoreSceneLoaded = 0,
        MenuEntry = 1,
        MenuExit = 2,
        GameplayEntry = 3,
        GameplayExit = 4,
        BattleEntry = 5,
        BattleExit = 6,
        ChangeGameState = 7,
        ShowLevelPopup = 8,
        None = 999,
    }
}