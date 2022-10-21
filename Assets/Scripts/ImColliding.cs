using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImColliding : MonoBehaviour
{
    bool isCurrentlyColliding;

    private void Update()
    {
        if (isCurrentlyColliding)
        {
            transform.position = new Vector3(Random.Range(-20, 20) - Random.Range(-5, 5), 2.5f, Random.Range(-20, 20) - Random.Range(-5, 5));
            isCurrentlyColliding = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Enemy")
        {
            isCurrentlyColliding = true;
            
        }
    }
}
