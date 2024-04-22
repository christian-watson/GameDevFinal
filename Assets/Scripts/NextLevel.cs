using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{

    public static int doorNum = 1;
    private Vector2 startPos = new Vector2(-10,-4);

    void Start(){
        private string nextStage = SceneManager.GetActiveScene().name;
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print(doorNum);
            if(doorNum >= 5){
                if(nextStage == "Scene_One"){
                    print("howdy");
                }
            }
            while(doorNum < 5){
                Vector2 adjustedPos = new Vector2((80 * doorNum), 0) + startPos;
                doorNum++;
                print(adjustedPos);
                other.gameObject.transform.position = adjustedPos;
                break;
            }
        }
        
    }

}
