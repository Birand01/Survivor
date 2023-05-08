using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterManager : MonoBehaviour
{
    public delegate void OnPlayerTotalGoldAmountHandler(int amount);
    public static event OnPlayerTotalGoldAmountHandler OnPlayerTotalGoldAmount;
    public delegate void OnPlayerTotalKillAmountHandler(int amount);
    public static event OnPlayerTotalKillAmountHandler OnPlayerTotalKillAmount;
    public static CounterManager Instance;
    private void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
        }
      
    }
    public int GoldCount { get; set; } = 0;
    public int KillCount { get; private set; } = 0;
   
    private void OnEnable()
    {
        EnemyHealth.OnDeadCounter += AddKill;
        GoldInteraction.OnGoldCollected += AddGold;
    }
    private void AddGold(int numberOfCoins)
    {
        GoldCount += numberOfCoins;
        PlayerPrefs.SetInt("GoldCount", GoldCount);
        OnPlayerTotalGoldAmount(GoldCount);
    }
    private void AddKill(int numberOfKill)
    {
        KillCount += numberOfKill;
        OnPlayerTotalKillAmount(KillCount);
    }
    private void OnDisable()
    {
        EnemyHealth.OnDeadCounter -= AddKill;
        GoldInteraction.OnGoldCollected -= AddGold;

    }
}
