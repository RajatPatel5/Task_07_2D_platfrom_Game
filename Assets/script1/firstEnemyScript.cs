using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firstEnemyScript : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float moveSpeed;
    private float Xmove;
    [SerializeField] private SpriteRenderer spriteRenderer;
    // [SerializeField]private LayerMask layerMask;
    // Update is called once per frame
    void Update()
    {
       
            RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Xmove, 0));
            rigidbody2D.velocity = new Vector2(Xmove, 0) * moveSpeed;
            if (hit.distance < 1f)
            {
                flips();
                if (hit.collider != null && hit.collider.tag == "Player")
                {
                    Destroy(hit.collider.gameObject);
                    SceneManager.LoadScene("level01");
                }

            }
        
     
          
        
        destroyEnemy();
    }
    private void flips()
    {

      
            spriteRenderer.flipX = false;
            Xmove = -1;
          
        
    }
    void destroyEnemy()
    {
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }
}
