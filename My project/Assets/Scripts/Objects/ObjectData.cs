using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "Scriptable Objects/ObjectData")]
public class ObjectData : ScriptableObject
{
    public int cost; //combien il coute au joueur
    public int price; //combien il rapporte une fois vendu

    public enum Type
    {
        Breakable,
        Explosive,
        Flammable
    }

    public List<Type> types;
}