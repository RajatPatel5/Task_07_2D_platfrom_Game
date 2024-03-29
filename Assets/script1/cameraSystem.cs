using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraSystem : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public float Xmin;
    public float Xmax;
    public float Ymin;
    public float Ymax;
    public float offset;
    Vector3 clamped;
    void Start()
    {
        if (player != null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
       
    }

  
   void LateUpdate()
    {
        if (player != null)
        {
            float x = Mathf.Clamp(player.transform.position.x+offset, Xmin, Xmax);
            float y = Mathf.Clamp(player.transform.position.y, Ymin, Ymax);
            //  clamped.z = player.transform.position.z;
            //  player.transform.position = clamped;
            transform.position = new Vector3(x, y, transform.position.z);
        }
        //clamped.x = Mathf.Clamp(player.transform.position.x,Xmin,Xmax);
        //clamped.y = Mathf.Clamp(player.transform.position.y,Ymin,Ymax);
      
       // transform.position = new Vector3(clamped.x, clamped.y, transform.position.z);
        //transform.position = new Vector3(clampedPlayerPosition.x, clampedPlayerPosition.y, transform.position.z);
    }
}
