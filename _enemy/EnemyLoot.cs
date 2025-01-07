using UnityEngine;

public class EnemyLoot : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] float _expDrop;

    public float ExpDrop => _expDrop;
}
