using System;

namespace ShutupDog.Domain.Playing
{
    public interface IAudioPlayer : IDisposable
    {
        IAudioPlayback PlayRandomAudio();
    }
}