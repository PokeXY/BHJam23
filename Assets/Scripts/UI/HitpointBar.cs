using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitpointBar : MonoBehaviour
{

    public Slider slider;
    public Color low;
    public Color high;

    public void SetHealth(float health, float maxHealth)
    {
        //The health bar should only be visible when the enemy is not at full health
        slider.gameObject.SetActive(health <= maxHealth);
        slider.value = health;
        slider.maxValue = maxHealth;

        //Set the color of the health bar dependent on how hurt the enemy is
        slider.fillRect.GetComponentInChildren<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }

    private void Awake()
    {
        SetHealth(1800, 1800);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
