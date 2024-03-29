using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyScript : MonoBehaviour
{
    public static enemyScript Instance;
    [SerializeField] private Rigidbody2D rigidbody2D;  
    [SerializeField] private float moveSpeed;
    private float Xmove=1;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private BoxCollider2D collider2D;

  public  int enemyhealth = 100;

    //[SerializeField] private Rigidbody2D rigidbody2D;
    bool EnemyDead=false;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Update()
    {
        if(!EnemyDead) 
        {
            Debug.Log("Not Dead");
            rigidbody2D.velocity = new Vector2(Xmove, 0) * moveSpeed;
            if (Physics2D.Raycast(transform.position, new Vector2(Xmove, 0), 1f, layerMask))
            {
                flips();
            }
            destroyEnemy();
        }
       
          
    }
    int colligencount = 1;
    private void OnCollisionStay2D(Collision2D collision)
    {
       // Debug.Log("this is enemy attack");
        colligencount++;
       
       for(int indexer=0;indexer<3;indexer++)
        {
            if (collision.gameObject.CompareTag("Player"))
            {

                animator.SetTrigger("isAttack");
                if (playerHealth.Instance.playerhealth > -5)
                {
                    int damege = 10;

                    playerHealth.Instance.playerhealth -= damege;
                    Debug.Log(playerHealth.Instance.playerhealth);
                    if (playerHealth.Instance.playerhealth < 0)
                    {
                        playerHealth.Instance.playrDead();

                    }
                    colligencount = 0;
                }

            }
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           // animator.SetBool("isAttack", false);
        }

    }
    private void flips()
    {
        if(Xmove<0)
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
   void  destroyEnemy()
    {
        if(transform.position.y<-7)
        {
            Destroy(gameObject);
        }
    }
    public void dead()
    {
        animator.SetTrigger("isDead");      
        EnemyDead = true;
        //this.enabled = false;
        collider2D.enabled = false;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        //Destroy(gameObject);
    }
}
