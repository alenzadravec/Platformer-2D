using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    [SerializeField] float loadingTime;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("LoadMainMenu");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Transform>().Rotate(new Vector3(0f, 0f, -1f));
    }

    IEnumerator LoadMainMenu() 
    {
        yield return new WaitForSeconds(loadingTime);
        FindObjectOfType<LevelLoader>().SetMainMenuTrue();
    }
}
