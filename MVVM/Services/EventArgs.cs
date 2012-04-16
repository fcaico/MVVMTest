using System;

namespace Pharos.MPS.Mobile.Client.MVVM
{
    public class EventArgs<T> : EventArgs
    {
        public T Content { get; private set; }

        public EventArgs(T content)
        {
            Content = content;
        }
    }
}