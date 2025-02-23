using UnityEngine;
using BayatGames.SaveGameFree;

public class CoinManager : Singleton<CoinManager>
{
    [SerializeField] float _coinsTest;

    public float Coins { get; private set; }
    const string COINS_KEY = "coins";

    void Start()
    {
        Coins = SaveGame.Load(COINS_KEY, _coinsTest);
    }

    public void AddCoins(float amount)
    {
        Coins += amount;
        SaveGame.Save(COINS_KEY, Coins);
    }

    public void RemoveCoins(float amount)
    {
        if (Coins >= amount)
        {
            Coins -= amount;
            SaveGame.Save(COINS_KEY, Coins);
        }
    }


}
