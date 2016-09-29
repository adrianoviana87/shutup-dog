using System.Collections.Generic;

namespace ShutupDog.Domain.Playing
{
    public interface IAudioFileRepository
    {
        IEnumerable<string> ListAllFiles();
    }
}