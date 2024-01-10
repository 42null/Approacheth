using System;
using System.Collections;
using System.Collections.Generic;
using SolarBodies;
using Unity.VisualScripting;
using UnityEditor.TextCore.Text;
using UnityEngine;
using UnityEngine.UI;

public class OrbitalBody : MonoBehaviour
{
    private List<KeyValuePair<GameObject, float>> orbiters = new List<KeyValuePair<GameObject, float>>();

    [SerializeField] [Range(0f, 10f)] public float scale = 1f;
    
    
    private ResourceHolder resourceHolder;
    private float orbitingAtAngle = 0;
    
    private Transform transform = new RectTransform();

    public float getAngle()
    {
        return orbitingAtAngle;
    }
    public float addToAngle(float angle)
    {
        return this.orbitingAtAngle += angle;
    }
    
    public OrbitalBody()
    {
        this.resourceHolder = NaturalResourceGen.generateResources(NaturalResourceGen.BodyType.STAR, scale);
    }


    public void addOrbiter(GameObject newOrbiter)
    {
        this.transform = GetComponent<Transform>();
        float orbiterDistance = (newOrbiter.transform.position - this.transform.position).magnitude;

        orbiters.Add(new KeyValuePair<GameObject, float>(newOrbiter, orbiterDistance));
    }
    
    private void OnValidate()
    {
        // this.transform.localScale = new Vector3(scale/10, scale/10, 1);
    }
    void Start()
     {

     }

    // Update is called once per frame
    void Update()
    {

        foreach (var orbiter in orbiters)
        {
            //TODO: Fix constent grabbing of GetComponent
            OrbitalBody orbitalBodyScript = orbiter.Key.GetComponent<OrbitalBody>();
            orbitalBodyScript.addToAngle(Time.deltaTime);
            orbiter.Key.transform.position = OrbitalMechanics.CaculateNewPos(orbiter.Key,this.transform.gameObject, orbitalBodyScript.getAngle(), orbiter.Value);
            
        }

    }
    
    
}