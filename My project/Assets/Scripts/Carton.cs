using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

public class Carton : MonoBehaviour
{
    public enum state
    {
        Moving,
        Placing
    }

    public state currentState;
    public List<BaseObject> objectsInCarton;

    private HashSet<ObjectData.Type> listTypeObjectCommand;
    private HashSet<ObjectData.Type> listTypeObjectSecurity;

    private Dictionary<string, int> listObjectInCarton;
    private Dictionary<string, int> listObjectSecurityInCarton;

    
    private void OnTriggerEnter(Collider other)
    {
        objectsInCarton.Add(other.GetComponent<BaseObject>());

        if (other.GetComponent<SellingObject>())
        {
            listObjectInCarton.Add(other.GetComponent<SellingObject>().objectData.objectID, 1);
        }
        if (other.GetComponent<SecurityObject>())
        {
            listObjectSecurityInCarton.Add(other.GetComponent<SecurityObject>().objectData.objectID, 1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        objectsInCarton.Remove(other.GetComponent<BaseObject>());
    }
}
