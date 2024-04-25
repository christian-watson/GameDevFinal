using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public NewScene ChangeLevelObj;
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        prefab = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void SpawnEnemy(){
        Instantiate(prefab);
    }
}
