using System.Collections;
using UnityEngine;
public class PlayerAttack : MonoBehaviour
{
    PlayerIA _actions;
    PlayerMove _playerMove;
    PlayerMana _playerMana;
    EnemyBrain _enemyTarget;

    [Header("Config")]
    [SerializeField] PlayerStatsSO _stats;
    [SerializeField] WeaponSO _initWeapon;
    [SerializeField] Transform[] _attackPoints;

    Coroutine _attackCoroutine;
    Transform _currentAttackPosition;
    float _currentAttackRotation;

    void Awake() {
        _actions = new PlayerIA();
        _playerMove = GetComponent<PlayerMove>();
        _playerMana = GetComponent<PlayerMana>();
    }

    void OnEnable() {
        _actions.Enable();
        SelectionManager.OnEnemySelectedEvent += EnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent += NoEnemySelectedCallback;
        EnemyHealth.OnEnemyDeadEvent += NoEnemySelectedCallback;
    }

    void OnDisable() {
        _actions.Disable();
        SelectionManager.OnEnemySelectedEvent -= EnemySelectedCallback;
        SelectionManager.OnNoSelectionEvent -= NoEnemySelectedCallback;
        EnemyHealth.OnEnemyDeadEvent -= NoEnemySelectedCallback;
    }

    void Start() {
        WpManager.Instance.EquipWeapon(_initWeapon);
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
            if (_playerMana.CurrentMana < _initWeapon.RecuiredMana) yield break;
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, _currentAttackRotation));
            Projectile projectile = Instantiate(_initWeapon.ProjectilePrefab, _currentAttackPosition.position, rotation);
            projectile.Dir = Vector3.up;
            projectile.Damage = GetAttackDamage();
            print("doljno rabotat'");
            _playerMana.UseMana(_initWeapon.RecuiredMana);
        }

        //here comes the animations
        yield return new WaitForSeconds(.5f);
        print("Ready completed");
    }

    public void EquipWp(WeaponSO newWp) {
        _initWeapon = newWp;
        _stats.TotalDmg = _stats.BaseDamage + _initWeapon.Damage;
    }


    //crit chance
    float GetAttackDamage() {
        float damage = _stats.BaseDamage;
        damage += _initWeapon.Damage;
        float randomPerc = Random.Range(0, 100f);
        if(randomPerc <= _stats.CritChance)
        {
            damage += damage * (_stats.CritDmg / 100f);
        }

        return damage;
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
