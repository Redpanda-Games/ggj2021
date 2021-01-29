using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decisions/InspectClue")]
internal sealed class InspectClueDecision : Decision
{
    internal override bool Decide(StateController controller)
    {
        if (controller.hunter.Clues.Count > 0)
            return true;
        else
            return false;
    }
}