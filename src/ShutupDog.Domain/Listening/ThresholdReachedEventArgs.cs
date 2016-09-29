using System;

namespace ShutupDog.Domain.Listening
{
    public class ThresholdReachedEventArgs : EventArgs
    {
        public ThresholdReachedEventArgs(double decibels)
        {
            Decibels = decibels;
        }

        public double Decibels { get; private set; }
    }
}