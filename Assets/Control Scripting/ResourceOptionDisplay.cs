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
    [SerializeField] public float resourceAmountMegatonnes = 200f;
    

    public ResourceOptionDisplay()
    {
    }

    public void setBackgroundSelected()
    {
        
    }
    
    public void click()
    {
        // constructorMenu.select(this);
        // GetComponent<Image>().color = onHighlightColor;//new Color(onHighlightColor.r, onHighlightColor.g, onHighlightColor.b, onHighlightColor.a);

    }

    public void setBackgroundSelected(bool selected)
    {
        // if (selected)
        // {
        //     GetComponent<Image>().color = onHighlightColor;//new Color(onHighlightColor.r, onHighlightColor.g, onHighlightColor.b, onHighlightColor.a);
        // }
        // else
        // {
        //     GetComponent<Image>().color = defaultColor;//new Color(defaultColor.r, defaultColor.g, defaultColor.b, defaultColor.a);
        // }
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
