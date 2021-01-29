using UnityEngine;

internal class StateController : MonoBehaviour
{
    [SerializeField] internal Hunter hunter;
    [SerializeField] internal Decision[] decisions;
    [Space(20)] [SerializeField] private State defaultState;
    private State _activeState;

    private void Update()
    {
        UpdateState(this);
        _activeState.Action(this);
    }

    public void UpdateState(StateController controller)
    {
        for (int i = 0; i < decisions.Length; i++)
        {
            bool hasSucceeded = decisions[i].Decide(controller);

            if (hasSucceeded)
                _activeState = decisions[i].TrueState;
            else
                _activeState = decisions[i].FalseState;
        }
    }
}