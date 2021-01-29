using UnityEngine;

internal abstract class Decision : ScriptableObject
{
    public State TrueState;
    public State FalseState;
    internal abstract bool Decide(StateController controller);
}