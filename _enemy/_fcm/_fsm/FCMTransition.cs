using System;

[Serializable]
public class FCMTransition
{
    public FCMDecision Decision; //IsPlayerInRangeOfAttack->True or False
    public string TrueState; //CurrentState -> AttackState
    public string FalseState; //CurrentState -> PatrolState
}