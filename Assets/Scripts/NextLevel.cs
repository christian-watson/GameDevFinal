using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{


    public static int doorNum = 1;

    private Vector2 startPos = new Vector2(-10,-4);
    private static string sceneName;
    private static Scene currentScene;


    void Start(){
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        print(currentScene);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(doorNum < 5){
                Vector2 adjustedPos = new Vector2((80 * doorNum), 0) + startPos;
                doorNum++;
                print(adjustedPos);
                other.gameObject.transform.position = adjustedPos;
            }
            else{
                print(sceneName);
                doorNum = 0;
                if(sceneName == "Scene_One"){
                    SceneManager.LoadScene("Scene_Two");
                }
            }
        }
        
    }

}
