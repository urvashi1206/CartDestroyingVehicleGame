using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public string LevelToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().name != "Expert")
            {
                SceneManager.LoadScene(LevelToLoad);
            }
            else
            {
                SceneManager.LoadScene("WinScreen");
            }
        }
    }
}
