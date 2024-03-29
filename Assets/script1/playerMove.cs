using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playerMove : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private FixedJoystick fixedJoystick;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Vector2 jumpDir;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public bool isGround = false;
    [SerializeField] private LayerMask layerMask;
    Vector2 upperLimit;
    Vector2 lowerLimit;
  
    private bool isJumping = false;
   
    void Update()
    {
      
            upperLimit = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
            lowerLimit = Camera.main.ScreenToWorldPoint(Vector2.zero);
            transform.position = new Vector2(Mathf.Clamp(transform.position.x, lowerLimit.x, upperLimit.x), Mathf.Clamp(transform.position.y, lowerLimit.y, upperLimit.y));

            if (fixedJoystick.Horizontal > 0.1f)
            {
                animator.SetBool("isRun", true);
            }
            else if (fixedJoystick.Horizontal < -0.1f)
            {
                animator.SetBool("isRun", true);
            }
            else
            {
                animator.SetBool("isRun", false);
            }


            if ((fixedJoystick.Horizontal > 0.1f))
            {
                spriteRenderer.flipX = false;
                transform.position = new Vector2(transform.position.x + 0.04f, transform.position.y);
               
            }

            else if (fixedJoystick.Horizontal < -0.1f)
            {
                spriteRenderer.flipX = true;
                transform.position = new Vector2(transform.position.x - 0.04f, transform.position.y);
              
            }
      
        findEnemy();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isGround = true;
        }
        raycast();
    }
    void raycast()
    {


    }
    int count = 0;
    void findEnemy()
    {
       

    }
    private bool isJump = false;
    public void jump()
    {
        if (spriteRenderer.flipX && isGround)
        {

            rb.velocity = new Vector2(-0.8f, 4f) * speed;
            isGround = false;
            isJump = true;
        }
        else if (!spriteRenderer.flipX && isGround)
        {

            rb.velocity = new Vector2(0.8f, 4f) * speed;
            isGround = false;
            isJump = true;
        }
        else
        {
            isJump = false;
        }

        jumpAnimation();
    }
    public void jumpAnimation()
    {
        animator.SetTrigger("isJump");
       
    }

 
    public void attackAnimation()
    {

        animator.SetTrigger("isAttack");

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, layerMask);

        if (hit.collider != null)
        {
           
            enemyScript enemyScript = hit.collider.GetComponent<enemyScript>();

            if (enemyScript != null)
            {
              
                enemyScript.enemyhealth -= 20;

                if (enemyScript.enemyhealth < -5)
                {
                    enemyScript.dead();
                }
            }
        }
    }
    public void low()
    {
        Physics2D.gravity = new Vector2(0, -4.0F);
    }

    public void medium()
    {
        Physics2D.gravity = new Vector3(0, -7.0F);
    }
    public void high()
    {
        Physics2D.gravity = new Vector2(0, -10.0F);
    }
    public void save()
    {
        //istouch = true;
        //setting.enabled = false;
    }
}
