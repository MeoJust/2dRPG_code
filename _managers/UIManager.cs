using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerStatsSO _stats;

    [Header("Player UI")]
    [SerializeField] TextMeshProUGUI _levelTXT;
    [SerializeField] Image _healthBar;
    [SerializeField] Image _manaBar;
    [SerializeField] Image _expBar;

    void Update()
    {
        UpdatePlayerUI();
    }

    void UpdatePlayerUI()
    {
        _levelTXT.text = $"Lv. {_stats.Level}";
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, _stats.Health / _stats.MaxHealth, 10f * Time.deltaTime);
        _manaBar.fillAmount = Mathf.Lerp(_manaBar.fillAmount, _stats.Mana / _stats.MaxMana, 10f * Time.deltaTime);
        _expBar.fillAmount = Mathf.Lerp(_expBar.fillAmount, _stats.CurrentExp / _stats.NextLevelExp, 10f * Time.deltaTime);
    }
}
