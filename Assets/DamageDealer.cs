using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float damageAmount;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<DamageTaker>())
        {
            other.gameObject.GetComponent<DamageTaker>().SetDamage(damageAmount);

            Debug.Log("Demed");

            if (other.gameObject.GetComponent<DamageTaker>().GetCurrentHealthAmount() <= 0f)
            {
                Destroy(other.gameObject);
            }
        }
    }
}
