using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medic : MonoBehaviour
{
    private Predicate<Soldier> IsAlive;
    private Func<Soldier, int> GetMissingHealth;
    void Start()
    {
        IsAlive = (soldier) => soldier.CurrentHealth > 0;
        GetMissingHealth = (soldier) => soldier.MaxHealth - soldier.CurrentHealth;

        Soldier firstSoldier = new Soldier(40, 100);
        Soldier secondSoldier = new Soldier(0, 100);

        Heal(firstSoldier, () =>
        {
            Debug.Log($"Recovering is completed! {firstSoldier.CurrentHealth}/{firstSoldier.MaxHealth}");
        });
        Heal(secondSoldier, () =>
        {
            Debug.Log($"Recovering is completed! {secondSoldier.CurrentHealth}/{secondSoldier.MaxHealth}");
        });
    }
    void Heal(Soldier target, Action onCompleteCallback)
    {
        if (!IsAlive(target))
        {
            Debug.Log("The Soldier is dead!");
            return;
        }

        var remainHealth = GetMissingHealth(target);
        Debug.Log($"Soldier is healing {remainHealth}");
        target.CurrentHealth += remainHealth;
        onCompleteCallback?.Invoke();
    }
}
