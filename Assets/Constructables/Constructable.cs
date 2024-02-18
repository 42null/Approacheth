using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constructable : MonoBehaviour
{
    public ResourceHolder requiredToMake = new ResourceHolder(new SortedList<Resource, float>()
    {
        { ResourceHolder.Iron, 0.03f},
        { ResourceHolder.Hydrogen, 0.06f},
        { ResourceHolder.Oxygen, 0.06f},
    });
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
