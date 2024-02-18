using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class BuildableMenu : SelectOptionMenu 
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("START WAS CALLED");
        solarBodyTracker = GameObject.Find("/Solar Body Tracker").GetComponent<SolarBodyTracker>();
        //Locate targets by self
        if (gameObjectTargets.Count == 0)
        {
            gameObjectTargets = solarBodyTracker.getConstructionTargets();
        }
        base.Start();
        updatePossibleToBuild();
    }

    private void updatePossibleToBuild()
    {
        ResourceDisplayList resourceListAvaiableToBuildWith = new ResourceDisplayList(new ResourceHolder(new SortedList<Resource, float>())); 
        foreach (var contentItem in this.gameObject.GetComponentInParent<Window>().contentItems)
        {
            if (contentItem.name == "Held Resource Display(Clone)")
            {

                resourceListAvaiableToBuildWith = contentItem.GetComponent<ResourceDisplayList>();
                break;
            }
        }

        // try
        // {
        //     resourceListAvaiableToBuildWith.DisplayResources;
        // }
        // catch (Exception e)
        // {
        //     Debug.Log("resourceListAvaiableToBuildWith was not found");
        //     return;
        // }
        
        foreach(var builtBodyTarget in builtBodyTargets)
        {
            GameObject targetSystemObjectPrefabToCreate =
                builtBodyTarget.GetComponent<TargetOptionDisplay>().targetSystemObject;
            // Debug.Log("PPPP"+targetSystemObjectPrefabToCreate.name);
            ResourceHolder resourcesRequiredToBuild = targetSystemObjectPrefabToCreate.GetComponent<OrbitalBody>().getResourses();
            if (resourceListAvaiableToBuildWith.DisplayResources.containsAll(resourcesRequiredToBuild))
            {
                builtBodyTarget.GetComponent<TargetOptionDisplay>().setBackgroundDisabled(false);
            }
            else
            {
                builtBodyTarget.GetComponent<TargetOptionDisplay>().setBackgroundDisabled(true);
            }
        }
    }
}