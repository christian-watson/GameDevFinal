using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public NextLevel MrObjectMan;

    public GameObject EnemySpawnerObj;

    private static int doorNum;
    private static Scene currentScene;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        if(currentScene.name == "DeathScreen"){
            EnemySpawnerObj.transform.position = new Vector2(-74.0f, 0.0f);
        }
    }  

    public void SpawnEnemy(float AdjustXPos){
        float xSpawnPos = MrObjectMan.GetSpawnPosX();
        Vector3 victor3 = new Vector3 (80.0f, 0, 0.0f);
        EnemySpawnerObj.transform.position += victor3;
        Vector3 AdjustedVector3 = new Vector3 (AdjustXPos, 0.0f,0.0f);
        GameObject newEnemy1 = Instantiate(prefab, EnemySpawnerObj.transform);
        GameObject newEnemy2 = Instantiate(prefab, EnemySpawnerObj.transform);
        newEnemy1.SetActive(true);
        newEnemy2.SetActive(true);
        prefab.SetActive(false);
        newEnemy2.transform.position = newEnemy1.transform.position + AdjustedVector3;
    }
}
