using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{


    [SerializeField] public static int doorNum = 1;

    private Vector2 startPos = new Vector2(-10,-4);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Scene_Two");
        }
        
    }

}
