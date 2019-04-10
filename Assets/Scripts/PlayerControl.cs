using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    float horizontal;
    bool isJumping = true;
    bool jumpPressed;
    public float speed = 1;
    public float jumpSpeed = 10;
    public static int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        jumpPressed = Input.GetKey(KeyCode.Space);


        animator.SetBool("walking", horizontal != 0);
        animator.SetBool("jumping", isJumping);

        if(life <= 0)
        {
            life = 3;
            SceneManager.LoadScene("Menu");
        }

        if (transform.position.y <= -3)
        {
            life = life - 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void FixedUpdate()
    {
        body.AddForce(new Vector2(horizontal * speed, 0));
        if (jumpPressed && isJumping == false)
        {
            body.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag != "Loot")
        {
            isJumping = true;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Loot")
        {
            Destroy(collider.gameObject);
        }
        else
        {
            isJumping = false;
        }
    }
}
