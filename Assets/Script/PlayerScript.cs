using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public GameObject ScoreText;
    public int coin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            coin += 10;
            ScoreText.GetComponent<Text>().text = "Score: " + coin;
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

}
