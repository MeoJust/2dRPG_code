using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public Transform Player { get; set; }

    [SerializeField] string _initStateId;
    [SerializeField] FCMState[] _states;
    public FCMState CurrentState { get; set; }

    void Start()
    {
        ChangeState(_initStateId);
    }

    void Update()
    {
        CurrentState?.UpdateState(this);
    }

    public void ChangeState(string newStateId)
    {
        FCMState newState = GetState(newStateId);
        if (newState != null)
            CurrentState = newState;
    }

    FCMState GetState(string newStateId)
    {
        for (int i = 0; i < _states.Length; i++)
        {
            if (_states[i].Id == newStateId)
                return _states[i];
        }
        return null;
    }

}
