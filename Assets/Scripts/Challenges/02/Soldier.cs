using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier 
{
    public int CurrentHealth;
    public int MaxHealth;

    public Soldier(int currentHealth, int maxHealth)
    {
        CurrentHealth = currentHealth;
        MaxHealth = maxHealth;
    }
}
