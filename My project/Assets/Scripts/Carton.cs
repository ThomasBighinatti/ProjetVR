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

    [SerializeField] private Dictionary<ObjectData.Type, int> listTypeObjectCommand = new Dictionary<ObjectData.Type, int>();
    [SerializeField] private Dictionary<ObjectData.Type, int> listTypeObjectSecurity = new Dictionary<ObjectData.Type, int>();

    [SerializeField] public Dictionary<string , int> listObjectInCarton = new Dictionary<string, int>();
    
    
    
    private void OnTriggerEnter(Collider other)
    {
        SellingObject sellingObject = other.GetComponent<SellingObject>();
        SecurityObject securityObject = other.GetComponent<SecurityObject>();

        
        if (sellingObject != null)
        {
            Debug.Log("Détection objet a vendre");
            if (!listObjectInCarton.ContainsKey(sellingObject.objectData.objectID))
            {
                listObjectInCarton.Add(sellingObject.objectData.objectID, 0);
            }
            listObjectInCarton[sellingObject.objectData.objectID]++;
            foreach (var type in sellingObject.objectData.types)
            {
                if (!listTypeObjectCommand.ContainsKey(type))
                {
                    listTypeObjectCommand.Add(type, 0);
                }

                listTypeObjectCommand[type]++;
            }
            Debug.Log(String.Join(",",listTypeObjectCommand));
            Debug.Log(String.Join(",",listObjectInCarton));

        }
        if (securityObject != null)
        {
            Debug.Log("Détection objet de sécurité");
            if (!listTypeObjectSecurity.ContainsKey(securityObject.objectData.types[0]))
            {
                listTypeObjectSecurity.Add(securityObject.objectData.types[0],0);
            }
            listTypeObjectSecurity[securityObject.objectData.types[0]]++;
            Debug.Log(String.Join(",",listTypeObjectSecurity));
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        SellingObject sellingObject = other.GetComponent<SellingObject>();
        SecurityObject securityObject = other.GetComponent<SecurityObject>();

        
        if (sellingObject != null)
        {
            Debug.Log("Détection objet a vendre");
            listObjectInCarton[sellingObject.objectData.objectID]--;
            if (listObjectInCarton[sellingObject.objectData.objectID] <= 0)
            {
                listObjectInCarton.Remove(sellingObject.objectData.objectID);
            }
            foreach (var type in sellingObject.objectData.types)
            {
                listTypeObjectCommand[type]--;
                if (listTypeObjectCommand[type] <= 0)
                {
                    listTypeObjectCommand.Remove(type);
                }
            }
            Debug.Log(String.Join(",",listTypeObjectCommand));
            Debug.Log(String.Join(",",listObjectInCarton));

        }
        if (securityObject != null)
        {
            Debug.Log("Détection objet de sécurité");
            listTypeObjectSecurity[securityObject.objectData.types[0]]--;
            if (listTypeObjectSecurity[securityObject.objectData.types[0]] <= 0)
            {
                listTypeObjectSecurity.Remove(securityObject.objectData.types[0]);
            }
            Debug.Log(String.Join(",",listTypeObjectSecurity));
        }
    }

    public bool VerifySecurity()
    {
        var commandKeys = new HashSet<ObjectData.Type>(listTypeObjectCommand.Keys);
        var securityKeys = new HashSet<ObjectData.Type>(listTypeObjectSecurity.Keys);

        return commandKeys.SetEquals(securityKeys);
    }
}