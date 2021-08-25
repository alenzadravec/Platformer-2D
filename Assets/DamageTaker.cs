using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float startingHealthAmount;

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
}
