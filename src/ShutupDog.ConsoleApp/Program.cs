using System;
using ShutupDog.Domain;
using ShutupDog.Infra.Audio.Listening;
using ShutupDog.Infra.Audio.Playing;
using ShutupDog.Infra.Files;
using ShutupDog.Infra.Globalization;

namespace ShutupDog.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var audioFileRepository = new AudioFileRepository();
            var audioListener = new AudioListener();
            var audioPlayer = new AudioPlayer(audioFileRepository);
            audioListener.ThresholdReached += ThresholdReached;
            var alarmService = new AlertService(-30.0, audioListener, audioPlayer);
            alarmService.Start();
            Console.ReadKey();
            alarmService.Dispose();
        }

        private static void ThresholdReached(object sender, Domain.Listening.ThresholdReachedEventArgs e)
        {
            Console.WriteLine(Texts.ThresholdReached, DateTime.Now, e.Decibels);
        }
    }
}
