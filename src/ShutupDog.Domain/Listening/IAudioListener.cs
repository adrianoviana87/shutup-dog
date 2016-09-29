using System;

namespace ShutupDog.Domain.Listening
{
    public interface IAudioListener : IDisposable
    {
        double Threshold { get; set; }

        void StartListening();

        void StopListening();

        event EventHandler<ThresholdReachedEventArgs> ThresholdReached;
    }
}
