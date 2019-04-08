using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    bool isJumping = false;
    public float speed = 1;
    public float jumpSpeed = 10;
    public static int life = 3;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        isJumping = Input.GetKey(KeyCode.Space);

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
        if (isJumping)
        {
            body.AddForce(Vector2.up * jumpSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Loot")
        {
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Loot")
        {
            Destroy(collider.gameObject);
        }
    }
}
