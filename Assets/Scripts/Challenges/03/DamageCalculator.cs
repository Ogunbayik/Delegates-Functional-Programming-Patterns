using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCalculator : MonoBehaviour
{
    public Func<float, float, float> DamageFormula;
    void Start()
    {
        EquipSword();
        EquipStaff();
    }
    private void EquipSword()
    {
        DamageFormula = (attack, defence) => (attack * 2) - defence;
        Debug.Log("Sword damage: " + Attack(100, 20));
    }
    private void EquipStaff()
    {
        DamageFormula = (atk, def) => atk * 3;
        Debug.Log("Büyü Saldýrýsý: " + Attack(100, 20));
    }

    float Attack(float damage, float enemyDef)
    {
        return DamageFormula(damage, enemyDef);
    }
}
