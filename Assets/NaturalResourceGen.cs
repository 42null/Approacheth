using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class NaturalResourceGen {
    
    public enum BodyType
    {
        UNSET_DEFAULT,
        STAR,
        PLANNET,
        ASTROID_TYPE_M,
        VANGAURD,
        IMPACTOR_PROBE,
    }

    public static ResourceHolder generateResources(BodyType bType, float mass)
    {
        //TODO: Use mass unit to cover all conversions in parameters
        SortedList<Resource, float> resources;
        if (bType == BodyType.STAR)
        {
            // Percentages are in line with Sol's percentages for now
            resources = new SortedList<Resource, float>
            {
                { ResourceHolder.Hydrogen, 91.2f/100*Units.solarMassToMegatonne(mass) },
                { ResourceHolder.Helium, 8.7f/100*Units.solarMassToMegatonne(mass) },
                { ResourceHolder.Oxygen, 0.078f/100*Units.solarMassToMegatonne(mass) },
                { ResourceHolder.Carbon, 0.043f/100*Units.solarMassToMegatonne(mass) },
                { ResourceHolder.Nitrogen, 0.0088f/100*Units.solarMassToMegatonne(mass) },
                { ResourceHolder.Silicon, 0.0045f/100*Units.solarMassToMegatonne(mass) },
                { ResourceHolder.Magnesium, 0.0038f/100*Units.solarMassToMegatonne(mass) },
                { ResourceHolder.Neon, 0.0035f/100*Units.solarMassToMegatonne(mass) },
                { ResourceHolder.Iron, 0.0030f/100*Units.solarMassToMegatonne(mass) },
                { ResourceHolder.Sulfur, 0.0015f/100*Units.solarMassToMegatonne(mass) },
            };
        }
        else if (bType == BodyType.PLANNET)
        {
            resources = new SortedList<Resource, float>
            {
                { ResourceHolder.Hydrogen, 91.2f/100*mass },
                { ResourceHolder.Oxygen, 0.078f/100*mass },
            };
        }
        else if(bType == BodyType.ASTROID_TYPE_M)
        {
            resources = new SortedList<Resource, float>
            {
                { ResourceHolder.Iron, 91f/100*(mass) },
                { ResourceHolder.Nickel, 8.5f/100*(mass) },
                { ResourceHolder.Cobalt, 0.06f/100*(mass) },
            };
        }
        else if(bType == BodyType.VANGAURD)
        {
            resources = new SortedList<Resource, float>
            {
                { ResourceHolder.Iron,      20f/100*(mass) },
                { ResourceHolder.Nickel,    10f/100*(mass) },
                { ResourceHolder.Aluminium, 10f/100*(mass) },
                { ResourceHolder.Cobalt,    5f/100*(mass) },
                { ResourceHolder.Carbon,    30f/100*(mass) },
                { ResourceHolder.Silicon,   10f/100*(mass) },
                { ResourceHolder.Copper,    5f/100*(mass) },
                { ResourceHolder.Oxygen,    5f/100*(mass) },
                { ResourceHolder.Magnesium, 5f/100*(mass) },
                { ResourceHolder.Fluorine,  5f/100*(mass) },
            };
        }
        else if(bType == BodyType.IMPACTOR_PROBE)
        {
            resources = new SortedList<Resource, float>
            {
                { ResourceHolder.Iron,      40f/100*(mass) },
                { ResourceHolder.Oxygen,    20f/100*(mass) },
                { ResourceHolder.Silicon,   15f/100*(mass) },
                { ResourceHolder.Magnesium, 2.5f/100*(mass) },
                { ResourceHolder.Fluorine,  2.5f/100*(mass) },
            };
        }
        else
        {
            resources = new SortedList<Resource, float>(){};
        }

        // resources.OrderByDescending(r => r.Key.atomicNumber)
        // return new ResourceHolder(new SortedList<Resource, float>(resources.OrderByDescending(r => r.Value).ToDictionary(r => r.Key, v => v.Value)));
        return new ResourceHolder(resources);
    }
        
}
