using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Units
{
    public static readonly float MEGATONNE_IN_A_SOLAR_MASS= 1.988E+21f;

    public static float solarMassToMegatonne(float solarMass)
    {
        return solarMass * MEGATONNE_IN_A_SOLAR_MASS;
    } 

}
