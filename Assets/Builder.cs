using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{

    public void construct(GameObject target)
    {
        Debug.Log("CONSTRUCT CALLED: "+target.name);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
