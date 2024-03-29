using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;


public class playerScore : MonoBehaviour
{
    private float timeLeft = 120f; // Changed to float
    private int PlayerScore ; // Corrected variable name
    [SerializeField] private TextMeshProUGUI timeLimitUI;
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject coin;

    void Update()
    {
        
            timeLeft -= Time.deltaTime;
            int timeLeftInt = Mathf.RoundToInt(timeLeft);
            timeLimitUI.text = timeLeftInt.ToString();


            if (timeLeft < 1)
            {
                SceneManager.LoadScene("level01");
            }
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Coin")
        {
            PlayerScore += 10;
            scoreUI.text = PlayerScore.ToString();
           
            Destroy(collision.gameObject);
        }
       
    }

    public void Score()
    {
        Debug.Log("Data says high score is currectly " + DataManeger.Instance.hightScore);

        PlayerScore = PlayerScore + (int)(timeLeft * 10); // Corrected score calculation
        DataManeger.Instance.hightScore = PlayerScore+(int)(timeLeft*10);
        DataManeger.Instance.SaveData();
        Debug.Log("now that we have to add the score in this and new score is "+DataManeger.Instance.hightScore);

    
    }
}
