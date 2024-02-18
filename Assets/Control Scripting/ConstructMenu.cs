using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ConstructMenu : SelectOptionMenu
{
    void Start()
    {
        solarBodyTracker = GameObject.Find("/Solar Body Tracker").GetComponent<SolarBodyTracker>();
        //Locate targets by self
        if (gameObjectTargets.Count == 0)
        {
            gameObjectTargets = solarBodyTracker.getSolarTargets();
        }
        base.Start();
    }

}