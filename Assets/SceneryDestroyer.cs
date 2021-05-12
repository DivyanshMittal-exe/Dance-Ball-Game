using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneryDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject player;


    // Update is called once per frame
    void Update()
    {
        if((RoadMover.z_max - this.gameObject.transform.position.z) > 800){
            Destroy(this.gameObject);
        }    
    }
}
