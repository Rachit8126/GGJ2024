using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Event Bus", menuName = "Assets/EventBus")]
public class EventsSo : ScriptableObject
{
    public event Action<int> OnPlayerMove;
    public event Action OnPlayerDie;

    public void InvokePlayerDeath()
    {
        OnPlayerDie?.Invoke();
    }

    public void InvokeOnPlayerMove(int direction)
    {
        OnPlayerMove?.Invoke(direction);
    }
}
