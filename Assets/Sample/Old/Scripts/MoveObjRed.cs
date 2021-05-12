using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MoveObjRed : MonoBehaviour
{
    //public float speed = 10.0f;
    //public AudioMixer audioMixer;
    public AudioSource audioSource;
    void Start()
    {
        // transform.Rotate(new Vector3(0,0,orientation*90));
        //box.velocity = new Vector3(0,0,-speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.transform.position.z > 0){
        audioSource.Play(0);
        }
    }
}
