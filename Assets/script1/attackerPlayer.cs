using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class attackerPlayer : MonoBehaviour
{
    


    [SerializeField] private Rigidbody2D rigidbody2D;
    [SerializeField] private float moveSpeed;
    private float Xmove;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
   
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(Xmove, 0));
        rigidbody2D.velocity = new Vector2(Xmove, 0) * moveSpeed;
        if (hit.distance < 2f)
        {

            if (player != null)
            {
                if (hit.collider != null && (hit.collider.tag == "Player"))
                {
                    //   Destroy(hit.collider.gameObject);
                    animator.SetBool("isAttack",true);
                    // SceneManager.LoadScene("level01");
                }
                else
                {
                    flips();
                }

            }

        }





        destroyEnemy();
    }
    private void flips()
    {

        if (Xmove < 0)
        {

            spriteRenderer.flipX = false;
            Xmove = 1;



        }
        else
        {
            spriteRenderer.flipX = true;
            Xmove = -1;

        }
    }
    void destroyEnemy()
    {
        if (transform.position.y < -7)
        {
            Destroy(gameObject);
        }
    }

}
