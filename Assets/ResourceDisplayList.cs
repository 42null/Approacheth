using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ResourceDisplayList : MonoBehaviour
{
    public GameObject displayPaneArea;
    public GameObject resourceBoxPrefab;
    public GameObject itemHolder;

    public ResourceHolder DisplayResources { get; set; }
    
    public ResourceDisplayList(ResourceHolder displayResources)
    {
        this.DisplayResources = displayResources;
    }
    
    void Start()
    {
        // displayResources = NaturalResourceGen.generateResources(NaturalResourceGen.BodyType.ASTROID_TYPE_M, 2_000);

        int index = 0;
        float widthOfScrollOffset = (itemHolder.GetComponent<RectTransform>().rect.width / 2) - (resourceBoxPrefab.GetComponent<RectTransform>().rect.width / 2);

        // var sortedByAmount = new SortedList<Resource, float>(DisplayResources.getResouces().OrderByDescending(r => r.Value).ToDictionary(r => r.Key, v => v.Value));
        var sortedByAmount = DisplayResources.getResouces();

        foreach (var resource in sortedByAmount)
        {
            GameObject resourceBox = Instantiate(resourceBoxPrefab, this.gameObject.transform.position + new Vector3((index++)*100- widthOfScrollOffset, 0, 0), Quaternion.identity, itemHolder.transform) as GameObject;
            resourceBox.GetComponent<ResourceOptionDisplay>().resourceShown = resource.Key;
            resourceBox.GetComponent<ResourceOptionDisplay>().resourceAmountMegatonnes = resource.Value;

            
            // resourceBox.getComponent*().GetComponent<TextMeshProUGUI>().text = resourceShown.name;
            // textResourceSymbol.GetComponent<TextMeshProUGUI>().text = resourceShown.symbol;
            // textResourceAmount.GetComponent<TextMeshProUGUI>().text = Units.format(resourceAmountMegatonnes, Units.Unit.MEGATONNE);
        }


        Window preCreatedParentWindow = null;
        this.gameObject.transform.parent.parent.TryGetComponent<Window>(out preCreatedParentWindow);
        if (preCreatedParentWindow != null)
        {
            preCreatedParentWindow.updateHeight();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
