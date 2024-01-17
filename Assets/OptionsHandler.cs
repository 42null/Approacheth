using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ConstructedMenu
{
    public GameObject initatedPrefab;
    public GameObject calledInitalization;
    public Window window;

    public ConstructedMenu(GameObject calledInitalization, GameObject initatedPrefab, Window window)
    {
        this.initatedPrefab = initatedPrefab;
        this.calledInitalization = calledInitalization;
        this.window = window;
    }

}

public class OptionsHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public GameObject windowPrefab;
    [SerializeField] public GameObject resourceContentListPrefab;
    [SerializeField] public GameObject selectContentListPrefab;
    [SerializeField] public Canvas canvasToPlaceOn;
    [SerializeField] public Camera camera;

    private Dictionary<GameObject, ConstructedMenu> constructedMenus = new Dictionary<GameObject, ConstructedMenu>(){};

    private Dictionary<GameObject, List<windowSections>> sectionsToBuildWith = new Dictionary<GameObject, List<windowSections>>();

    public enum windowSections
    {
        REOURCES,
        CONSTRUCT,
        OPTIONS,
    }


    private void addSection(GameObject gameObjectRequesting, windowSections windowSection)
    {
        if (sectionsToBuildWith.ContainsKey(gameObjectRequesting))
        {
            sectionsToBuildWith[gameObjectRequesting].Add(windowSection);
        }
        else
        {
            sectionsToBuildWith[gameObjectRequesting] = new List<windowSections> { windowSection };
        }
    }

    public void addResources(GameObject gameObjectRequesting)
    {
        addSection(gameObjectRequesting, windowSections.REOURCES);
    }
    
    public void addOptions(GameObject gameObjectRequesting)
    {
        addSection(gameObjectRequesting, windowSections.OPTIONS);
    }
    
    public void addConstructor(GameObject gameObjectRequesting)
    {
        addSection(gameObjectRequesting, windowSections.CONSTRUCT);
    }
    
    public void buildFromAlreadyAdded(GameObject gameObjectRequesting)
    {
        Debug.Log($"BuildFromAlreadyAdded: \"{gameObjectRequesting.name}\"");

        if (sectionsToBuildWith[gameObjectRequesting] != null)
        {
            openOrResourceWindow(gameObjectRequesting, sectionsToBuildWith[gameObjectRequesting]);
        }
    }
    
    public void openOrResourceWindow(GameObject gameObjectRequesting, List<windowSections> includeSections)
    {
        if(constructedMenus.ContainsKey(gameObjectRequesting))
        {
            ConstructedMenu targetedMenu = constructedMenus[gameObjectRequesting];
            targetedMenu.window.updateHeight();
            targetedMenu.initatedPrefab.SetActive(!targetedMenu.initatedPrefab.activeSelf);
        }
        else
        {
            if (gameObjectRequesting.TryGetComponent<OrbitalBody>(out OrbitalBody orbitalBody))
            {
                ResourceHolder resourceHolder = orbitalBody.getResourses();

                Vector3 worldPosition = gameObjectRequesting.transform.position;

                // Vector2 screenPosition = camera.WorldToScreenPoint(worldPosition);
                Vector2 canvasPosition = WorldToCanvasPosition(canvasToPlaceOn, camera, worldPosition);
                canvasPosition.x += (canvasToPlaceOn.GetComponent<RectTransform>().sizeDelta.x / 2);
                canvasPosition.y += (canvasToPlaceOn.GetComponent<RectTransform>().sizeDelta.y / 2);

                GameObject instantiatedWindowPrefab = Instantiate(windowPrefab, canvasPosition, Quaternion.identity, canvasToPlaceOn.transform);
                Window window = instantiatedWindowPrefab.GetComponent<Window>();

                window.referenceIcon.GetComponent<Image>().sprite = gameObjectRequesting.GetComponent<SpriteRenderer>().sprite;
                
                
                if (includeSections.Contains(windowSections.REOURCES))
                {
                    GameObject resourcesContent = Instantiate(resourceContentListPrefab, canvasPosition, Quaternion.identity, instantiatedWindowPrefab.transform);

                    resourcesContent.transform.SetParent(window.content.transform, false);

                    resourcesContent.GetComponent<ResourceDisplayList>().DisplayResources = resourceHolder;

                    window.contentItems.Add(resourcesContent);

                    constructedMenus.Add(gameObjectRequesting,
                        new ConstructedMenu(gameObjectRequesting, instantiatedWindowPrefab, window));
   
                }

                if (includeSections.Contains(windowSections.CONSTRUCT))
                {
                    GameObject selectorConstruct = Instantiate(selectContentListPrefab, canvasPosition,
                        Quaternion.identity, instantiatedWindowPrefab.transform);
                    selectorConstruct.transform.SetParent(window.content.transform, false);

                    window.contentItems.Add(selectorConstruct);
                    window.updateHeight();
                }
            }
        }
    }

    private Vector2 WorldToCanvasPosition(Canvas canvas, Camera worldCamera, Vector3 worldPosition)
    {
        Vector2 viewportPoint = worldCamera.WorldToViewportPoint(worldPosition);

        var rootCanvasTransform = (canvas.isRootCanvas ? canvas.transform : canvas.rootCanvas.transform) as RectTransform;
        var rootCanvasSize = rootCanvasTransform!.rect.size;

        var rootCoord = (viewportPoint - rootCanvasTransform.pivot) * rootCanvasSize;
        if (canvas.isRootCanvas)
            return rootCoord;

        var rootToWorldPos = rootCanvasTransform.TransformPoint(rootCoord);
        Vector2 convertedPos = canvas.transform.InverseTransformPoint(rootToWorldPos);
        
        // convertedPos.x += (canvasToPlaceOn.GetComponent<RectTransform>().sizeDelta.x / 2);
        // convertedPos.y += (canvasToPlaceOn.GetComponent<RectTransform>().sizeDelta.y / 2);
        
        return convertedPos;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        openOrResourceWindow(eventData.pointerPress, new List<windowSections>() { windowSections.CONSTRUCT });
    }
}
