using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using Random = UnityEngine.Random;

public class CommandManager : MonoBehaviour
{
    public static CommandManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        instance = this; 
    }

    [SerializeField] private List<ObjectData> listPossibleObjects;

    public Command currentCommand;

    private void Start()
    {
        CreateCommand();
    }

    public void CreateCommand()
    {
        currentCommand = new Command(GenerateRandomCommand());
    }

    private List<ObjectData> GenerateRandomCommand()
    {
        List<ObjectData> listCommand = new List<ObjectData>();
        int taille = Random.Range(3, 6);
        for (int i = 0; i < taille; i++)
        {
            int randomObject = Random.Range(0, listPossibleObjects.Count + 1);
            listCommand.Add(listPossibleObjects[randomObject]);
        }
        return listCommand;
    }


    public bool ValidateCommand()
    {
        Dictionary<string, int> commandInCarton = CartonManager.Instance.currentCarton.listObjectInCarton;
        Dictionary<string, int> commandToDo = currentCommand.objectsIDCount;

        if (commandInCarton.Count != commandToDo.Count)
        {
            return false;
        }

        foreach (var objects in commandInCarton)
        {
            if (!commandToDo.TryGetValue(objects.Key, out int currentValue) || currentValue != objects.Value)
            {
                return false;
            }
        }

        return true;
    }
}
