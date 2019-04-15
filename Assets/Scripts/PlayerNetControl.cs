using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

[System.Obsolete]
public class PlayerNetControl : NetworkBehaviour
{
    float horizontal;
    float vertical;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(isLocalPlayer) 
            animator.SetBool("walking", horizontal != 0);
    }

    private void FixedUpdate()
    {


        if (isLocalPlayer)
        {

            var originalPosition = transform.position;

            originalPosition = originalPosition + (new Vector3(horizontal, vertical) * 0.5f);

            transform.position = originalPosition;
        }
    }
}
