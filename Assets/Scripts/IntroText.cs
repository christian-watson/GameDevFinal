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

    public GameObject prefab;
    public GameObject spawnerObj;
    GameObject Enemy1;
    public GameObject theButton;
    public GameObject NextLevelObj;
    // Start is called before the first frame update
    void Start()
    {
        Enemy1 = Instantiate(prefab, spawnerObj.transform);
    }

    // Update is called once per frame
    void Update()
    { 
        ChangeFirstText();
        ChangeSecondText();
        ChangeThirdText();
        nextScene();
    }

    private void ChangeFirstText(){
        if(textNum == 0){
            if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
                PressedA = true;
            }
            if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
                PressedD = true;
            }
            if(PressedA && PressedD){
                textObj.text = "Very good! Now press space to jump!";
                textNum ++;
            }
        }
    }

    private void ChangeSecondText(){
        if(textNum == 2){
        if(Input.GetKeyDown(KeyCode.Space)){
            textObj.text = "Good Job! Now jump on the platforms to make it to the end of the level!";
            textNum++;
        }
    }
    }

    private void ChangeThirdText(){
        if(textNum == 1){
            if(Input.GetKeyDown(KeyCode.Space)){
                textNum++;
                textObj.text = "Try double jumping!";
            }
        }
        }
    
    private void OnCollisionEnter2D(Collision2D other){
        if(textNum == 3){
            if (other.gameObject.CompareTag("Player")){
                other.gameObject.transform.position = new Vector3(65.0f, -5.0f, 0f);
                Enemy1.SetActive(true);
                textObj.text = "Press R to damage the enemy!";
                textNum++;
                NextLevelObj.transform.position += new Vector3(20.0f, 0, 0);
                
            }
        }
    }

    private void nextScene(){
        if(textNum == 4){
            if(!(Enemy1.activeInHierarchy)){
            textObj.text = "Press the button in the bottom right to play level 1!";
            theButton.SetActive(true);
        }
        }
    }
}
