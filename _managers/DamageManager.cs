using UnityEngine;

public class DamageManager : Singleton<DamageManager>
{
    [Header("Config")]
    [SerializeField] DamageTXT _damageTxtPrefab;

    public void ShowDamage(float damageAmount, Transform parent)
    {
        DamageTXT damageTxt = Instantiate(_damageTxtPrefab, parent);
        damageTxt.transform.position += Vector3.right * .5f;
        damageTxt.SetText(damageAmount);
    }
}
