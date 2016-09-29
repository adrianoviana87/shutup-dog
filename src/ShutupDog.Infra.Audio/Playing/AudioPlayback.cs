using System;
using ShutupDog.Domain.Playing;

namespace ShutupDog.Infra.Audio.Playing
{
    public class AudioPlayback : IAudioPlayback
    {
        private NAudio.Wave.WaveOutEvent m_waveOut;

        public AudioPlayback(string fileName)
        {
            m_waveOut = new NAudio.Wave.WaveOutEvent();
            m_waveOut.PlaybackStopped += PlaybackStopped;
            var provider = new NAudio.Wave.WaveFileReader(fileName);
            m_waveOut.Init(provider);
            m_waveOut.Play();
        }
        
        public DateTime? FinishedAt { get; private set; }

        public void Dispose()
        {
            if (m_waveOut != null)
            {
                if (!FinishedAt.HasValue)
                {
                    m_waveOut.Stop();
                }

                m_waveOut.Dispose();
                m_waveOut = null;
            }
        }

        private void PlaybackStopped(object sender, NAudio.Wave.StoppedEventArgs e)
        {
            FinishedAt = DateTime.Now;
            Dispose();
        }
    }
}