using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;
    public Transform target;
    private Vector2 VectorTarget;
    private Vector2 position;

    public Vector3 playerLocation = new Vector3(0,0,0);

    private void GoToPlayer(){
        Vector3 playerLocation = target.transform.position;
        if(target.transform.position.x > transform.position.x){
            position.x += speed * Time.deltaTime;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GoToPlayer();
    }
}
