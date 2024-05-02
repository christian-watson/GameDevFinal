using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Threading;
public class IntroText : MonoBehaviour
{

    public Text textObj;

    private bool PressedA;
    private bool PressedD;

    public int textNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        ChangeFirstText();
        ChangeSecondText();
    }

    private void ChangeFirstText(){
        if(textNum == 0){
            if(Input.GetKeyDown(KeyCode.A)){
                PressedA = true;
            }
            if(Input.GetKeyDown(KeyCode.D)){
                PressedD = true;
            }
            if(PressedA && PressedD){
                textObj.text = "Very good! Now press space to jump!";
                textNum ++;
            }
        }
    }

    private void ChangeSecondText(){
        if(textNum == 1){
        if(Input.GetKeyDown(KeyCode.Space)){
            textObj.text = "Good Job! Now jump on the platforms to make it to the end of the level!";
        }
    }
    }
}
