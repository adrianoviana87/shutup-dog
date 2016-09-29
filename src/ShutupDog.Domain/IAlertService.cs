using System;

namespace ShutupDog.Domain
{
    public interface IAlertService : IDisposable
    {
        void Start();
        void Stop();
    }
}