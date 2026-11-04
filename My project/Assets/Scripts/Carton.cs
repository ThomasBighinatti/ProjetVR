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

    public HashSet<ObjectData.Type> listTypeObjectCommand = new HashSet<ObjectData.Type>();
    public HashSet<ObjectData.Type> listTypeObjectSecurity = new HashSet<ObjectData.Type>();

    public Dictionary<SellingObject, int> listObjectInCarton = new Dictionary<SellingObject, int>();
    
    
    private void OnTriggerEnter(Collider other)
    {
        SellingObject sellingObject = other.GetComponent<SellingObject>();
        SecurityObject securityObject = other.GetComponent<SecurityObject>();

        
        if (sellingObject != null)
        {
            Debug.Log("Détection objet a vendre");
            if (!listObjectInCarton.ContainsKey(sellingObject))
            {
                listObjectInCarton.Add(sellingObject, 0);
            }
            listObjectInCarton[sellingObject]++;
            foreach (var type in sellingObject.objectData.types)
            {
                listTypeObjectCommand.Add(type);
            }
            Debug.Log(String.Join(",",listTypeObjectCommand));
            Debug.Log(String.Join(",",listObjectInCarton));

        }
        if (securityObject != null)
        {
            Debug.Log("Détection objet de sécurité");
            listTypeObjectSecurity.Add(securityObject.objectData.types[0]);
            Debug.Log(String.Join(",",listTypeObjectSecurity));
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
