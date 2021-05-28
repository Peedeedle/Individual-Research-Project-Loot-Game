///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
///     File:            HealthBar.cs
///     Author:          Jack Peedle
///     Date Created:    15/11/2020
///     Brief:
///\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    // Reference to slider on healthbar
    public Slider slider;

    // Public colour gradient for healthbar
    public Gradient gradient;

    // Fill image
    public Image fill;

    // Set the max health to the player
    public void SetMaxHealth (int health)
    {
        // Set slider value and max slider value to health
        slider.maxValue = health;
        slider.value = health;

        // Evaluate the colour of the gradient
        fill.color = gradient.Evaluate(1f);

    }

    // Set the health to what the slider is currently on
    public void SetHealth (int health)
    {
        // Set slider value to health
        slider.value = health;

        // Evaluate health and set colour
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
