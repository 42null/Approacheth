using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TargetOptionDisplay : MonoBehaviour
{
    [SerializeField] public GameObject targetSystemObject;
    [SerializeField] public Image icon;
    [SerializeField] public GameObject title;
    [SerializeField] public ConstructMenu constructorMenu;

    [SerializeField] public Color defaultColor = new Color(0.8f, 0.8f, 0.8f, 1f);
    [SerializeField] public Color onHighlightColor = new Color(1f, 1f, 1f, 1f);
    
    public TargetOptionDisplay()
    {
    }

    public void setBackgroundSelected()
    {
        
    }
    
    public void click()
    {
        constructorMenu.select(this);
        GetComponent<Image>().color = onHighlightColor;//new Color(onHighlightColor.r, onHighlightColor.g, onHighlightColor.b, onHighlightColor.a);

    }

    public void setBackgroundSelected(bool selected)
    {
        if (selected)
        {
            GetComponent<Image>().color = onHighlightColor;//new Color(onHighlightColor.r, onHighlightColor.g, onHighlightColor.b, onHighlightColor.a);
        }
        else
        {
            GetComponent<Image>().color = defaultColor;//new Color(defaultColor.r, defaultColor.g, defaultColor.b, defaultColor.a);
        }
    }
    
    void Start()
    {
        
    }

    public void updateTargetAttributes()//TODO: Merge with assignment of targetSystemObject
    {
        this.icon.sprite = targetSystemObject.GetComponent<SpriteRenderer>().sprite;
        this.title.GetComponent<TextMeshProUGUI>().text = targetSystemObject.name;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
