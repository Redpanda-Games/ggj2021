using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/ChasePrey")]
internal sealed class ChasePreyDecision : Decision
{
    internal override bool Decide(StateController controller)
    {
        return controller.hunter.HasPrey;
    }
}