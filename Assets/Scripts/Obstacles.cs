using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public GameObject[] obstacle;
    public GameObject prize;
    public GameObject player;
    float offset;
    public static float speed = 100;
    public  float speedup = 30;

    public float spawnTime = 0.5f;
    public float spawnDelay = 3.0f;


    void speed_inc(){
        speed += speedup;
    }
    void obs(){
        for(int i = 0; i< 8;i++){
            int ch = Random.Range(0,10);
            if(ch > 5){
                int index = Random.Range(0,7);
                GameObject coll = Instantiate(obstacle[index]) as GameObject;
                coll.transform.position = new Vector3(2*(i-4),1.5f,offset+170);
                coll.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed);
                coll.GetComponent<Rigidbody>().mass = Random.Range(1,7);
            }
        }

    }

    void poi(){
        int tot = Random.Range(0,6);
        int location = Random.Range(0,8-tot);
        for(int i = 0; i< location;i++){
            GameObject coll = Instantiate(prize) as GameObject;
            coll.transform.position = new Vector3(2*(i)-5,2,offset+170);
            coll.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed);
        }
    }
    void create(){
        int dec = Random.Range(0,2);
        if (dec == 0){
                poi();
            }else
            {
                obs();
            }
    }

    void Start()
    {
        InvokeRepeating ("create", spawnTime, spawnDelay);
        InvokeRepeating ("speed_inc", 11, 112);
        InvokeRepeating ("speed_inc", 22, 224);
        InvokeRepeating ("speed_inc", 38, 112);
        InvokeRepeating ("speed_inc", 92, 112);
    }

    // Update is called once per frame
    void Update()
    {
       offset = player.transform.position.z; 
    }
}
