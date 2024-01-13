using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalResourceGen {
    
    public enum BodyType
    {
        UNSET_DEFAULT,
        STAR,
        PLANNET,
        ASTROID_TYPE_M,
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
        else
        {
            resources = new SortedList<Resource, float>();
        }
        return new ResourceHolder(resources);
    }
        
}
