using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    [SerializeField] private Color lowHealthColor;
    [SerializeField] private Color highHealthColor;
    [SerializeField] private Color mediumHealthColor;
   
    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (slider != null)
        {
            slider.value = CalculateHealthPercentage(currentHealth, maxHealth);
            UpdateSliderColor(currentHealth, maxHealth);

        }
        else
        {
            Debug.LogError("Slider reference is not set on the HealthBar!");
        }
        
    }

    private float CalculateHealthPercentage(int currentHealth, int maxHealth)
    {
        return (float)currentHealth / maxHealth;
    }
    private void UpdateSliderColor(float currentValue, float maxValue)
    {
        float healthPercentage = currentValue / maxValue;


        if (healthPercentage <= 0.2f)
        {
           
            slider.fillRect.GetComponent<Image>().color = lowHealthColor;
        }
        else if (healthPercentage <= 0.8f)
        {
            slider.fillRect.GetComponent<Image>().color = mediumHealthColor;

        }
        else 
        {
           
            slider.fillRect.GetComponent<Image>().color = highHealthColor;
        }
    }
}
