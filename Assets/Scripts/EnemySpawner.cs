using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject prefab;
    public NextLevel MrObjectMan;

    public GameObject EnemySpawnerObj;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }  

    public void SpawnEnemy(float AdjustXPos){
        float xSpawnPos = MrObjectMan.GetSpawnPosX();
        Vector3 victor3 = new Vector3 (80.0f, 0, 0.0f);
        EnemySpawnerObj.transform.position += victor3;
        GameObject newEnemy1 = Instantiate(prefab, EnemySpawnerObj.transform);
        EnemySpawnerObj.transform.position += new Vector3(AdjustXPos, 0.0f, 0.0f);
        GameObject newEnemy2 = Instantiate(prefab, EnemySpawnerObj.transform);
        EnemySpawnerObj.transform.position -= new Vector3(AdjustXPos, 0.0f, 0.0f);
        newEnemy1.SetActive(true);
        newEnemy2.SetActive(true);
        prefab.SetActive(false);
    }
}
