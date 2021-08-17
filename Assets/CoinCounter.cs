using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    [SerializeField] int coinsForFullHealth;
    [SerializeField] Text coinCounterText;
    private int coinAmount;

    // Start is called before the first frame update
    void Start()
    {
        coinAmount = 0;
        coinCounterText.text = coinAmount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseCoins(int increasingAmount) 
    {
        coinAmount += increasingAmount;
        coinCounterText.text = coinAmount.ToString();

        if (coinAmount == coinsForFullHealth) 
        {
            //set player health to initial amount
        }
    }
}
