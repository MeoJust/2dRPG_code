using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMana PlayerMana{get; private set;}
    public PlayerHealth PlayerHealth{get; set;}

    [Header("Config")]
    [SerializeField] PlayerStatsSO _stats;

    [Header("TEST")]
    public ItemHealthPotion HealthPotion;
    public ItemManaPotion ManaPotion;

    public PlayerStatsSO Stats => _stats;

    private void Awake() {
        PlayerMana = GetComponent<PlayerMana>();
        PlayerHealth = GetComponent<PlayerHealth>();
    }

    //TEMP
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            HealthPotion.UseItem();
            if (HealthPotion.UseItem())
            {
                Debug.Log("Health Potion used");
            }
            else
            {
                Debug.Log("Health Potion not used");
            }
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            ManaPotion.UseItem();
            if (ManaPotion.UseItem())
            {
                Debug.Log("Mana Potion used");
            }
            else
            {
                Debug.Log("Mana Potion not used");
            }
        }
    }

    public void ResetPlayer()
    {
        _stats.ResetPlayer();
        PlayerMana.ResetMana();

        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = Color.white;
        }
    }
}
