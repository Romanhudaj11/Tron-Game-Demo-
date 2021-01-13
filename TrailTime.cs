using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailTime : MonoBehaviour
{
    public float trailTime; 

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TrailRenderer>().time = trailTime; 
    }
}
