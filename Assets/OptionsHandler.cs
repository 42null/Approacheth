using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    
    public void openOrResourceWindow(GameObject gameObjectRequesting)
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
                // instantiatedWindowPrefab.transform.SetParent(canvasToPlaceOn.transform, false);

            
                Window window = instantiatedWindowPrefab.GetComponent<Window>();
                GameObject resourcesContent = Instantiate(resourceContentListPrefab, canvasPosition, Quaternion.identity, instantiatedWindowPrefab.transform);
                // GameObject resourcesContent = Instantiate(resourceContentListPrefab, canvasPosition, Quaternion.identity, window.content.transform);
            
                resourcesContent.transform.SetParent(window.content.transform, false);
            
                resourcesContent.GetComponent<ResourceDisplayList>().DisplayResources = resourceHolder;
            
                window.contentItems.Add(resourcesContent);
                
                constructedMenus.Add(gameObjectRequesting, new ConstructedMenu(gameObjectRequesting, instantiatedWindowPrefab, window));




                Debug.Log("ADDING 2nd");
                
                GameObject selectorConstruct = Instantiate(selectContentListPrefab, canvasPosition, Quaternion.identity, instantiatedWindowPrefab.transform);
                selectorConstruct.transform.SetParent(window.content.transform, false);
                
                window.contentItems.Add(selectorConstruct);
                try
                {
                    window.updateHeight();
                }
                catch (Exception e)
                {
                    Debug.Log("Error: "+e.Message);
                }
                //
                // constructedMenus.Add(gameObjectRequesting, new ConstructedMenu(gameObjectRequesting, instantiatedWindowPrefab, window));
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
        openOrResourceWindow(eventData.pointerPress);
    }
}
