using System;

namespace Pharos.MPS.Mobile.Client.MVVM
{
    public interface IDispatchOnUIThread
    {
        void Invoke(Action action);
    }
}
