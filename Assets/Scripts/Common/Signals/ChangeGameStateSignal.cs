using Architecture.Common.Systems;

namespace Architecture.Common.Signals
{
    public sealed class ChangeGameStateSignal : AbstractSignal
    {
        public ChangeGameStateSignal(GameState state)
        {
            GameStateSystem.CurrentGameState = state;
        }
    }
}