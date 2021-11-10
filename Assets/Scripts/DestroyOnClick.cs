using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    public GameObject obj;

    public void OnButtonPress(){
        if (obj == true)
        {
            Destroy(this.obj);
        }
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
