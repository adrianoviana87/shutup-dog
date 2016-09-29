using System;

namespace ShutupDog.Domain.Playing
{
    public interface IAudioPlayback : IDisposable
    {
        DateTime? FinishedAt { get; }        
    }
}