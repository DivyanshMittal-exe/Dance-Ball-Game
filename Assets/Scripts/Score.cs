using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    float finalScore;
    public Text scoreTxt;

    // Update is called once per frame
    void Update()
    {
        finalScore = (RoadMover.z_max) *0.1f + Movement.score;
        scoreTxt.text = finalScore.ToString("0");
    }
}
