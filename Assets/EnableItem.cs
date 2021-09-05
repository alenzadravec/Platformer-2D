using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableItem : MonoBehaviour
{
    [SerializeField] GameObject itemToEnable;
    // Start is called before the first frame update
    void Start()
    {
        itemToEnable.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (FindObjectOfType<Player>().GetItemsList().Count == 2)//because game doesn't let be otherwise - hardcoded
            {
                itemToEnable.gameObject.SetActive(true);
            }
        }
    }
}
