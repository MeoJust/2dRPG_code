using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Player _player;
    //TEMP
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _player.ResetPlayer();
        }
    }
}
