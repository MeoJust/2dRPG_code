using UnityEngine;

public class Player : MonoBehaviour
{
    PlayerMana _playerMana;

    [SerializeField] PlayerStatsSO _stats;

    public PlayerStatsSO Stats => _stats;

    private void Awake() {
        _playerMana = GetComponent<PlayerMana>();
    }

    public void ResetPlayer()
    {
        _stats.ResetPlayer();
        _playerMana.ResetMana();

        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = Color.white;
        }
    }
}
