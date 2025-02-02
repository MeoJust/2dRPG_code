using UnityEngine;
using System;

public class SelectionManager : MonoBehaviour
{
    public static event Action<EnemyBrain> OnEnemySelectedEvent;
    public static event Action OnNoSelectionEvent;

    [SerializeField] LayerMask _enemyLayer;

    Camera _mainCam;

    void Awake()
    {
        _mainCam = Camera.main;
    }

    void Update()
    {
        SelectEnemy();
    }

    void SelectEnemy()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(_mainCam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, _enemyLayer);
            if (hit.collider != null)
            {
                EnemyBrain enemyBrain = hit.collider.GetComponent<EnemyBrain>();
                if (!enemyBrain) return;
                EnemyHealth enemyHealth = enemyBrain.GetComponent<EnemyHealth>();
                if(enemyHealth.CurrentHealth <= 0) {
                    EnemyLoot enemyLoot = enemyBrain.GetComponent<EnemyLoot>();
                    LootManager.Instance.ShowLootPanel(enemyLoot);
                    // return;
                }
                else
                {
                    OnEnemySelectedEvent?.Invoke(enemyBrain);
                }
            }

            else
            {
                OnNoSelectionEvent?.Invoke();
            }
        }
    }
}
