using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animHDD : MonoBehaviour
{
    public Animator anim;
    bool reverse;
    string modelName = "Naruto";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) 
        {
            if (modelName == "Naruto") {
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("_Idle")) 
                {
                    reverse = false;
                    anim.Play("Walk");
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk")) 
                {
                    if (reverse == false) 
                    {
                        anim.Play("Run"); 
                    }
                    else 
                    {
                        anim.Play("_Idle");
                    }
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                {
                    if (reverse == false) 
                    {
                        anim.Play("Dash"); 
                    }
                    else 
                    {
                        anim.Play("Walk");
                    }
                }
                else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
                {
                    reverse = true;
                    anim.Play("Run"); 
                }
            }

            // Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            // RaycastHit Hit;
            // if (Physics.Raycast(ray, out Hit))
            // {
            //     modelName = Hit.transform.name.ToString();
            //     if (modelName == "Naruto") {
            //         if (anim.GetCurrentAnimatorStateInfo(0).IsName("_Idle")) 
            //         {
            //             reverse = false;
            //             anim.Play("Walk");
            //         }
            //         else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk")) 
            //         {
            //             if (reverse == false) 
            //             {
            //                 anim.Play("Run"); 
            //             }
            //             else 
            //             {
            //                 anim.Play("_Idle");
            //             }
            //         }
            //         else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run"))
            //         {
            //             if (reverse == false) 
            //             {
            //                 anim.Play("Dash"); 
            //             }
            //             else 
            //             {
            //                 anim.Play("Walk");
            //             }
            //         }
            //         else if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dash"))
            //         {
            //             reverse = true;
            //             anim.Play("Run"); 
            //         }
            //     }
            // }
        } 
    }
}