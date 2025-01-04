using UnityEngine;

public class PlayerMana : MonoBehaviour
{
    [SerializeField] PlayerStatsSO _stats;

    public float CurrentMana {  get; private set; }

    void Start() {
        ResetMana();
    }

    //TEMP
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            UseMana(1);
            Debug.Log("Player mana: " + _stats.Mana);
        }
    }

    public void UseMana(float amount)
    {
        if (_stats.Mana >= amount)
        {
            _stats.Mana -= amount;
            Debug.Log("Mana ostalos': " + _stats.Mana);

            if (_stats.Mana <= 0)
            {
                _stats.Mana = 0;
            }
            CurrentMana = _stats.Mana;
        }
        else
        {
            Debug.Log("Not enough mana");
        }

        
    }

    public void ResetMana() {
        CurrentMana = _stats.MaxMana;
    }
}
