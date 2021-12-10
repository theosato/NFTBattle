using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetMonster : MonoBehaviour
{
    public GameObject obj_on;
    public GameObject obj_off1;
    public GameObject obj_off2;

    public void OnButtonPress(){
        obj_on.SetActive(true);
        obj_off1.SetActive(false);
        obj_off2.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
  
    }
}
