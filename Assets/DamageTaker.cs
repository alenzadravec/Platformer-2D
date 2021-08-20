using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTaker : MonoBehaviour
{
    [SerializeField] float health;

    public void SetDamage(float damageAmount) 
    {
        health -= damageAmount;
    }

    public float GetCurrentHealthAmount() 
    {
        return health;
    }
}
