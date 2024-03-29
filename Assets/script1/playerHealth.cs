using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{
    public static playerHealth Instance;
    [SerializeField] private Animator animator;
   public int playerhealth=100;
    float time = 0;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
    }   
    void Update ()
    {
     
    }

  public           void playrDead()
    {
        if(playerhealth < 0)
        {
            animator.SetTrigger("isDead");
            //estroy(animator);
            //animator.enabled=false;
            //SceneManager.LoadScene("level01");
           
        }
       
    }


}
