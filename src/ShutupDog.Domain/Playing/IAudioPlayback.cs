using System;

namespace ShutupDog.Domain.Playing
{
    public interface IAudioPlayback
    {
        DateTime? FinishedAt { get; }        
    }
}