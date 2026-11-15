using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class CartonManager : MonoBehaviour
{
    public static CartonManager Instance;

    [Header("Pool")]
    [SerializeField] private GameObject objectToPool;
    [SerializeField] private int amountToPool = 2;
    [SerializeField] private int maxSize = 5;

    [Header("Conveyor belt")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform restPoint; // endroit ou la box s'arrete
    [SerializeField] private Transform endPoint;
    [SerializeField] private float speed = 1f;
    [SerializeField] private int rewardPerBox = 10;

    private ObjectPool<GameObject> _pool;
    private GameObject _currentBox;
    private bool _isBusy;

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

    private void Start()
    {
        _currentBox = SpawnBox(restPoint.position); //premier carton prcq bah sinon y'en a pas
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnButtonPressed();
        }
    }

    private GameObject CreateBox() => Instantiate(objectToPool);
    private void OnGetBox(GameObject box) => box.SetActive(true);
    private void OnReleaseBox(GameObject box) => box.SetActive(false);
    private void OnDestroyBox(GameObject box) => Destroy(box);

    private GameObject SpawnBox(Vector3 position)
    {
        GameObject box = _pool.Get();
        box.transform.SetPositionAndRotation(position, spawnPoint.rotation);
        return box;
    }

    public void DespawnBox(GameObject box) => _pool.Release(box);
    
    public void OnButtonPressed() //la c'est a toi de faire jewbuzz
    {
        if (_isBusy) return;
        StartCoroutine(CycleRoutine());
    }
    
    

    private IEnumerator CycleRoutine()
    {
        _isBusy = true;
        
        yield return MoveBox(_currentBox, endPoint.position);
        
        DespawnBox(_currentBox);
        //MoneyManager.Instance.AddMoney(rewardPerBox); 
        
        _currentBox = SpawnBox(spawnPoint.position);
        yield return MoveBox(_currentBox, restPoint.position);

        _isBusy = false;
    }

    private IEnumerator MoveBox(GameObject box, Vector3 target)
    {
        Rigidbody rb = box.GetComponent<Rigidbody>(); 
        var wait = new WaitForFixedUpdate(); //tick

        while ((target - rb.position).sqrMagnitude > 0.0001f) //check si le carton est a - de ~1cm
        {
            Vector3 next = Vector3.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime); //prochaine pos ou aller
            rb.MovePosition(next);
            yield return wait; //attend jusqu'au prochain tick
        }

        rb.MovePosition(target);
    }
}