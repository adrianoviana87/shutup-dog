using System;
using NAudio.Wave;
using ShutupDog.Domain.Listening;

namespace ShutupDog.Infra.Audio.Listening
{
    public class AudioListener : IAudioListener
    {
        private WaveInEvent m_source;

        public AudioListener()
        {
            m_source = new WaveInEvent();
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

        protected void OnThresholdReached(double decibel)
        {
            ThresholdReached?.Invoke(this, new ThresholdReachedEventArgs(decibel));
        }

        private void SourceStreamDataAvailable(object sender, WaveInEventArgs e)
        {
            double sum = 0;
            for (var i = 0; i < e.BytesRecorded; i = i + 2)
            {
                double sample = BitConverter.ToInt16(e.Buffer, i) / 32768.0;
                sum += (sample * sample);
            }
            double rms = Math.Sqrt(sum / (e.BytesRecorded / 2));
            var decibel = 20 * Math.Log10(rms);
            if (decibel >= Threshold)
            {
                OnThresholdReached(decibel);
            }
        }
    }
}