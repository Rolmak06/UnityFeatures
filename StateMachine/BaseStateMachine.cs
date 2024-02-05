using UnityEngine;

/// <summary>
/// Base class for the state machine framework.
/// </summary>
public abstract class BaseStateMachine : MonoBehaviour
{
    protected BaseState currentState;
    
    // Update is called once per frame
    void Update()
    {
        //Calls the tick state method every frame 
        currentState?.Tick(Time.deltaTime);
    }

    /// <summary>
    /// Switch the defined state machine to a new state
    /// </summary>
    /// <param name="newState">the newly created state</param>
    public void SwitchState(BaseState newState)
    {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
    }
}
