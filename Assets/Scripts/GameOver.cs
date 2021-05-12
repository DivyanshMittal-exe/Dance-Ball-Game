using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class GameOver : MonoBehaviour
{
    bool gameEnded  = false;
    public float TimeDelayQuit = 1.0f;
    public void FinGame(){
        if(gameEnded == false){
            gameEnded = true;
            Invoke("EndMenu", TimeDelayQuit);
        }
    }

    void EndMenu(){
        SceneManager.LoadScene(3);
    }
}
