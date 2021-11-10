using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public GameObject modelFirst;
    private bool modelFirstBool;
    public GameObject modelSecond;
    private bool modelSecondBool;
    public ParticleSystem particles;

    public void OnButtonPress(){
        if (modelFirstBool == true)
        {
            modelFirst.SetActive(false);
            modelFirstBool = false;
            modelSecond.SetActive(true);
            modelSecondBool = true;
            if (particles) {
                particles.Play();
            }
        } 
        else if (modelSecondBool == true) 
        {  
            modelFirst.SetActive(true);
            modelFirstBool = true;
            modelSecond.SetActive(false);
            modelSecondBool = false;
            if (particles) {
                particles.Stop();
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        modelFirst.SetActive(true);
        modelFirstBool = true;
        modelSecond.SetActive(false);
        modelSecondBool = false;
        if (particles) {
            particles.Stop();
        }  
    }

    // Update is called once per frame
    void Update()
    {
        // if ((Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began) || (Input.GetKeyDown(KeyCode.Space)))
        // // if (Input.GetKeyDown(KeyCode.Space)) 
        // {
        //     if (modelFirstBool == true)
        //     {
        //         modelFirst.SetActive(false);
        //         modelFirstBool = false;
        //         modelSecond.SetActive(true);
        //         modelSecondBool = true;
        //         if (particles) {
        //             particles.Play();
        //         }
        //     } 
        //     else if (modelSecondBool == true) 
        //     {  
        //         modelFirst.SetActive(true);
        //         modelFirstBool = true;
        //         modelSecond.SetActive(false);
        //         modelSecondBool = false;
        //         if (particles) {
        //             particles.Stop();
        //         }
        //     }
        // } 
    }
}
