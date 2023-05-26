using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
     anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
        anim.SetFloat("Direction", Input.GetAxis("Horizontal"));
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Jumping");
        }
    }

}
