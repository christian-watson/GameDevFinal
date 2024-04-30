using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{


    public static int doorNum = 0;

    public Vector2 startPos = new Vector2(-10,-4);
    private static string sceneName;
    private static Scene currentScene;
    public EnemySpawner enemySpawnerObj;
    public GameObject prefab;



    void Start(){
        currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        enemySpawnerObj = (GameObject.Find("EnemySpawnerObject")).GetComponent<EnemySpawner>();
        prefab = GameObject.Find("Enemy");
        LevelSpawnEnemy();
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
                enemySpawnerObj.SpawnEnemy(10.0f);
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

    private void LevelSpawnEnemy(){
        if(doorNum < 1){
            enemySpawnerObj = (GameObject.Find("EnemySpawnerObject")).GetComponent<EnemySpawner>();
            enemySpawnerObj.SpawnEnemy(5.0f);
            doorNum++;
        }
    }

    void Update(){
        currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "DeathScreen"){
            doorNum = 0;
        }
    }

    public float GetSpawnPosX(){
        return (80 * doorNum) + startPos.x;
    }

}
