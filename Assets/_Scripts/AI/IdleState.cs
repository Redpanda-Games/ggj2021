using UnityEngine;

[CreateAssetMenu(menuName = "AI/States/Idle")]
internal sealed class IdleState : State
{
    internal override void Action(StateController controller)
    {
        controller.hunter.WanderAround();
    }
}