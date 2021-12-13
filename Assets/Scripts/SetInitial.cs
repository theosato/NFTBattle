using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInitial : MonoBehaviour
{
    public GameObject obj_on;
    public GameObject obj_off1;
    public GameObject obj_off2;

    // Start is called before the first frame update
    void Start()
    {
        obj_on.SetActive(true);
        obj_off1.SetActive(false);
        obj_off2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
