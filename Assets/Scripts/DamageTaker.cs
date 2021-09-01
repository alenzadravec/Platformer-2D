using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] float health; // only serialized for debugging purposes
    [SerializeField] float startingHealthAmount;
    private float healthKeeper;

    private void Start()
    {
        health = startingHealthAmount;
        healthKeeper = health;
    }

    public void SetDamage(float damageAmount) 
    {
        health -= damageAmount;
    }

    public float GetCurrentHealthAmount() 
    {
        return health;
    }

    public void ResetHealth() 
    {
        this.health = startingHealthAmount;
    }

    public bool OnHealthChange() 
    {
        if (health < healthKeeper)
        {
            healthKeeper = health;
            return true;
        }
        else 
        {
            return false;
        }
    }
}
