using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    public  float lifetime = 5.0f;
    
    //public GameObject box;

    // Update is called once per frame
    void Update()
    {
        if(lifetime > 0){
            lifetime -= Time.deltaTime;
        }else{
            Destroy(this.gameObject);
        }
        
    }
}
