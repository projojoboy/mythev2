using UnityEngine;

public abstract class State : MonoBehaviour
{
    public virtual void StateEnter() { }
    public virtual void StateLeave() { }
    public abstract bool Reason();
    public abstract void StateUpdate();
}
