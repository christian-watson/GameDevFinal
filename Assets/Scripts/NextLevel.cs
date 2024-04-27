using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{


    public static int doorNum = 1;

    public Vector2 startPos = new Vector2(-10,-4);
    private static string sceneName;
    private static Scene currentScene;
    public EnemySpawner enemySpawnerObj;
    public GameObject prefab;



    void Start(){
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        print(currentScene);
        enemySpawnerObj = (GameObject.Find("EnemySpawnerObject")).GetComponent<EnemySpawner>();
         prefab = GameObject.Find("Enemy");
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
                enemySpawnerObj.SpawnEnemy(0.0f);
                print("did it spawn");
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

    void Update(){
    }

    public float GetSpawnPosX(){
        return (80 * doorNum) + startPos.x;
    }

}
