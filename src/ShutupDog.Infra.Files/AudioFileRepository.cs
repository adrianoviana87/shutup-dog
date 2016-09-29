using System.Collections.Generic;
using ShutupDog.Domain.Playing;

namespace ShutupDog.Infra.Files
{
    public class AudioFileRepository : IAudioFileRepository
    {
        public IEnumerable<string> ListAllFiles()
        {
            return new[] { @"C:\Windows\Media\Alarm01.wav" };
        }
    }
}
