using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class Player : MonoBehaviour
{
    int health = 10;
    public int Health => health;

    float strength = 10f;
    public float Strength => strength;

    float speed = 5.0f;
    public float Speed => speed;

    float originalSpeed;
    float speedBoostDuration = 0.0f;
    float speedBoostTimer = 0.0f;
    bool isSpeedBoostActive = false;

    [SerializeField] TextMeshProUGUI healtText, strengthText, speedText;

    private void Start()
    {
        originalSpeed = speed;
        UpdateHealthText();
        UpdateSpeedText();
        UpdateStrengthText();
    }

    private void Update()
    {
        UpdateSpeedBoostTimer();
    }

    void UpdateSpeedBoostTimer()
    {
        if (isSpeedBoostActive)
        {
            speedBoostTimer += Time.deltaTime;
            Debug.Log("+++Speed Boost...");

            if (speedBoostTimer >= speedBoostDuration)
            {
                speed = originalSpeed;
                isSpeedBoostActive = false;
                Debug.Log("Speed boost ended. Speed reset.");

            }
        }
    }
    public void PowerUp(int healthIncrease)
    {
        health += healthIncrease;
        Debug.Log($"Health increased by {healthIncrease}. New health: {health}");
        UpdateHealthText();
    }

    public void PowerUp(float strengthMultiplier)
    {
        strength *= strengthMultiplier;
        UpdateStrengthText();
        Debug.Log($"Strength  increased by {strengthMultiplier * 100}%. New Strength: {strength}");
    }
    public void PowerUp(float speedMultiplier, float duration)
    {
        if (!isSpeedBoostActive)
        {
            speed *= speedMultiplier;
            isSpeedBoostActive = true;
            speedBoostDuration = duration;
            speedBoostTimer = 0.0f;
            UpdateSpeedText();
            Debug.Log($"Speed boosted by {speedMultiplier * 100}% for {duration} seconds.");
        }
    }

    void UpdateHealthText()
    {
        healtText.text = $"health: {Health} ";
    }

    void UpdateStrengthText()
    {
        strengthText.text = $"strength: {Strength} ";
    }

    void UpdateSpeedText()
    {
        speedText.text = $"speed: {Speed} ";
    }

}
