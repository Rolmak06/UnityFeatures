using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Listens for a SO_GameEvent and invokes a UnityEvent in response
/// </summary>
public class GameEventListener : MonoBehaviour
{
    [SerializeField] private SO_GameEvent gameEvent;
    [SerializeField] private UnityEvent onGameEvent;

    private void OnEnable()
    {
        if (gameEvent != null && onGameEvent != null)
            gameEvent.Subscribe(onGameEvent);
    }

    private void OnDisable()
    {
        if (gameEvent != null && onGameEvent != null)
            gameEvent.Unsubscribe(onGameEvent);
    }
}
