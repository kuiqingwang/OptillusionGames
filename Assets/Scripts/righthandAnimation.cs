using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class righthandAnimation : MonoBehaviour
{
    public GameObject runLittleManAnimation;
    public PlayableDirector timeline;
        public float reversespeed;
    void pause(){
        Animator runLittleMan = runLittleManAnimation.GetComponent<Animator>();
        Animator rightHand = this.GetComponent<Animator>();
        runLittleMan.SetFloat("speed",0);
        rightHand.SetBool("pause",true);
        Debug.Log("pause");
    }
    void reverse(){
        Animator runLittleMan = runLittleManAnimation.GetComponent<Animator>();
        runLittleMan.SetFloat("speed",-2.0f);
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(reversespeed);
        Debug.Log("reverse");
    }
    void pauseFinish(){
        Animator rightHand = this.GetComponent<Animator>();
        rightHand.SetBool("pause",false);
    }
}
