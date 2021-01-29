using UnityEngine;

[CreateAssetMenu(menuName = "AI/States/Inspect")]
internal sealed class InspectState : State
{
    internal override void Action(StateController controller)
    {
        controller.hunter.InspectClue();
    }
}