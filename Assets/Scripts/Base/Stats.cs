using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public int damage;
    public Action OnHealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int _damage)
    {
        if(currentHealth - _damage <= 0)
        {
            currentHealth = 0;
        }
        else
        {
            currentHealth -= _damage;
        }

        OnHealthChanged?.Invoke();
    }

    public void Heal(int amount)
    {
        if(currentHealth + amount >= maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += amount;
        }

        OnHealthChanged?.Invoke();
    }
}
