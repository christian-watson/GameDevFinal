using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bossPrefab, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
