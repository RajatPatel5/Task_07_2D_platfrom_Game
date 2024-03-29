using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2Script : MonoBehaviour
{
//    public static enemy2Script Instance;
//    [SerializeField] private Rigidbody2D rigidbody2D;
//    [SerializeField] private float moveSpeed;
//    private float Xmove = 1;
//    [SerializeField] private SpriteRenderer spriteRenderer;
//    [SerializeField] private GameObject player;
//    [SerializeField] private Animator animator;
//    [SerializeField] private LayerMask layerMask;
//    [SerializeField] private BoxCollider2D collider2D;

  
//    //[SerializeField] private Rigidbody2D rigidbody2D;
//    bool EnemyDead = false;
//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//        }
//    }
//    void Update()
//    {
//        if (!EnemyDead)
//        {
//            rigidbody2D.velocity = new Vector2(Xmove, 0) * moveSpeed;
//            if (Physics2D.Raycast(transform.position, new Vector2(Xmove, 0), 1f, layerMask))
//            {
//                flips();
//            }
//            destroyEnemy();
//        }


//    }
//    int colligencount = 1;
//    private void OnCollisionStay2D(Collision2D collision)
//    {
//        colligencount++;
//        if (collision.gameObject.CompareTag("Player") && colligencount == 20 && (!EnemyDead))
//        {
//            //   animator.SetBool("isAttack", true);
//            animator.SetTrigger("isAttack");
//            if (playerHealth.Instance.playerhealth > -5)
//            {
//                int damege = 10;

//                playerHealth.Instance.playerhealth -= damege;
//                Debug.Log(playerHealth.Instance.playerhealth);
//                if (playerHealth.Instance.playerhealth < 0)
//                {
//                    playerHealth.Instance.playrDead();

//                }
//                colligencount = 0;
//            }

//        }
//    }
   
//    private void flips()
//    {
//        if (Xmove < 0)
//        {
//            spriteRenderer.flipX = false;
//            Xmove = 1;
//        }
//        else
//        {
//            spriteRenderer.flipX = true;
//            Xmove = -1;
//        }
//    }
//    void destroyEnemy()
//    {
//        if (transform.position.y < -7)
//        {
//            Destroy(gameObject);
//        }
//    }
//    public void dead()
//    {
//        animator.SetTrigger("isDead");
//        EnemyDead = true;
//        collider2D.enabled = false;
//        rigidbody2D.velocity = Vector2.zero;
//        rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

//    }
}