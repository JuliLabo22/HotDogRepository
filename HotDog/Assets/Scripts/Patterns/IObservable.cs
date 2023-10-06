using System.Collections.Generic;

public interface IObservable
{
    void Subscribe(IObserver observer);
    void UnSubscribe(IObserver observer);
    void OnNotify();
}
