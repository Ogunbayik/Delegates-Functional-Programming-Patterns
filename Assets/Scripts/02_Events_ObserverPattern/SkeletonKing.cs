using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonKing : MonoBehaviour
{
    private int _testDamage = 5;

    public static event Action OnBossDead;

    private int _health = 20;

    private void OnMouseDown() => TakeDamage(_testDamage);
    private void TakeDamage(int damageAmount)
    {
        _health -= damageAmount;

        if (_health <= 0)
            Die();
    }
    private void Die()
    {
        _health = 0;
        OnBossDead?.Invoke();
    }
}
