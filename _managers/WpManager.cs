using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WpManager : Singleton<WpManager>
{
    [Header("Config")]
    [SerializeField] Image _wpIcon;
    [SerializeField] TextMeshProUGUI _wpManaTXT;

    public void EquipWeapon(WeaponSO wp)
    {
        _wpIcon.sprite = wp.Icon;
        _wpIcon.SetNativeSize();
        _wpIcon.gameObject.SetActive(true);
        _wpManaTXT.text = wp.RecuiredMana.ToString();
        _wpManaTXT.gameObject.SetActive(true);
        GameManager.Instance.Player.PlayerAttack.EquipWp(wp);
    }

}