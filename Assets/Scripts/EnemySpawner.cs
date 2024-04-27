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
        EnemySpawnerObj.transform.position += victor3 + new Vector3(AdjustXPos, 0.0f, 0.0f);
        GameObject newEnemy = Instantiate(prefab, EnemySpawnerObj.transform);
        print(EnemySpawnerObj.transform.position);
        print(newEnemy.transform.position);
        newEnemy.SetActive(true);
        prefab.SetActive(false);
    }
}
