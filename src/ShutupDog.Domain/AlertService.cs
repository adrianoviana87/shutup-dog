using ShutupDog.Domain.Listening;
using ShutupDog.Domain.Playing;

namespace ShutupDog.Domain
{
    /// <summary>
    /// Application logic to play alerts when audio reaches a certain threshold.
    /// </summary>
    public class AlertService : IAlertService
    {
        private readonly IAudioListener m_audioListener;
        private readonly IAudioPlayer m_audioPlayer;
        private IAudioPlayback m_currentPlayingAudio;
        
        
        public AlertService(double threshold, IAudioListener audioListener, IAudioPlayer audioPlayer)
        {
            m_audioListener = audioListener;
            m_audioPlayer = audioPlayer;
            m_audioListener.Threshold = threshold;
            m_audioListener.ThresholdReached += ThresholdReached;
        }
        
        public void Start()
        {
            m_audioListener.StartListening();
        }

        public void Stop()
        {
            m_audioListener.StopListening();
        }

        private void ThresholdReached(object sender, ThresholdReachedEventArgs e)
        {
            if (m_currentPlayingAudio == null || (m_currentPlayingAudio != null && m_currentPlayingAudio.FinishedAt.HasValue))
            {
                m_currentPlayingAudio = m_audioPlayer.PlayRandomAudio();
            }
        }

        public void Dispose()
        {            
            m_audioListener?.Dispose();
            m_currentPlayingAudio?.Dispose();
        }
    }
}