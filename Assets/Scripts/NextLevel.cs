using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{


    [SerializeField] public static int doorNum = 1;

    private Vector2 startPos = new Vector2(-10,-4);

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print(doorNum);
            while(doorNum < 5){
                Vector2 adjustedPos = new Vector2((80 * doorNum), 0) + startPos;
                doorNum++;
                print(adjustedPos);
                other.gameObject.transform.position = adjustedPos;
                break;
            }
        }
        
    }

}
