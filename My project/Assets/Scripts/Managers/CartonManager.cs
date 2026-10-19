using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CartonManager : MonoBehaviour
{
    
    public static CartonManager Instance;
    
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool = 20;
    [SerializeField] private int maxSize = 100;
    private ObjectPool<GameObject> _pool;
    
    
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        Instance = this;
    }

    private void SpawnBox()
    {
        
    }
}
