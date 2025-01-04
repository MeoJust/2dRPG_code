using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] PlayerStatsSO _stats;

    public PlayerStatsSO Stats => _stats;

    public void ResetPlayer()
    {
        _stats.ResetPlayer();

        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.color = Color.white;
        }
    }
}
