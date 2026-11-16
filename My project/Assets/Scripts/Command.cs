using System.Collections.Generic;
using UnityEngine;

public class Command 
{
    public int totalCommandprofit;
    [SerializeField] public Dictionary<string, int> objectsIDCount = new Dictionary<string, int>();    
    
    public Command(List<ObjectData> listObjects)
    {
        Debug.Log(string.Join(",", listObjects));
        foreach (var obj in listObjects)
        {
            totalCommandprofit += obj.profit;

            if (objectsIDCount.ContainsKey(obj.objectID))
                objectsIDCount[obj.objectID]++;
            else
                objectsIDCount.Add(obj.objectID, 1);
        }
    }
}
