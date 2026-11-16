using System;
using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
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
    public TMP_Text commandText;

    private Command currentCommand;

    private void Start()
    {
        CreateCommand();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (ValidateCommand())
            {
                commandText.text = "La commande est bonne !";
            }
            else
            {
                commandText.text = "Commande ratée...";
            }
        }
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
            int randomObject = Random.Range(0, listPossibleObjects.Count);
            listCommand.Add(listPossibleObjects[randomObject]);
        }

        foreach (var objects in listCommand)
        {
            commandText.text += objects.objectID + "\n";
        }
        return listCommand;
    }


    public bool ValidateCommand()
    {
        Carton currentCarton = CartonManager.Instance.currentBox.GetComponentInChildren<Carton>();
        Dictionary<string, int> commandInCarton = currentCarton.listObjectInCarton;
        Dictionary<string, int> commandToDo = currentCommand.objectsIDCount;

        if (!currentCarton.VerifySecurity())
        {
            Debug.Log("La sécurité n'est pas bonne");
            return false;
        }
        
        if (commandInCarton.Count != commandToDo.Count)
        {
            Debug.Log("Commande pas bonne");
            return false;
        }

        foreach (var objects in commandInCarton)
        {
            if (!commandToDo.TryGetValue(objects.Key, out int currentValue) || currentValue != objects.Value)
            {
                Debug.Log("Commande pas bonne");
                return false;
            }
        }
        
        Debug.Log("Commande bien éxécuté !");
        return true;
    }
}
