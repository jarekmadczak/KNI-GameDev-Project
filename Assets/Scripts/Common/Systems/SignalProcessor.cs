using System.Collections.Generic;

namespace Architecture.Common.Systems
{
    public static class SignalProcessor
    {
        public static List<AbstractSignal> Signals = new List<AbstractSignal>();
        public static void SendSignal(AbstractSignal signal) => Signals.Add(signal);
    }
}
