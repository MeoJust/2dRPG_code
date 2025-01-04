using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public static DamageManager Instance;

    [Header("Config")]
    [SerializeField] DamageTXT _damageTxtPrefab;

    void Awake()
    {
        Instance = this;
    }

    public void ShowDamage(float damageAmount, Transform parent)
    {
        DamageTXT damageTxt = Instantiate(_damageTxtPrefab, parent);
        damageTxt.transform.position += Vector3.right * .5f;
        damageTxt.SetText(damageAmount);
    }
}
