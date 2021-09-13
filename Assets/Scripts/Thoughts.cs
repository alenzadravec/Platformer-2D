using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thoughts : MonoBehaviour
{
    [SerializeField] Text thoughtsBox;
    [SerializeField] int thoughtsCounter = 0;
    [SerializeField] List<string> thoughtsTriggers = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "thought") 
        {
            if (FindObjectOfType<Player>().GetItemsList().Count == 4) // YOU WIN!
            {
                thoughtsBox.text = thoughtsTriggers[thoughtsTriggers.Count];
            }
                thoughtsBox.text = thoughtsTriggers[thoughtsCounter];
                other.gameObject.SetActive(false);
                thoughtsCounter++;
        }
    }
}
