using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    [SerializeField] PlayerStatsSO _stats;

    //TEMP
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExp(50);
            Debug.Log("Player exp: " + _stats.CurrentExp);
            Debug.Log("Player level: " + _stats.Level);
        }
    }

    public void AddExp(float amount)
    {
        _stats.TotalExp += amount;
        _stats.CurrentExp += amount;

        while (_stats.CurrentExp >= _stats.NextLevelExp)
        {
            _stats.CurrentExp -= _stats.NextLevelExp;
            NextLevel();
        }
    }

    void NextLevel()
    {
        _stats.Level++;
        _stats.AtributePoints++;
        //print("attr. points: " + _stats.AtributePoints);
        float expRequired = _stats.NextLevelExp;
        float newNextLevelExp = Mathf.Round(expRequired + _stats.NextLevelExp * (_stats.ExpMultiplier / 100));
        _stats.NextLevelExp = newNextLevelExp;
    }
}
