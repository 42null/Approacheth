using System;
using System.Collections;
using System.Collections.Generic;
using SolarBodies;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEditor;

[System.Serializable]
public class OrbiterData
{
    public GameObject Orbiter;
    public float Distance = 0;
    
    // public GameObject Orbiter => orbiter;
    // public float Distance => distance;

    public OrbiterData(GameObject orbiter, float distance)
    {
        this.Orbiter = orbiter;
        this.Distance = distance;
    }

}

public class OrbitalBody : MonoBehaviour
{
    [SerializeField]
    public NaturalResourceGen.BodyType bodyType = NaturalResourceGen.BodyType.UNSET_DEFAULT;
    
    // [SerializeField] public List<KeyValuePair<GameObject, float>> orbiters = new List<KeyValuePair<GameObject, float>>();
    [SerializeField] public List<OrbiterData> orbiters = new List<OrbiterData>();

    [SerializeField] [Range(0f, 10f)] public float scale = 1f;
    
    
    private ResourceHolder resourceHolder;
    private float orbitingAtAngle = 0;
    
    private Transform transform;

    public float getAngle()
    {
        return orbitingAtAngle;
    }
    public float addToAngle(float angle)
    {
        return this.orbitingAtAngle += angle;
    }

    // public OrbitalBody()
    public OrbitalBody()
    {
    }

    // public SortedList<Resource,float> getResourses()
    public ResourceHolder getResourses()
    {
        return this.resourceHolder;
        // return resourceHolder.getResouces();
    }


    public void addOrbiter(GameObject newOrbiter)
    {
        this.transform = GetComponent<Transform>();
        float orbiterDistance = OrbitalMechanics.CalculateDistanceBetween(this.gameObject, newOrbiter);
        
        orbiters.Add(new OrbiterData(newOrbiter, orbiterDistance));
    }
    
    private void OnValidate()
    {
    
        // this.transform.localScale = new Vector3(scale/10, scale/10, 1);
    }
    void Start()
    {
        this.resourceHolder = NaturalResourceGen.generateResources(this.bodyType, scale);

        //TODO: Move to OnValidate to make show up in inspector?
        for(int i = 0; i < orbiters.Count; i++)
        {
            if (orbiters[i].Distance == 0)
            {
                orbiters[i].Distance = OrbitalMechanics.CalculateDistanceBetween(this.gameObject, orbiters[i].Orbiter);
            }
        }
    }
    
    // Update is called once per frame
    void Update()
    {

        foreach (var orbiter in orbiters)
        {
            //TODO: Fix constent grabbing of GetComponent
            OrbitalBody orbitalBodyScript = orbiter.Orbiter.GetComponent<OrbitalBody>();
            orbitalBodyScript.addToAngle(Time.deltaTime);
            orbiter.Orbiter.transform.position = OrbitalMechanics.CaculateNewPos(orbiter.Orbiter,this.gameObject, orbitalBodyScript.getAngle(), orbiter.Distance);
            
        }

    }
    
    
}