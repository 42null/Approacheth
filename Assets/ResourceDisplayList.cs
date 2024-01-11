using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResourceDisplayList : MonoBehaviour
{
    public GameObject displayPaneArea;
    public GameObject resourceBoxPrefab;
    public GameObject itemHolder;

    private ResourceHolder displayResources;


    void Start()
    {
        displayResources = NaturalResourceGen.generateResources(NaturalResourceGen.BodyType.ASTROID_TYPE_M, 2_000);

        int index = 0;
        float widthOfScrollOffset = (itemHolder.GetComponent<RectTransform>().rect.width / 2) - (resourceBoxPrefab.GetComponent<RectTransform>().rect.width / 2);
        foreach (var resource in displayResources.getResouces())
        {
            Debug.Log("widthOfScroll - "+widthOfScrollOffset);
            GameObject resourceBox = Instantiate(resourceBoxPrefab, this.gameObject.transform.position + new Vector3((index++)*100- widthOfScrollOffset, 0, 0), Quaternion.identity, itemHolder.transform) as GameObject;
            resourceBox.GetComponent<ResourceOptionDisplay>().resourceShown = resource.Key;
            resourceBox.GetComponent<ResourceOptionDisplay>().resourceAmountMegatonnes = resource.Value;

            
            // GameObject newPlayer = Instantiate(Resources.Load("Player", typeof(GameObject))) as GameObject;
            
            // resourceBox.getComponent*().GetComponent<TextMeshProUGUI>().text = resourceShown.name;
            // textResourceSymbol.GetComponent<TextMeshProUGUI>().text = resourceShown.symbol;
            // textResourceAmount.GetComponent<TextMeshProUGUI>().text = Units.format(resourceAmountMegatonnes, Units.Unit.MEGATONNE);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
