using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadMover : MonoBehaviour
{

    public GameObject player;
    public GameObject mountain;

    float z_old;
    public static float z_max = 0;

    public static float spawner = 0;
   // private Vector3 offset;
    void Start()
    {
        //offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {   
        z_old = this.gameObject.transform.position.z;

        if(player.transform.position.z > z_old){
        transform.position = new Vector3(0,0,player.transform.position.z);
        }

        if(player.transform.position.z > z_max){
            z_max = player.transform.position.z;

        }

        if(z_max >= spawner){
            spawner += 620;
            GameObject mont = Instantiate(mountain) as GameObject;
            mont.transform.position = new Vector3(0f,-265f,spawner+170f);
        }

    }
}
