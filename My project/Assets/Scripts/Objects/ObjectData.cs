using UnityEngine;

[CreateAssetMenu(fileName = "ObjectData", menuName = "Scriptable Objects/ObjectData")]
public class ObjectData : ScriptableObject
{
    public string objectID;
    public int cost; //combien il coute au joueur
    public int price; //combien il rapporte une fois vendu
}
