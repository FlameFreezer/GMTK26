using System;

public class EventBus
{
    public Action onTick;
    public Action<bool> onPause;
}