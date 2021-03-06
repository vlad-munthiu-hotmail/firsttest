﻿using System;
using System.Configuration;

namespace TestVeracode
{
    class Program
    {
        static void Main(string[] args)
        {
            var mytest = new MyDisposableClass();
            mytest.DoSomething();
            int i = 2;
        }
    }

    public class MyDisposableClass : IDisposable
    {
        private int _calls = 1;
        public void DoSomething()
        {
            _calls++;
            var a = new SecondDisposable()
            a.Run();
        }

        private bool _disposed;

        protected virtual void Dispose(bool dispose)
        {
            if (_disposed)
                return;

            if(dispose)
            {
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class SecondDisposable : IDisposable
    {
        private int _calls = 1;
        public void Run()
        {
            _calls++;
        }

        private bool _disposed;

        protected virtual void Dispose(bool dispose)
        {
            if (_disposed)
                return;

            if (dispose)
            {
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
