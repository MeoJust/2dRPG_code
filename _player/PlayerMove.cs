using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    PlayerIA _ia;
    Player _player;

    [SerializeField] float _moveSpeed;

    Rigidbody2D _rb;
    Vector2 _moveDir;

    public Vector2 MoveDir;

    void Awake()
    {
        _ia = new PlayerIA();
        _player = GetComponent<Player>();
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        _ia.Enable();
    }

    void OnDisable()
    {
        _ia.Disable();
    }

    void Update()
    {
        ReadMoveInput();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ReadMoveInput()
    {
        _moveDir = _ia.move.walk.ReadValue<Vector2>().normalized;
    }

    void Move()
    {
        if (_player.Stats.Health <= 0)
            return;

        _rb.MovePosition(_rb.position + _moveDir * _moveSpeed * Time.fixedDeltaTime);
    }
}
