using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] float health; // only serialized for debugging purposes
    [SerializeField] float startingHealthAmount;

    private void Start()
    {
        health = startingHealthAmount;
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
}