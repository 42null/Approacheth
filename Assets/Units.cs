using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class Units
{
    public static readonly float MEGATONNE_IN_A_SOLAR_MASS = 1.988E+21f;

    public enum Unit
    {
        MEGATONNE,
        SOLAR_MASS
    }


    public static float solarMassToMegatonne(float solarMass)
    {
        return solarMass * MEGATONNE_IN_A_SOLAR_MASS;
    }

    public static string format(float value, Unit unit)
    {
        return unit switch
        {
            Unit.MEGATONNE => $"{value.ToString("#,0.##")} Mt",
            Unit.SOLAR_MASS => "",
            _ => $"{value} {unit}"
        };
    }
    
    
}
