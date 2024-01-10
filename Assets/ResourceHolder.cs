using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public struct Resource : IComparable<Resource>
{
    public ResourceHolder.Element elementEnum { get; }
    public int atomicNumber { get; }
    public string symbol { get; }
    public string name { get; }
    public double meltingPointK { get; }

    public Resource(ResourceHolder.Element elementEnum, byte atomicNumber, string symbol, string name, float meltingPointK )
    {
        this.elementEnum = elementEnum;
        this.atomicNumber = atomicNumber;
        this.symbol = symbol;
        this.name = name;
        this.meltingPointK = meltingPointK;
    }

    public int CompareTo(Resource other)
    {
        return atomicNumber.CompareTo(other.atomicNumber);
    }
}

public class ResourceHolder
{
    public enum Element
    {
        HYDROGEN,
        HELIUM,
        LITHIUM,
        BERYLLIUM,
        BORON,
        CARBON,
        NITROGEN,
        OXYGEN,
        FLUORINE,
        NEON,
        SODIUM,
        MAGNESIUM,
        ALUMINIUM,
        SILICON,
        PHOSPHORUS,
        SULFUR,
        CHLORINE,
        ARGON,
        POTASSIUM,
        CALCIUM,
        SCANDIUM,
        TITANIUM,
        VANADIUM,
        CHROMIUM,
        MANGANESE,
        IRON
    }
    
    public static readonly Resource Hydrogen = new Resource(Element.HYDROGEN,1, "H", "Hydrogen", 14.01f);
    public static readonly Resource Helium = new Resource(Element.HELIUM,2, "He", "Helium", -1f);
    public static readonly Resource Lithium = new Resource(Element.LITHIUM,3, "Li", "Lithium", 453.69f);
    public static readonly Resource Beryllium = new Resource(Element.BERYLLIUM,4, "Be", "Beryllium", 1560f);
    public static readonly Resource Boron = new Resource(Element.BORON,5, "B", "Boron", 2349f);
    public static readonly Resource Carbon = new Resource(Element.CARBON,6, "C", "Carbon", 4000f);
    public static readonly Resource Nitrogen = new Resource(Element.NITROGEN,7, "N", "Nitrogen", 63.15f);
    public static readonly Resource Oxygen = new Resource(Element.OXYGEN,8, "O", "Oxygen", 54.36f);
    public static readonly Resource Fluorine = new Resource(Element.FLUORINE,9, "F", "Fluorine", 53.53f);
    public static readonly Resource Neon = new Resource(Element.NEON,10, "Ne", "Neon", 24.56f);
    public static readonly Resource Sodium = new Resource(Element.SODIUM,11, "Na", "Sodium", 370.87f);
    public static readonly Resource Magnesium = new Resource(Element.MAGNESIUM,12, "Mg", "Magnesium", 923f);
    public static readonly Resource Aluminium = new Resource(Element.ALUMINIUM,13, "Al", "Aluminium", 933.47f);
    public static readonly Resource Silicon = new Resource(Element.SILICON,14, "Si", "Silicon", 1687f);
    public static readonly Resource Phosphorus = new Resource(Element.PHOSPHORUS,15, "P", "Phosphorus", 317.3f);
    public static readonly Resource Sulfur = new Resource(Element.SULFUR,16, "S", "Sulfur", 388.36f);
    public static readonly Resource Chlorine = new Resource(Element.CHLORINE,17, "Cl", "Chlorine", 171.6f);
    public static readonly Resource Argon = new Resource(Element.ARGON,18, "Ar", "Argon", 83.8f);
    public static readonly Resource Potassium = new Resource(Element.POTASSIUM,19, "K", "Potassium", 336.53f);
    public static readonly Resource Calcium = new Resource(Element.CALCIUM,20, "Ca", "Calcium", 1115f);
    public static readonly Resource Scandium = new Resource(Element.SCANDIUM,21, "Sc", "Scandium", 1814f);
    public static readonly Resource Titanium = new Resource(Element.TITANIUM,22, "Ti", "Titanium", 1941f);
    public static readonly Resource Vanadium = new Resource(Element.VANADIUM,23, "V", "Vanadium", 2183f);
    public static readonly Resource Chromium = new Resource(Element.CHROMIUM,24, "Cr", "Chromium", 2180f);
    public static readonly Resource Manganese = new Resource(Element.MANGANESE,25, "Mn", "Manganese", 1519f);
    public static readonly Resource Iron = new Resource(Element.IRON,26, "Fe", "Iron", 1811f);

    private SortedList<Resource, float> storedResources;
    
    public ResourceHolder(SortedList<Resource, float> storedResources)
    {
        this.storedResources = storedResources;
    }

    public float addResrouce(Resource resource, float amountMegatonneage)
    {
        if (this.storedResources.ContainsKey(resource))
        {
            return this.storedResources[resource] += amountMegatonneage;
        }
        else
        {
            this.storedResources.Add(resource, amountMegatonneage);
            return amountMegatonneage;
        }
    }

    public float getResouce(Resource resource)
    {
        if (this.storedResources.ContainsKey(resource))
        {
            return this.storedResources[resource];
        }
        else
        {
            return 0;
        }
    }
}
