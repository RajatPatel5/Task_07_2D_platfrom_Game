using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove3 : MonoBehaviour
{
    [SerializeField] private GameObject player;
 
    [SerializeField] private float Xoffset;
    void Start()
    {

    }
    void Update()
    {
        //if(GameManeger.Instance.isPlay)
        //{
            if (player != null)
            {


                if (transform.position.x < (player.transform.position.x - 15f))
                {
                    transform.position = new Vector3(player.transform.position.x + Xoffset, 3.5f, 0);
                }
            }
        //}
       

    }
}
