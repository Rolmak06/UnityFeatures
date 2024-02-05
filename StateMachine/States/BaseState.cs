/// <summary>
/// Base state of the state machine framework.
/// </summary>
public abstract class BaseState 
{
    
    /// <summary>
    /// Enter is called when entering in this new state
    /// </summary>
    public abstract void Enter();

   
    /// <summary>
    /// Tick is called every frame as long as this state exists
    /// </summary>
    public abstract void Tick(float deltaTime);

 
    /// <summary>
    /// Exit is called when exiting this state
    /// </summary>
    public abstract void Exit();
}
