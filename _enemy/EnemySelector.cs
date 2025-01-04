using UnityEngine;

public class EnemySelector : MonoBehaviour
{
    EnemyBrain _enemyBrain;

    [Header("Config")]
    [SerializeField] GameObject _selectorSprite;

    void Awake()
    {
        _enemyBrain = GetComponent<EnemyBrain>();
    }

    void OnEnable()
    {
        SelectionManager.OnEnemySelectedEvent += OnEnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent += OnNoSelectionCallback;
    }

    void OnDisable()
    {
        SelectionManager.OnEnemySelectedEvent -= OnEnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent -= OnNoSelectionCallback;
    }

    void OnEnemySelectedCallback(EnemyBrain enemyBrain)
    {
        if (enemyBrain == _enemyBrain)
        {
            _selectorSprite.SetActive(true);
        }
        else
        {
            _selectorSprite.SetActive(false);
        }
    }

    void OnNoSelectionCallback()
    {
        _selectorSprite.SetActive(false);
    }
}
