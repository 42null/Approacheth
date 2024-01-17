using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ConstructMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject scrollPanel;

    [SerializeField] public List<GameObject> constructionPrefabs;

    
    [SerializeField] public GameObject prefabSelectorBar;
    [SerializeField] public List<GameObject> gameObjectTargets = new List<GameObject>(){};
    [SerializeField] public List<GameObject> builtBodyTargets = new List<GameObject>(){};
    [SerializeField] public SolarBodyTracker solarBodyTracker = new SolarBodyTracker();
    // new SolarBodyTracker();

    
    private TargetOptionDisplay selectedTarget = null;
    
    // Start is called before the first frame update
    void Start()
    {
        solarBodyTracker = GameObject.Find("/Solar Body Tracker").GetComponent<SolarBodyTracker>();
        //Locate targets by self
        if (gameObjectTargets.Count == 0)
        {
            gameObjectTargets = solarBodyTracker.getSolarTargets();
        }
        
        
        List<GameObject> instantiatedBoxes = new List<GameObject>(){};

        float startingY = 70;
        for (int i = 0; i < gameObjectTargets.Count; i++)
        {
            // instantiatedBoxes[i] = Instantiate(prefabSelectorBar, new Vector3(0, -100f, 0), Quaternion.identity, scrollPanel.transform) as GameObject;
            Vector3 relativeSpawnPositionToPanel = new Vector3(0, startingY + ( -72 * i ), 0);
            instantiatedBoxes.Add(Instantiate(prefabSelectorBar, scrollPanel.transform.TransformPoint(relativeSpawnPositionToPanel), Quaternion.identity, scrollPanel.transform) as GameObject);

            TargetOptionDisplay targetOptionDisplay = instantiatedBoxes[i].GetComponent<TargetOptionDisplay>();
            targetOptionDisplay.targetSystemObject = gameObjectTargets[i];
            targetOptionDisplay.constructorMenu = this.gameObject.GetComponent<ConstructMenu>();
            targetOptionDisplay.updateTargetAttributes();
        }
        
        Window preCreatedParentWindow = null;
        // // this.gameObject.transform.parent.parent.TryGetComponent<Window>(out preCreatedParentWindow);
        // if (preCreatedParentWindow != null)
        // {
        //     preCreatedParentWindow.updateHeight();
        // }

        this.builtBodyTargets = instantiatedBoxes;
    }

    public void select(TargetOptionDisplay targetOptionDisplay)
    {
        if (this.selectedTarget != null)
        {
            this.selectedTarget.setBackgroundSelected(false);
        }
        
        // "only one" mode - remove all others from selectedTarget instead of adding a new selectedTarget to the list  
        this.selectedTarget = targetOptionDisplay;
        this.selectedTarget.setBackgroundSelected(true);
    }

    public void constructClick()
    {

        GameObject placeUnderTransform = this.selectedTarget.targetSystemObject.transform.gameObject;
                                                
        Vector3 globalScale = new Vector3(0.03f, 0.03f, 1f);

        float radius = Mathf.Max(placeUnderTransform.GetComponent<SpriteRenderer>().bounds.size.x, placeUnderTransform.GetComponent<SpriteRenderer>().bounds.size.y) / 1.5f + globalScale.x * 2.5f;

        float angle = Random.Range(0f, 360f);
        Vector3 relativeSpawnPositionToObject = new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);

        GameObject newlyConstructed = Instantiate(constructionPrefabs[0], placeUnderTransform.transform.position + relativeSpawnPositionToObject, Quaternion.identity);

        placeUnderTransform.GetComponent<OrbitalBody>().addOrbiter(newlyConstructed);
        
        newlyConstructed.transform.localScale = globalScale;
    }


    // Update is called once per frame
    void Update()
    {
        
    }








}