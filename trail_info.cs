using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trail_info : MonoBehaviour
{
    TrailRenderer renderTrail;

    public GameObject cubeCollider;

    public GameObject colliderFolder; 

    int numVertices = 0;

    List<GameObject> boxColliders = new List<GameObject>(); 

    Vector3 offset = new Vector3(90, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        renderTrail = GetComponent<TrailRenderer>();
    }

    int pauseCount = 0;
    const int NUM_FRAMES_PAUSED = 10; 

    // Update is called once per frame
    void Update()
    {
        numVertices = renderTrail.positionCount;

        if (numVertices > 20)
        {
            pauseCount++;

            int numAdded = 0;

            //place them every 10 frames
            if(pauseCount >= NUM_FRAMES_PAUSED)
            {
                Vector3 targetDirection = transform.position - renderTrail.GetPosition(numVertices - 10);

                boxColliders.Add(Instantiate(cubeCollider, renderTrail.GetPosition(numVertices - 10), Quaternion.LookRotation(targetDirection), colliderFolder.transform)); 

                numAdded++;

                pauseCount = 0; 
            }

            if (boxColliders.Count >= 57)
            {
                Destroy(boxColliders[0]);
                boxColliders.RemoveAt(0);
            }
        }
    }
}
 