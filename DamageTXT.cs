using UnityEngine;
using TMPro;

public class DamageTXT : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] TextMeshProUGUI _txt;

    public void SetText(float damage)
    {
        _txt.text = damage.ToString();
    }

    public void DieMtfckr()
    {
        Destroy(gameObject);
    }
}
