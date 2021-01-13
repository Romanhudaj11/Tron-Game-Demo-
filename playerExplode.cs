using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerExplode : MonoBehaviour
{
    public GameObject fragmentedCube;

    RenderBuffer playerRigidBody; 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Vector3 finalVelocity = GetComponent<Rigidbody>().velocity;

            GameObject deadPlayer = Instantiate(fragmentedCube, gameObject.transform.position, gameObject.transform.rotation);

            deadPlayer.GetComponent<Rigidbody>().velocity = finalVelocity; 
            
            Destroy(gameObject); 
        }
    }
}
