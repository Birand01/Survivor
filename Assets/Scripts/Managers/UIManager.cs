using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text goldCounterText,deadCounterText;
    [SerializeField] private GameObject levelFailUI;
    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeadEvent += LevelFailActivation;
        CounterManager.OnPlayerTotalKillAmount += TotalKillAmount;
        CounterManager.OnPlayerTotalGoldAmount += TotalGoldAmount;
    }
    private void Start()
    {
        if (PlayerPrefs.HasKey("GoldCount"))
        {
            CounterManager.Instance.GoldCount = PlayerPrefs.GetInt("GoldCount");
            goldCounterText.text = CounterManager.Instance.GoldCount.ToString();
        }
    }
    private void TotalGoldAmount(int value)
    {
        
        goldCounterText.text = value.ToString();
    }

    private void TotalKillAmount(int value)
    {
        deadCounterText.text = value.ToString();
    }
    private void LevelFailActivation()
    {
        levelFailUI.SetActive(true);
    }
    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeadEvent -= LevelFailActivation;
        CounterManager.OnPlayerTotalKillAmount -= TotalKillAmount;
        CounterManager.OnPlayerTotalGoldAmount -= TotalGoldAmount;

    }
}
