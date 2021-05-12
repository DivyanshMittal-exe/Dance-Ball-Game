using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;


public class Movement : MonoBehaviour
{
    public static float score = 0;
    private float movx;
    private float movy;

    public GameObject SlowDown;
    public GameObject Parts;


    public AudioSource audioSourceG;

    public AudioSource prizesound;
    public AudioSource obsSound;

    public static bool powerAct = false;

    public float resetTime = 10.0f;

    private float timeManage;
    public float powerTime = 1.0f;
    private float powerManage;
    public float speedmax = 30;
    //public float jump = 1000;
    public float gravity = 8;
    public float speed = 1000;
    public float speedup = 400;
    private Rigidbody rigid;


    

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        timeManage = resetTime;
        powerManage = powerTime;
        
    }

    void OnMove(InputValue movementValue){
        Vector2 movementvec = movementValue.Get<Vector2>();
        movx = movementvec.x;
        movy = movementvec.y;

    }
    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && (this.gameObject.transform.position.y < 1.36 && this.gameObject.transform.position.y > 1)){
            rigid.AddForce(new Vector3(0,600,0));

            Debug.Log("Spaced");
        }

        Vector3 fdir;
        if(rigid.velocity.z < speedmax || movy < 0){
         fdir = new Vector3(movx,0f,movy);
        }else{
         fdir = new Vector3(movx,0f,0f);
        }
        rigid.AddForce(fdir*speed*Time.deltaTime);
        rigid.AddForce(new Vector3(0,-gravity,0));
// 
       
    }

    private void OnTriggerEnter(Collider other) {
        
        
        if(other.gameObject.CompareTag("Collectible")){
            GameObject partics = Instantiate(Parts) as GameObject;
            partics.transform.position = other.gameObject.transform.position;
            Destroy(other.gameObject);
            score+=10;
            prizesound.Play();
        }
        if(other.gameObject.CompareTag("Obstacle")){
            Destroy(other.gameObject);
            score -= 5;
            obsSound.Play();
        }
        
    }

    void UsePower(){
        powerAct = true;
        powerManage = powerTime;
        Time.timeScale = 0.5f;
        audioSourceG.pitch = 0.5f;
        SlowDown.SetActive(true);

    }
    void Update() {
        if(Input.GetKeyDown(KeyCode.CapsLock)){
            if(timeManage <= 0 ){
                UsePower();
                timeManage = resetTime + powerTime;
            }
        }
        if(powerAct == true){
        if(powerManage > 0){
            powerManage -= Time.deltaTime;
        }else{
            powerAct = false;
            Time.timeScale = 1f;
            audioSourceG.pitch = 1f;
            SlowDown.SetActive(false);
        }

         
        }

        if(timeManage > 0){
            timeManage -= Time.deltaTime;
        }


            if(this.gameObject.transform.position.y < -20){
                SceneManager.LoadScene(3);
            }
    }
}
