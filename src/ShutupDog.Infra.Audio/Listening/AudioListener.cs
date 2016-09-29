using System;
using NAudio.Wave;
using ShutupDog.Domain.Listening;

namespace ShutupDog.Infra.Audio.Listening
{
    public class AudioListener : IAudioListener
    {
        private WaveIn m_source;

        public AudioListener()
        {
            m_source = new WaveIn();
            m_source.DeviceNumber = 0;
            m_source.WaveFormat = new WaveFormat();
            m_source.DataAvailable += SourceStreamDataAvailable;
        }
        
        public double Threshold { get; set; }

        public void StartListening()
        {
            m_source.StartRecording();
        }

        public void StopListening()
        {
            m_source.StopRecording();
        }

        public event EventHandler<ThresholdReachedEventArgs> ThresholdReached;

        public void Dispose()
        {
            if (m_source != null)
            {
                m_source.DataAvailable -= SourceStreamDataAvailable;
                m_source.Dispose();
                m_source = null;
            }
        }

        private void SourceStreamDataAvailable(object sender, WaveInEventArgs e)
        {
            
        }
    }
}