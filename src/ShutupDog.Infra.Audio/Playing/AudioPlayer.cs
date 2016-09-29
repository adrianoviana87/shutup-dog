using System.Linq;
using ShutupDog.Domain.Playing;

namespace ShutupDog.Infra.Audio.Playing
{
    public class AudioPlayer : IAudioPlayer
    {
        private readonly IAudioFileRepository m_audioFileRepository;

        public AudioPlayer(IAudioFileRepository audioFileRepository)
        {
            m_audioFileRepository = audioFileRepository;                        
        }
        
        public IAudioPlayback PlayRandomAudio()
        {
            var audioFile = GetRandomAudioFile();
            return new AudioPlayback(audioFile);
        }        

        private string GetRandomAudioFile()
        {
            var files = m_audioFileRepository.ListAllFiles().ToArray();
            return files[0];
        }
    }
}