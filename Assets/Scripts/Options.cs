using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;


public class Options : MonoBehaviour
{
    public AudioMixer audioMixer;

    public TMPro.TMP_Dropdown resDropDown;
    Resolution[] resolutions;

    void Start(){
       resolutions = Screen.resolutions;
       resDropDown.ClearOptions();
       List<string> options = new List<string>();

       int resind = 0;
       for(int i = 0; i < resolutions.Length;i++){
           string option = resolutions[i].width + "x" + resolutions[i].height ;
           options.Add(option);

           if(resolutions[i].width ==  Screen.currentResolution.width && resolutions[i].height ==  Screen.currentResolution.height){
               resind = i;
           }
       }
       resDropDown.AddOptions(options);
       resDropDown.value = resind;
       resDropDown.RefreshShownValue();
    }

    public void MainMen(){
        SceneManager.LoadScene(0);
    }
    public void RessSet(int resset){
        Resolution reso = resolutions[resset];
        Screen.SetResolution(reso.width,reso.height,Screen.fullScreen);
    }
    
    public void VolumeSet(float vol){
       audioMixer.SetFloat("VolumePara",vol);
    }
    public void QualitySet(int qlty){
       QualitySettings.SetQualityLevel(qlty);
    }

    public void FSSet(bool fs){
       Screen.fullScreen = fs;
    }

    
}
