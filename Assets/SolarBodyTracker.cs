using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarBodyTracker : MonoBehaviour
{
    //TODO: Rework to not use static and have a new instance for every system when that occurs.
    [SerializeField] public GameObject primaryBody; 
    //Will make a different system but right now, larger bodies (planets) will not require sending a probe first and it will be seperated in a better way. 
    [SerializeField] public List<GameObject> planets = new List<GameObject>(){}; 
    [SerializeField] public List<GameObject> astroids = new List<GameObject>(){};
    
    [SerializeField] public List<GameObject> buildables = new List<GameObject>(){};

    public List<GameObject> getSolarTargets()
    {
        List<GameObject> allSolarObjects = new List<GameObject>(){ primaryBody };
        allSolarObjects.AddRange(planets);
        allSolarObjects.AddRange(astroids);
        return allSolarObjects;
    }
    public List<GameObject> getConstructionTargets()
    {
        return buildables;
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
