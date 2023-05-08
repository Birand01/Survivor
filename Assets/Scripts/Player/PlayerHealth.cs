using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealth : HealthBase
{
    public delegate void OnPlayerDeadAnimationHandler();
    public static event OnPlayerDeadAnimationHandler OnPlayerDeadEvent;
    public delegate void OnGameOverSoundHandler(string name, bool state);
    public static event OnGameOverSoundHandler OnGameOverSound;

    [SerializeField] public Slider healthBarSlider;
    [SerializeField] protected Image healthBarFillImage;
    [SerializeField] protected Color maxHealthColor, minHealthColor;
   
    private void Awake()
    {
        SetHealthBarUI();
    }

    protected virtual void Update()
    {
        SetHealthBarUI();
    }
    private void SetHealthBarUI()
    {
        float healthPercentage = CalculateHealthPercentage();
        healthBarSlider.value = healthPercentage;
        healthBarFillImage.color = Color.Lerp(minHealthColor, maxHealthColor, healthPercentage / healthBarSlider.maxValue);


    }
    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        Health = Mathf.Clamp(Health, 0, healthBarSlider.value);
        SetHealthBarUI();
    }
    private float CalculateHealthPercentage()
    {
        return (Health / healthBarSlider.maxValue) * healthBarSlider.maxValue;
    }

    protected override void CheckIfDead()
    {
       if(Health<=0)
        {
            OnGameOverSound?.Invoke("GameOverSound", true);
            OnPlayerDeadEvent?.Invoke();
            Debug.Log("Player is dead");
        }
    }
    private void DeadEvent()
    {
        Health = 0;
    }
}
