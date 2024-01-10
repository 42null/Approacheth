using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ConstructMenu : MonoBehaviour
{
    [SerializeField]
    public GameObject scrollPanel;

    [SerializeField] public List<GameObject> constructionPrefabs;

    
    [FormerlySerializedAs("prefabSelectorBars")] [SerializeField]
    public GameObject prefabSelectorBar;
    [SerializeField] public GameObject[] bodyTargets;

    
    private TargetOptionDisplay selectedTarget = null;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] instantiatedBoxes = new GameObject[bodyTargets.Length];

        float startingY = 70;
        for (int i = 0; i < bodyTargets.Length; i++)
        {
            // instantiatedBoxes[i] = Instantiate(prefabSelectorBar, new Vector3(0, -100f, 0), Quaternion.identity, scrollPanel.transform) as GameObject;
            Vector3 relativeSpawnPositionToPanel = new Vector3(0, startingY + ( -72 * i ), 0);
            instantiatedBoxes[i] = Instantiate(prefabSelectorBar, scrollPanel.transform.TransformPoint(relativeSpawnPositionToPanel), Quaternion.identity, scrollPanel.transform) as GameObject;

            TargetOptionDisplay targetOptionDisplay = instantiatedBoxes[i].GetComponent<TargetOptionDisplay>();
            targetOptionDisplay.targetSystemObject = bodyTargets[i];
            targetOptionDisplay.constructorMenu = this.gameObject.GetComponent<ConstructMenu>();
            targetOptionDisplay.updateTargetAttributes();
        }

        this.bodyTargets = instantiatedBoxes;
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
        
        // this.heldResources = SortedList<Resource, float> resources = new SortedList<Resource, float>
        // {
        //     { ResourceHolder.Hydrogen, 91.2f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        //     { ResourceHolder.Helium, 8.7f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        //     { ResourceHolder.Oxygen, 0.078f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        //     { ResourceHolder.Carbon, 0.043f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        //     { ResourceHolder.Nitrogen, 0.0088f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        //     { ResourceHolder.Silicon, 0.0045f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        //     { ResourceHolder.Magnesium, 0.0038f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        //     { ResourceHolder.Neon, 0.0035f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        //     { ResourceHolder.Iron, 0.0030f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        //     { ResourceHolder.Sulfur, 0.0015f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
        // };
        
        
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