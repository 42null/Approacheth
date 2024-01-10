using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaturalResourceGen {
    
    public enum BodyType
    {
        STAR,
        ASTROID,
        PLANNER
    }

    public static ResourceHolder generateResources(BodyType bType, float sizeSolarMasses)
    {
        if (bType == BodyType.STAR)
        {
            // Percentages are in line with Sol's percentages for now
            SortedList<Resource, float> resources = new SortedList<Resource, float>
            {
                { ResourceHolder.Hydrogen, 91.2f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
                { ResourceHolder.Helium, 8.7f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
                { ResourceHolder.Oxygen, 0.078f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
                { ResourceHolder.Carbon, 0.043f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
                { ResourceHolder.Nitrogen, 0.0088f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
                { ResourceHolder.Silicon, 0.0045f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
                { ResourceHolder.Magnesium, 0.0038f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
                { ResourceHolder.Neon, 0.0035f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
                { ResourceHolder.Iron, 0.0030f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
                { ResourceHolder.Sulfur, 0.0015f/100*Units.solarMassToMegatonne(sizeSolarMasses) },
            };
            return new ResourceHolder(resources);
        }

        return new ResourceHolder(new SortedList<Resource, float>());
    }
        
}
