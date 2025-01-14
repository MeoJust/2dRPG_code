using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] Player _player;
    [SerializeField] PlayerStatsSO _stats;
    public PlayerStatsSO Stats => _stats;
    public Player Player => _player;
    //TEMP
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _player.ResetPlayer();
        }
    }

    public void AddPlayerExp(float amount) {
        PlayerExp playerExp = _player.GetComponent<PlayerExp>();
        playerExp.AddExp(amount);
    }
}
