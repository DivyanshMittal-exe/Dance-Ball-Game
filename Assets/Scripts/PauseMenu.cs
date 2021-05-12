using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public static bool GamePause = false;
    public GameObject PauseMenuUI;

        public AudioSource audioSourceG;
    public AudioSource audioSourceP;



    public void MainMenuPause(){
        Debug.Log("Quit");
        
        SceneManager.LoadScene(0);

        Time.timeScale = 1.0f;
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(GamePause){
                resume();
            }else{
                pause();
            }
        }
    }
    void pause(){
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GamePause = true;
        audioSourceG.Pause();
        audioSourceP.Play();
    }
    void resume(){
        PauseMenuUI.SetActive(false);
        if(Movement.powerAct == true){
            Time.timeScale = 0.5f;
        }else {
            Time.timeScale = 1f;
        }
        
        GamePause = false;
        audioSourceG.Play();
        audioSourceP.Pause();
    }



    public void VolumeisSet(float vol){
       audioMixer.SetFloat("VolumePara",vol);
    }
}
