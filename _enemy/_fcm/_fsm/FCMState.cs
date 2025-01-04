using System;

[Serializable]
public class FCMState
{
    public string Id;
    public FCMAction[] Actions;
    public FCMTransition[] Transitions;

    public void UpdateState(EnemyBrain enemyBrain)
    {
        ExecuteActions();
        ExecuteTransitions(enemyBrain);
    }

    public void ExecuteActions()
    {
        for (int i = 0; i < Actions.Length; i++)
        {
            Actions[i].Act();
        }
    }

    void ExecuteTransitions(EnemyBrain enemyBrain)
    {
        if (Transitions == null || Transitions.Length == 0)
            return;

        for (int i = 0; i < Transitions.Length; i++)
        {
            bool decisionSucceeded = Transitions[i].Decision.Decide();
            if (decisionSucceeded)
                enemyBrain.ChangeState(Transitions[i].TrueState);
            else
                enemyBrain.ChangeState(Transitions[i].FalseState);
        }
    }
}
