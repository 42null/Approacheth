using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using Object = UnityEngine.Object;

public class Window : MonoBehaviour
{
    [SerializeField] public GameObject content;
    [SerializeField] public GameObject closeIcon;
    [SerializeField] public GameObject shrinkIcon;
    [SerializeField] public GameObject contentListHolder;
    [SerializeField] public List<GameObject> contentItems = new List<GameObject>(){};

    private bool isShrunk = false; 
    
    void Start()
    {
    }

    void Update()
    {
        
    }

    public float updateHeight()
    {
        
        float totalHeight = 0;
        float previousHeight = 0;
        foreach(var contentItem in contentItems)
        {
            float height;
            try
            {
                height = UIHelpers.calculateSqueezedHeight(
                    contentItem.GetComponent<InnerContentContent>().getInnerContentChildren(), 5, 5);
            }
            catch (Exception e)
            {
                height = 200;
            }

            // Debug.Log(height+"____");
            contentItem.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
            contentItem.transform.localPosition = new Vector3(contentItem.transform.localPosition.x, -totalHeight, contentItem.transform.localPosition.z);
            totalHeight += height;
            // Debug.Log("height="+height);
        }
        this.contentListHolder.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, totalHeight);

        return totalHeight;            

        // float height = UIHelpers.calculateSqueezedHeight(contentItems.First().gameObject.GetComponent<InnerContentContent>().getInnerContentChildren(), 5, 5);
        // this.contentListHolder.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        // Debug.Log("height="+height);
        // return height;
    }
    
    public void shrinkWindow()
    {
        contentListHolder.SetActive(isShrunk);
        isShrunk = !isShrunk;
    }
    
    public void closeWindow()
    {
        Object.Destroy(this.gameObject);
    }

}
