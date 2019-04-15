using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverControl : MonoBehaviour
{
    private Animator animator;
    private bool isLevelOn = false;
    private bool isDisabled = false;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            isLevelOn = !isLevelOn;

        if (Input.GetKeyDown(KeyCode.P))
            isDisabled = !isDisabled;

        animator.SetBool("power", isLevelOn);
        animator.SetBool("disable", isDisabled);

    }

}
