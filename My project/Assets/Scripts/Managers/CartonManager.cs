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
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        _pool = new ObjectPool<GameObject>(
            CreateBox,
            OnGetBox,
            OnReleaseBox,
            OnDestroyBox,
            defaultCapacity: amountToPool,
            maxSize: maxSize
        );
    }

    private GameObject CreateBox() => Instantiate(objectToPool);
    private void OnGetBox(GameObject box) => box.SetActive(true);
    private void OnReleaseBox(GameObject box) => box.SetActive(false);
    private void OnDestroyBox(GameObject box) => Destroy(box);
    
    private void SpawnBox()
    {
        GameObject box = _pool.Get();
    }

    public void DespawnBox(GameObject box)
    {
        _pool.Release(box);
    }
}