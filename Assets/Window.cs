using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

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

    public void updateHeight()
    {
        float height = UIHelpers.calculateSqueezedHeight(contentItems.First().gameObject.GetComponent<InnerContentContent>().getInnerContentChildren(), 5, 5);
        this.contentListHolder.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
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
