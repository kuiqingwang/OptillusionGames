using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
public class controller : MonoBehaviour
{
    public GameObject handAnimation;
    public GameObject bar;
    public GameObject runLittleManAnimation;
    public GameObject blackScene1;
    public GameObject countDownClockAnimation;
    public PlayableDirector timeline;
    bool unlock = false;
    public void playLittleMan(){
        Animator runLittleMan = runLittleManAnimation.GetComponent<Animator>();
        runLittleMan.SetTrigger("play");
    }
    IEnumerator fade(){
    for (float f = 1f; f>=0; f-=0.1f){
        Color c = blackScene1.GetComponent<Renderer>().material.color;
        c.a = f;
        blackScene1.GetComponent<Renderer>().material.color = c;
        //yield return null;
        yield return new WaitForSeconds(0.05f);
    }
    }
    public void bright(){
    StartCoroutine(fade());
}
    public void unlockMouseButton(){
        unlock=true;
    }
    public void levelfinish(){
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(0);
        Animator countDownClock = countDownClockAnimation.GetComponent<Animator>();
        countDownClock.SetBool("Win",true);
    }
    public void nextlevel(){
        timeline.playableGraph.GetRootPlayable(0).SetSpeed(1);
        Animator countDownClock = countDownClockAnimation.GetComponent<Animator>();
        countDownClock.SetBool("Win",false);
    }

    void Update()
    {
        Animator rightHand = handAnimation.GetComponent <Animator>();
        Animator runLittleMan = runLittleManAnimation.GetComponent<Animator>();
        bool pause=rightHand.GetBool("pause");
        if(unlock){
            if(!pause){
                bar.transform.Rotate(0,-10*Time.deltaTime,0);
            }
            else {
                timeline.playableGraph.GetRootPlayable(0).SetSpeed(0);
            }
            if (Input.GetMouseButtonDown(0)){
                rightHand.SetTrigger("play");
                Debug.Log("play");
            }
            if (Input.GetMouseButtonUp(0)){
                rightHand.SetTrigger("end");
                Debug.Log("end");
                runLittleMan.SetFloat("speed",1.0f);
                timeline.playableGraph.GetRootPlayable(0).SetSpeed(1);
            }
        }
    }
}
