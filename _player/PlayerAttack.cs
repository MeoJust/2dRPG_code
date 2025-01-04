using System.Collections;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    PlayerIA _actions;
    PlayerMove _playerMove;
    EnemyBrain _enemyTarget;

    [Header("Config")]
    [SerializeField] WeaponSO _initWeapon;
    [SerializeField] Transform[] _attackPoints;

    Coroutine _attackCoroutine;
    Transform _currentAttackPosition;
    float _currentAttackRotation;

    void Awake() {
        _actions = new PlayerIA();
        _playerMove = GetComponent<PlayerMove>();
    }

    void OnEnable() {
        _actions.Enable();
        SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent += NoEnemySelectedCallback;
    }

    void OnDisable() {
        _actions.Disable();
        SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent -= NoEnemySelectedCallback;
    }

    void Start() {
        _actions.attack.clickAttack.performed += ctx => Attack();
        _currentAttackPosition = _attackPoints[0];
    }

    void Update() {
        GetFirePosition();
    }

    void Attack() {
        if (_enemyTarget == null)
            return;
        if (_attackCoroutine != null)
            StopCoroutine(_attackCoroutine);

        _attackCoroutine = StartCoroutine(AttackCoroutine());
    }

    IEnumerator AttackCoroutine() {
        if(_currentAttackPosition != null)
        {
            //if (_playerMana.CurrentMana < _initWeapon.RecuiredMana) yield break;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, _currentAttackRotation));
            Projectile projectile = Instantiate(_initWeapon.ProjectilePrefab, _currentAttackPosition.position, rotation);
            projectile.Dir = Vector3.up;
            print("doljno rabotat'");
        }

        //here comes the animations
        yield return new WaitForSeconds(.5f);
        print("Ready completed");
    }

    void GetFirePosition() {
        Vector2 moveDir = _playerMove.MoveDir;

        switch (moveDir.x)
        {
            case > 0:
                _currentAttackPosition = _attackPoints[1];
                _currentAttackRotation = -90f;
                break;
            case < 0:
                _currentAttackPosition = _attackPoints[3];
                _currentAttackRotation = -270f;
                break;
        }

        switch (moveDir.y)
        {
            case > 0:
                _currentAttackPosition = _attackPoints[0];
                _currentAttackRotation = 0;
                break;
            case < 0:
                _currentAttackPosition = _attackPoints[2];
                _currentAttackRotation = 180f;
                break;
        }
    }

    void EnemySelectedCallback(EnemyBrain enemySelected) {
        _enemyTarget = enemySelected;
    }

    void NoEnemySelectedCallback() {
        _enemyTarget = null;
    }
}
