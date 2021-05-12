using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Spawn : MonoBehaviour
{
    public GameObject RedBox;
    public GameObject BlueBox;
    //public Transform redtrans;
    //public Transform bluetrans;
    //public GameObject[] listBlocks;
    public List<GameObject> blocks = new List<GameObject>();
    public List<int> orie = new List<int>();
    public float spawnTime = 1.0f;
    public float spawnDelay = 1.0f;
    public static int score = 0;
    // private Score newScore;
    // int counter = 0;
    public float speed = 100.0f;

    public float speedup = 10.0f;
    public GameObject dest_Red;
    public GameObject dest_Blue;
    

    private void spawnRed(int orientation){

        // listBlocks = new GameObject[i];
        GameObject rd = Instantiate(RedBox) as GameObject;
        rd.transform.position = new Vector3(3.75f,5,25);
        rd.transform.Rotate(new Vector3(0,0,orientation*90));
        rd.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed);
        blocks.Add(rd);
        orie.Add(orientation);
    }
    private void spawnBlue(int orientation){
        // listBlocks = new GameObject[i];
        GameObject blue = Instantiate(BlueBox) as GameObject;
        blue.transform.position = new Vector3(-3.75f,5,25);
        blue.transform.Rotate(new Vector3(0,0,orientation*90));
        blue.GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed);
        blocks.Add(blue);
        orie.Add(orientation + 4);
    }

    // void spawn(){
    //     int dec = Random.Range(0,2);
    //     int rtr = Random.Range(0,4);
    //     if (dec == 0){
    //         spawnRed(rtr);
    //     }else
    //     {
    //         spawnBlue(rtr);
    //     }
    // }

    void speed_inc(){
        speed += speedup;
        for(int i =0; i < blocks.Count;i++){
            float mass = blocks[i].GetComponent<Rigidbody>().mass;
            blocks[i].GetComponent<Rigidbody>().velocity = new Vector3(0,0,-speed);
        }
    }


    void Start()
    {
        InvokeRepeating ("makeBlock", spawnTime, spawnDelay);
        InvokeRepeating ("speed_inc", 11, 112);
        InvokeRepeating ("speed_inc", 22, 224);
        InvokeRepeating ("speed_inc", 38, 112);
        InvokeRepeating ("speed_inc", 92, 112);
        // StartCoroutine(makeBlock());
        //Invoke("makeBlock", 1);
        // newScore = Object.FindObjectOfType<Score> ();
    }

    void makeBlock(){
        
        
            
            // yield return new WaitForSeconds(spawnDelay);
            int dec = Random.Range(0,2);
            int rtr = Random.Range(0,4);
            
            if (dec == 0){
                spawnRed(rtr);
            }else
            {
                spawnBlue(rtr);
            }
            //counter = counter + 1;
            
            
        
    }

    void GameEnd(){
        SceneManager.LoadScene(3);
    }

    void Update(){

        
        // if(transform.childCount > 1){
        //             Destroy (GetComponent<Transform> ().GetChild (0).gameObject);
        //         }

        if(orie.Count>0){
        if((Input.GetKeyDown(KeyCode.W) && orie[0]==0)||(Input.GetKeyDown(KeyCode.A) && orie[0]==1)||(Input.GetKeyDown(KeyCode.S) && orie[0]==2)||(Input.GetKeyDown(KeyCode.D) && orie[0]==3)||(Input.GetKeyDown(KeyCode.UpArrow) && orie[0]==4)||(Input.GetKeyDown(KeyCode.LeftArrow) && orie[0]==5)||(Input.GetKeyDown(KeyCode.DownArrow) && orie[0]==6)||(Input.GetKeyDown(KeyCode.RightArrow) && orie[0]==7))
        {   
            if(orie[0] >3){
                Instantiate(dest_Blue,blocks[0].transform.position,blocks[0].transform.rotation);
            }else{
                Instantiate(dest_Red,blocks[0].transform.position,blocks[0].transform.rotation);
            }
            Destroy(blocks[0]);
            blocks.Remove(blocks[0]);
            orie.Remove(orie[0]);
            score += 10;
        }else if(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.D)||Input.GetKeyDown(KeyCode.S)||Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.W)){
            if(score > 0){
                score-=5;
            }
        }
        }
        // newScore.fetchScore(score);
        //scoreText.text = score.ToString();
        if(blocks.Count > 0){
            if(blocks[0].transform.position.z <= -25){
                for(int i =0; i < blocks.Count;i++){
                    Destroy(blocks[i]);
                    blocks.Remove(blocks[i]);
                    orie.Remove(orie[i]);
                }
                    Invoke("GameEnd",1.0f);
            }
        }
    }
}
