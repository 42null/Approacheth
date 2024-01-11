using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InnerContentContent : MonoBehaviour
{
    [SerializeField] public GameObject contentHeldInSpace;

    public List<GameObject> getInnerContentChildren()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in contentHeldInSpace.transform)
        {
            children.Add(child.gameObject);
        }
        return children;
    }
    
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
