using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] Player _player;

    private void Awake() {
        Instance = this;
    }

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
