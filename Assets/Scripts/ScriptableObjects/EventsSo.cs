using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event Bus", menuName = "Assets/EventBus")]
public class EventsSo : ScriptableObject
{
    public event Action OnPlayerMove;

    public void InvokeOnPlayerMove()
    {
        OnPlayerMove?.Invoke();
    }
}
