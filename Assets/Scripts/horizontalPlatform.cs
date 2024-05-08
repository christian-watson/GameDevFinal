using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class horizontalPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;

    public Transform endPoint;

    public float speed = 1.5f;

    int direction = 1;

    private void OnDrawGizmos()
    {
        if(platform!=null && startPoint!=null && endPoint!=null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         Vector2 target = currentMovementTarget();

         platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

         float distance = (target - (Vector2)platform.position).magnitude;

         if(distance <= 0.1f)
         {
            direction *= -1;
         }
    }

    Vector2 currentMovementTarget()
    {
        if (direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

  
}
