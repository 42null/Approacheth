using UnityEngine;
using UnityEngine.EventSystems;

public class ResourceHandler : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public GameObject windowPrefab;
    [SerializeField] public GameObject resourceContentListPrefab;
    [SerializeField] public Canvas canvasToPlaceOn;
    [SerializeField] public Camera camera;

    public void createResourceWindow(GameObject gameObjectRequesting)
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

            
            GameObject resourcesContent = Instantiate(resourceContentListPrefab, canvasPosition, Quaternion.identity, instantiatedWindowPrefab.transform);
            
            resourcesContent.transform.SetParent(instantiatedWindowPrefab.transform, false);

            instantiatedWindowPrefab.GetComponent<Window>().contentItems.Add(resourcesContent);
            instantiatedWindowPrefab.GetComponent<Window>().updateHeight();

            // instantiatedWindowPrefab.GetComponent<Window>().contentListHolder = ;
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
        createResourceWindow(gameObject);
    }
}
