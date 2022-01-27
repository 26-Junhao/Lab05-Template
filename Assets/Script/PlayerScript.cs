using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public int coin;
    
    private float scorevalue;

    public float totalcoins;

    public float timeleft;

    public int timeRemaining;

    public Text TimerText;
    public GameObject ScoreText;

    private float TimerValue;

    public GameObject particle;

    // Update is called once per frame
    void Update()
    {
        timeleft -= Time.deltaTime;
        timeRemaining = Mathf.FloorToInt(timeleft % 60);
        TimerText.text = "Timer : " + timeRemaining.ToString();

        if(scorevalue == totalcoins)
        {
            if (timeleft >= TimerValue)
            {
                SceneManager.LoadScene("GameWinScene");
            }
        }
        else if(timeleft <= 0)
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Coin")
        {
            scorevalue += 10;
            ScoreText.GetComponent<Text>().text = "Score : " + scorevalue;
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag == "Water")
        {
            SceneManager.LoadScene("GameLoseScene");
        }
    }
}
