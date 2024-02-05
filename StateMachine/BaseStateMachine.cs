using UnityEngine;

public abstract class BaseStateMachine : MonoBehaviour
{
    protected BaseState currentState;
    
    // Update is called once per frame
    void Update()
    {
        //Calls the tick state method every frame 
        currentState?.Tick(Time.deltaTime);
    }

    public void SwitchState(BaseState newState)
    {
            currentState?.Exit();
            currentState = newState;
            currentState?.Enter();
    }
}
