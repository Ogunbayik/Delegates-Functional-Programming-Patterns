using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageSystem : MonoBehaviour
{
    private float _baseDamage = 10;

    private List<Func<float, float>> _damageModifiers = new List<Func<float, float>>();
    private void Update()
    {
        var isPressedEquipButton = Input.GetKeyDown(KeyCode.Q);
        var isPressedPotionButton = Input.GetKeyDown(KeyCode.W);
        var isPressedPoisonButton = Input.GetKeyDown(KeyCode.E);
        var isPressedResetButton = Input.GetKeyDown(KeyCode.R);

        if (isPressedEquipButton)
        {
            EquipWeaponModifier();
            Debug.Log($"Total damage: {CalculateTotalDamage()}");
        }
        else if (isPressedPotionButton)
        {
            DrinkPotionModifier();
            Debug.Log($"Total damage: {CalculateTotalDamage()}");
        }
        else if (isPressedPoisonButton)
        {
            PoisonDebuffModifier();
            Debug.Log($"Total damage: {CalculateTotalDamage()}");
        }
        else if (isPressedResetButton)
        {
            ResetToBuffModifier();
            Debug.Log($"Total damage: {CalculateTotalDamage()}");
        }
    }
    private void AddModifiers(Func<float, float> modifier) => _damageModifiers.Add(modifier);
    private void EquipWeaponModifier() => AddModifiers(damage => damage + 5);
    private void DrinkPotionModifier() => AddModifiers(damage => damage * 1.5f);
    private void PoisonDebuffModifier() => AddModifiers(damage => damage / 2);
    private void ResetToBuffModifier()
    {
        _damageModifiers.Clear();
        AddModifiers(damage => _baseDamage);
    }
    public float CalculateTotalDamage()
    {
        float finalDamage = _baseDamage;

        foreach (var modifier in _damageModifiers)
            finalDamage = modifier(finalDamage);

        return finalDamage;
    }
}
