using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColRot : MonoBehaviour
{
    public float time=20; 
    
    void Update()
    {
        transform.Rotate(new Vector3(15,30,45)*Time.deltaTime);
        if(time > 0){
            time -= Time.deltaTime;
        }else{
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {

        // if(other.gameObject.CompareTag("Obstacle")){
        //     Destroy(this.gameObject);
        // }
        if(other.gameObject.CompareTag("Spawner")){
            Destroy(this.gameObject);
        }
    }
}
