using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] float damageAmount;
    [SerializeField] GameObject effect;

    private void Start()
    {
        Debug.Log(effect);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != gameObject.tag) 
        {
            if (other.gameObject.GetComponent<DamageTaker>())
            {
                other.gameObject.GetComponent<DamageTaker>().SetDamage(damageAmount);

                Debug.Log("Demed" + other.gameObject.GetComponent<DamageTaker>().GetCurrentHealthAmount());

                if (other.gameObject.GetComponent<DamageTaker>().GetCurrentHealthAmount() <= 0f)
                {
                    Debug.Log(other.gameObject.name + "is killed");
                    if (other.gameObject.GetComponent<DamageDealer>())
                    {
                        effect = other.gameObject.GetComponent<DamageDealer>().GetEffect();
                    }

                    if (effect)
                    {
                        GameObject effect = Instantiate(this.effect, other.transform.localPosition, transform.rotation);
                    }
                    Destroy(other.gameObject);
                }
            }
        }
    }

    public GameObject GetEffect() 
    {
        return effect;
    }
}
