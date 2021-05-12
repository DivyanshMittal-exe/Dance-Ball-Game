using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obs_Cont : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-Obstacles.speed);
        if(this.gameObject.transform.position.y < 0){
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Spawner")){
            Destroy(this.gameObject);
        }
    }
}
