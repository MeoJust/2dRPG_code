using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] PlayerStatsSO _stats;

    [Header("Player UI")]
    [SerializeField] TextMeshProUGUI _levelTXT;
    [SerializeField] Image _healthBar;
    [SerializeField] Image _manaBar;
    [SerializeField] Image _expBar;

    [Header("Chel Panel")]
    [SerializeField] GameObject _charPanel;
    [SerializeField] TextMeshProUGUI _statsLevelTXT;
    [SerializeField] TextMeshProUGUI _statsDmgTXT;
    [SerializeField] TextMeshProUGUI _statsCritChanceTXT;
    [SerializeField] TextMeshProUGUI _statsCritDmgTXT;
    [SerializeField] TextMeshProUGUI _statsTotalExpTXT;
    [SerializeField] TextMeshProUGUI _statsCurrentExpTXT;
    [SerializeField] TextMeshProUGUI _statsReqExpTXT;
    [SerializeField] TextMeshProUGUI _attributePointsTXT;
    [SerializeField] TextMeshProUGUI _strenghtTXT;
    [SerializeField] TextMeshProUGUI _dexterityTXT;
    [SerializeField] TextMeshProUGUI _intelligenceTXT;

    void OnEnable() {
        PlayerUpgrade.OnPlayerUpgradeEvent += UpgradeCallback;
    }

    void OnDisable() { 
        PlayerUpgrade.OnPlayerUpgradeEvent -= UpgradeCallback;

    }

    void UpgradeCallback() {
        UpdateStatsPanel();
    }

    void Update() {
        UpdatePlayerUI();
    }

    public void OpenCloseStatsPanel() {
        _charPanel.SetActive(!_charPanel.activeSelf);
        if (_charPanel.activeSelf)
        {
            UpdateStatsPanel();
        }
    }

    void UpdatePlayerUI() {
        _levelTXT.text = $"Lv. {_stats.Level}";
        _healthBar.fillAmount = Mathf.Lerp(_healthBar.fillAmount, _stats.Health / _stats.MaxHealth, 10f * Time.deltaTime);
        _manaBar.fillAmount = Mathf.Lerp(_manaBar.fillAmount, _stats.Mana / _stats.MaxMana, 10f * Time.deltaTime);
        _expBar.fillAmount = Mathf.Lerp(_expBar.fillAmount, _stats.CurrentExp / _stats.NextLevelExp, 10f * Time.deltaTime);
    }

    void UpdateStatsPanel() {
        _statsLevelTXT.text = _stats.Level.ToString();
        _statsDmgTXT.text = _stats.TotalDmg.ToString();
        _statsCritChanceTXT.text = _stats.CritChance.ToString();
        _statsCritDmgTXT.text = _stats.CritDmg.ToString();
        _statsTotalExpTXT.text = _stats.TotalExp.ToString();
        _statsCurrentExpTXT.text = _stats.CurrentExp.ToString();
        _statsReqExpTXT.text = _stats.NextLevelExp.ToString();

        _attributePointsTXT.text = $"Poionts: {_stats.AtributePoints}";
        _strenghtTXT.text = _stats.Strenght.ToString();
        _dexterityTXT.text = _stats.Dexterity.ToString();
        _intelligenceTXT.text = _stats.Intelligence.ToString();
    }
}
