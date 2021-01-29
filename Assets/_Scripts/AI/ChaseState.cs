using UnityEngine;

[CreateAssetMenu(menuName = "AI/States/Chase")]
internal sealed class ChaseState : State
{
    internal override void Action(StateController controller)
    {
        controller.hunter.ChasePrey();
    }
}