namespace Architecture.Boot
{
    internal enum SignalType
    {
        CoreSceneLoaded = 0,
        MenuEntry = 1,
        MenuExit = 2,
        GameplayEntry = 3,
        GameplayExit = 4,
        BattleEntry = 5,
        BattleExit = 6,
        ChangeGameState = 7,
        None = 999,
    }
}