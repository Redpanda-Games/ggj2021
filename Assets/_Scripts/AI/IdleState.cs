using UnityEngine;

[CreateAssetMenu(menuName = "AI/States/Idle")]
internal sealed class IdleState : State
{
    private float _timer;
    
    internal override void Action(StateController controller)
    {
        //controller.hunter.WanderAround();
    }
}