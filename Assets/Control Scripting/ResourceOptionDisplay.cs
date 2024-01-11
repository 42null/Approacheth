using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResourceOptionDisplay : MonoBehaviour
{
    [SerializeField] public GameObject textResourceName;
    [SerializeField] public GameObject textResourceSymbol;
    [SerializeField] public GameObject textResourceAmount;

    [SerializeField] public Resource resourceShown;
    [SerializeField] public float resourceAmountMegatonnes = 0;
    

    public ResourceOptionDisplay()
    {
    }

    public void setBackgroundSelected()
    {
        
    }
    
    public void click()
    {
        // constructorMenu.select(this);
    }

    public void setBackgroundSelected(bool selected)
    {
    }
    
    void Start()
    {
        textResourceName.GetComponent<TextMeshProUGUI>().text = resourceShown.name;
        textResourceSymbol.GetComponent<TextMeshProUGUI>().text = resourceShown.symbol;
        textResourceAmount.GetComponent<TextMeshProUGUI>().text = Units.format(resourceAmountMegatonnes, Units.Unit.MEGATONNE);
    }

    public void updateTargetAttributes()//TODO: Merge with assignment of targetSystemObject
    {

        
    }

    void Update()
    {
    }
}
