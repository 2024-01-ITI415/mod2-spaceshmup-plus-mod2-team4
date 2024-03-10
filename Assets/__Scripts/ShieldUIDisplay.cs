using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShieldUIDisplay : MonoBehaviour
{
    // Reference to the UI Text component
    private TextMeshProUGUI shieldCounter;

    void Start()
    {
        // Get the UI Text component
        shieldCounter = GetComponent<TextMeshProUGUI>();

        // Subscribe to the shield level changed event
        Hero.OnShieldLevelChanged += UpdateShieldUI;
    }

    void OnDestroy()
    {
        // Unsubscribe from the shield level changed event to avoid memory leaks
        Hero.OnShieldLevelChanged -= UpdateShieldUI;
    }

    void UpdateShieldUI(float newShieldLevel)
    {
        // Update the UI text with the new shield level
        shieldCounter.text = "Shields: " + Mathf.FloorToInt(newShieldLevel).ToString();
    }
}
