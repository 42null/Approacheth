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
        IRON,
        COBALT,
        NICKEL,
        COPPER,
        ZINC,
        GALLIUM,
        GERMANIUM,
        ARSENIC,
        SELENIUM,
        BROMINE,
        KRYPTON,
        RUBIDIUM,
        STRONTIUM,
        YTTRIUM,
        ZIRCONIUM,
        NIOBIUM,
        MOLYBDENUM,
        TECHNETIUM,
        RUTHENIUM,
        RHODIUM,
        PALLADIUM,
        SILVER,
        CADMIUM,
        INDIUM,
        TIN,
        ANTIMONY,
        TELLURIUM,
        IODINE,
        XENON,
        CAESIUM,
        BARIUM,
        LANTHANUM,
        CERIUM,
        PRASEODYMIUM,
        NEODYMIUM,
        PROMETHIUM,
        SAMARIUM,
        EUROPIUM,
        GADOLINIUM,
        TERBIUM,
        DYSPROSIUM,
        HOLMIUM,
        ERBIUM,
        THULIUM,
        YTTERBIUM,
        LUTETIUM,
        HAFNIUM,
        TANTALUM,
        TUNGSTEN,
        RHENIUM,
        OSMIUM,
        IRIDIUM,
        PLATINUM,
        GOLD,
        MERCURY,
        THALLIUM,
        LEAD,
        BISMUTH,
        POLONIUM,
        ASTATINE,
        RADON,
        FRANCIUM,
        RADIUM,
        ACTINIUM,
        THORIUM,
        PROTACTINIUM,
        URANIUM,
        NEPTUNIUM,
        PLUTONIUM,
        AMERICIUM,
        CURIUM,
        BERKELIUM,
        CALIFORNIUM,
        EINSTEINIUM,
        FERMIUM,
        MENDELEVIUM,
        NOBELIUM,
        LAWRENCIUM,
        RUTHERFORDIUM,
        DUBNIUM,
        SEABORGIUM,
        BOHRIUM,
        HASSIUM,
        MEITNERIUM,
        DARMSTADTIUM,
        ROENTGENIUM,
        COPERNICIUM,
        NIHONIUM,
        FLEROVIUM,
        MOSCOVIUM,
        LIVERMORIUM,
        TENNESSINE,
        OGANESSON,
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
    public static readonly Resource Cobalt = new Resource(Element.COBALT, 27, "Co", "Cobalt", 1768f);
    public static readonly Resource Nickel = new Resource(Element.NICKEL, 28, "Ni", "Nickel", 1728f);
    public static readonly Resource Copper = new Resource(Element.COPPER, 29, "Cu", "Copper", 1357.77f);
    public static readonly Resource Zinc = new Resource(Element.ZINC, 30, "Zn", "Zinc", 692.88f);
    public static readonly Resource Gallium = new Resource(Element.GALLIUM, 31, "Ga", "Gallium", 302.9146f);
    public static readonly Resource Germanium = new Resource(Element.GERMANIUM, 32, "Ge", "Germanium", 1211.4f);
    public static readonly Resource Arsenic = new Resource(Element.ARSENIC, 33, "As", "Arsenic", 1090f);
    public static readonly Resource Selenium = new Resource(Element.SELENIUM, 34, "Se", "Selenium", 453f);
    public static readonly Resource Bromine = new Resource(Element.BROMINE, 35, "Br", "Bromine", 265.8f);
    public static readonly Resource Krypton = new Resource(Element.KRYPTON, 36, "Kr", "Krypton", 115.79f);
    public static readonly Resource Rubidium = new Resource(Element.RUBIDIUM, 37, "Rb", "Rubidium", 312.46f);
    public static readonly Resource Strontium = new Resource(Element.STRONTIUM, 38, "Sr", "Strontium", 1050f);
    public static readonly Resource Yttrium = new Resource(Element.YTTRIUM, 39, "Y", "Yttrium", 1799f);
    public static readonly Resource Zirconium = new Resource(Element.ZIRCONIUM, 40, "Zr", "Zirconium", 2128f);
    public static readonly Resource Niobium = new Resource(Element.NIOBIUM, 41, "Nb", "Niobium", 2750f);
    public static readonly Resource Molybdenum = new Resource(Element.MOLYBDENUM, 42, "Mo", "Molybdenum", 2896f);
    public static readonly Resource Technetium = new Resource(Element.TECHNETIUM, 43, "Tc", "Technetium", 2430f);
    public static readonly Resource Ruthenium = new Resource(Element.RUTHENIUM, 44, "Ru", "Ruthenium", 2607f);
    public static readonly Resource Rhodium = new Resource(Element.RHODIUM, 45, "Rh", "Rhodium", 2237f);
    public static readonly Resource Palladium = new Resource(Element.PALLADIUM, 46, "Pd", "Palladium", 1828.05f);
    public static readonly Resource Silver = new Resource(Element.SILVER, 47, "Ag", "Silver", 1234.93f);
    public static readonly Resource Cadmium = new Resource(Element.CADMIUM, 48, "Cd", "Cadmium", 594.22f);
    public static readonly Resource Indium = new Resource(Element.INDIUM, 49, "In", "Indium", 429.75f);
    public static readonly Resource Tin = new Resource(Element.TIN, 50, "Sn", "Tin", 505.08f);
    public static readonly Resource Antimony = new Resource(Element.ANTIMONY, 51, "Sb", "Antimony", 903.78f);
    public static readonly Resource Tellurium = new Resource(Element.TELLURIUM, 52, "Te", "Tellurium", 722.66f);
    public static readonly Resource Iodine = new Resource(Element.IODINE, 53, "I", "Iodine", 386.85f);
    public static readonly Resource Xenon = new Resource(Element.XENON, 54, "Xe", "Xenon", 161.4f);
    public static readonly Resource Caesium = new Resource(Element.CAESIUM, 55, "Cs", "Caesium", 301.59f);
    public static readonly Resource Barium = new Resource(Element.BARIUM, 56, "Ba", "Barium", 1000f);
    public static readonly Resource Lanthanum = new Resource(Element.LANTHANUM, 57, "La", "Lanthanum", 1193f);
    public static readonly Resource Cerium = new Resource(Element.CERIUM, 58, "Ce", "Cerium", 1068f);
    public static readonly Resource Praseodymium = new Resource(Element.PRASEODYMIUM, 59, "Pr", "Praseodymium", 1208f);
    public static readonly Resource Neodymium = new Resource(Element.NEODYMIUM, 60, "Nd", "Neodymium", 1297f);
    public static readonly Resource Promethium = new Resource(Element.PROMETHIUM, 61, "Pm", "Promethium", 1315f);
    public static readonly Resource Samarium = new Resource(Element.SAMARIUM, 62, "Sm", "Samarium", 1345f);
    public static readonly Resource Europium = new Resource(Element.EUROPIUM, 63, "Eu", "Europium", 1099f);
    public static readonly Resource Gadolinium = new Resource(Element.GADOLINIUM, 64, "Gd", "Gadolinium", 1585f);
    public static readonly Resource Terbium = new Resource(Element.TERBIUM, 65, "Tb", "Terbium", 1629f);
    public static readonly Resource Dysprosium = new Resource(Element.DYSPROSIUM, 66, "Dy", "Dysprosium", 1680f);
    public static readonly Resource Holmium = new Resource(Element.HOLMIUM, 67, "Ho", "Holmium", 1734f);
    public static readonly Resource Erbium = new Resource(Element.ERBIUM, 68, "Er", "Erbium", 1802f);
    public static readonly Resource Thulium = new Resource(Element.THULIUM, 69, "Tm", "Thulium", 1818f);
    public static readonly Resource Ytterbium = new Resource(Element.YTTERBIUM, 70, "Yb", "Ytterbium", 1097f);
    public static readonly Resource Lutetium = new Resource(Element.LUTETIUM, 71, "Lu", "Lutetium", 1925f);
    public static readonly Resource Hafnium = new Resource(Element.HAFNIUM, 72, "Hf", "Hafnium", 2506f);
    public static readonly Resource Tantalum = new Resource(Element.TANTALUM, 73, "Ta", "Tantalum", 3290f);
    public static readonly Resource Tungsten = new Resource(Element.TUNGSTEN, 74, "W", "Tungsten", 3695f);
    public static readonly Resource Rhenium = new Resource(Element.RHENIUM, 75, "Re", "Rhenium", 3459f);
    public static readonly Resource Osmium = new Resource(Element.OSMIUM, 76, "Os", "Osmium", 3306f);
    public static readonly Resource Iridium = new Resource(Element.IRIDIUM, 77, "Ir", "Iridium", 2719f);
    public static readonly Resource Platinum = new Resource(Element.PLATINUM, 78, "Pt", "Platinum", 2041.4f);
    public static readonly Resource Gold = new Resource(Element.GOLD, 79, "Au", "Gold", 1337.33f);
    public static readonly Resource Mercury = new Resource(Element.MERCURY, 80, "Hg", "Mercury", 234.43f);
    public static readonly Resource Thallium = new Resource(Element.THALLIUM, 81, "Tl", "Thallium", 577f);
    public static readonly Resource Lead = new Resource(Element.LEAD, 82, "Pb", "Lead", 600.61f);
    public static readonly Resource Bismuth = new Resource(Element.BISMUTH, 83, "Bi", "Bismuth", 544.7f);
    public static readonly Resource Polonium = new Resource(Element.POLONIUM, 84, "Po", "Polonium", 527f);
    public static readonly Resource Astatine = new Resource(Element.ASTATINE, 85, "At", "Astatine", 575f);
    public static readonly Resource Radon = new Resource(Element.RADON, 86, "Rn", "Radon", 202f);
    public static readonly Resource Francium = new Resource(Element.FRANCIUM, 87, "Fr", "Francium", 281f);
    public static readonly Resource Radium = new Resource(Element.RADIUM, 88, "Ra", "Radium", 973f);
    public static readonly Resource Actinium = new Resource(Element.ACTINIUM, 89, "Ac", "Actinium", 1323f);
    public static readonly Resource Thorium = new Resource(Element.THORIUM, 90, "Th", "Thorium", 2115f);
    public static readonly Resource Protactinium = new Resource(Element.PROTACTINIUM, 91, "Pa", "Protactinium", 1841f);
    public static readonly Resource Uranium = new Resource(Element.URANIUM, 92, "U", "Uranium", 1405.3f);
    public static readonly Resource Neptunium = new Resource(Element.NEPTUNIUM, 93, "Np", "Neptunium", 917f);
    public static readonly Resource Plutonium = new Resource(Element.PLUTONIUM, 94, "Pu", "Plutonium", 912.5f);
    public static readonly Resource Americium = new Resource(Element.AMERICIUM, 95, "Am", "Americium", 1449f);
    public static readonly Resource Curium = new Resource(Element.CURIUM, 96, "Cm", "Curium", 1613f);
    public static readonly Resource Berkelium = new Resource(Element.BERKELIUM, 97, "Bk", "Berkelium", 1259f);
    public static readonly Resource Californium = new Resource(Element.CALIFORNIUM, 98, "Cf", "Californium", 1173f);
    public static readonly Resource Einsteinium = new Resource(Element.EINSTEINIUM, 99, "Es", "Einsteinium", 1133f);
    public static readonly Resource Fermium = new Resource(Element.FERMIUM, 100, "Fm", "Fermium", 1462.5f);
    public static readonly Resource Mendelevium = new Resource(Element.MENDELEVIUM, 101, "Md", "Mendelevium", 1100f);
    public static readonly Resource Nobelium = new Resource(Element.NOBELIUM, 102, "No", "Nobelium", 1100f);
    public static readonly Resource Lawrencium = new Resource(Element.LAWRENCIUM, 103, "Lr", "Lawrencium", 1900f);
    public static readonly Resource Rutherfordium = new Resource(Element.RUTHERFORDIUM, 104, "Rf", "Rutherfordium", 2400f);
    public static readonly Resource Dubnium = new Resource(Element.DUBNIUM, 105, "Db", "Dubnium", -1f);
    public static readonly Resource Seaborgium = new Resource(Element.SEABORGIUM, 106, "Sg", "Seaborgium", -1f);
    public static readonly Resource Bohrium = new Resource(Element.BOHRIUM, 107, "Bh", "Bohrium", -1f);
    public static readonly Resource Hassium = new Resource(Element.HASSIUM, 108, "Hs", "Hassium", -1f);
    public static readonly Resource Meitnerium = new Resource(Element.MEITNERIUM, 109, "Mt", "Meitnerium", -1f);
    public static readonly Resource Darmstadtium = new Resource(Element.DARMSTADTIUM, 110, "Ds", "Darmstadtium", -1f);
    public static readonly Resource Roentgenium = new Resource(Element.ROENTGENIUM, 111, "Rg", "Roentgenium", -1f);
    public static readonly Resource Copernicium = new Resource(Element.COPERNICIUM, 112, "Cn", "Copernicium", 283f);
    public static readonly Resource Nihonium = new Resource(Element.NIHONIUM, 113, "Nh", "Nihonium", 700f);
    public static readonly Resource Flerovium = new Resource(Element.FLEROVIUM, 114, "Fl", "Flerovium", 284f);
    public static readonly Resource Moscovium = new Resource(Element.MOSCOVIUM, 115, "Mc", "Moscovium", 700f);
    public static readonly Resource Livermorium = new Resource(Element.LIVERMORIUM, 116, "Lv", "Livermorium", 700f);
    public static readonly Resource Tennessine = new Resource(Element.TENNESSINE, 117, "Ts", "Tennessine", 700f);
    public static readonly Resource Oganesson = new Resource(Element.OGANESSON, 118, "Og", "Oganesson", 325f);
    
    
    public SortedList<Resource, float> storedResources;
    
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
    
    public SortedList<Resource, float> getResouces()
    {
        return this.storedResources;
    }
}
