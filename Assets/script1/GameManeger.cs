using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManeger : MonoBehaviour
{
    public static GameManeger Instance;
    // [SerializeField] public GameObject startUI;
    [SerializeField] private Canvas start;
    [SerializeField] private Canvas scoreScrean;
    [SerializeField] private Canvas settingPage;
    [SerializeField] private Canvas playAgain;
    public bool isPlay = false;
    private void Awake()
    {

        start.enabled = true;
        scoreScrean.enabled = false;
        settingPage.enabled = false;
        playAgain.enabled = false;
        if (Instance == null)

        {
            Instance = this;
        }
    }
    public void Update()
    {
    }
    public void startGame()
    {
        Debug.Log("hello ");
        isPlay = true;
        start.enabled = false;
        scoreScrean.enabled=true;


    }
    public void pause()
    {
        Time.timeScale = 0f;
    }
    public void unPause()
    {
        Time.timeScale = 1f;
    }
}
