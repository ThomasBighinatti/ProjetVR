using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Objects", menuName = "Scriptable Objects/Objects")]
public class Objects : ScriptableObject
{
    public string objectName;
    public string description;
    public float value;
    public List<Modifiers> modifiers = new List<Modifiers>();
    
    public enum Modifiers
    {
        Radioactive,
        Fragile,
        Explosive,
        SideUp, //doit être posé dans un sens particulier
        BioHazardous,
        Inflammable,
        Corrosive,
        CrushingHazardous, //t'écrase
        ElectricalHazardous,
        LivingCreature,
        GassesUnderPressure //s'envole partout si prend un choc et explose si feu a coté
    }
}
