using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Scriptable Objects/ItemData")]
public class ItemData : ScriptableObject
{
    public string objectName;
    public string description;
    public float value;
    //public List<Modifiers> modifiers = new();
    
    /*
    public enum Modifiers
    {
        Radioactive,
        Fragile,
        Explosive,
        SideUp, //doit être posé dans un sens particulier
        BioHazardous,
        Flammable,
        Corrosive,
        CrushingHazardous, //t'écrase
        ElectricalHazardous,
        LivingCreature,
        GassesUnderPressure //s'envole partout si prend un choc et explose si feu a coté
    }
    */
}
