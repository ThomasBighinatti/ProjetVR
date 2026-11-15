using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager Instance;

    void Awake()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
    }
    private int _money;
    
    public void AddMoney(int amount) => _money += amount;
    public void RemoveMoney(int amount) => _money -= amount;
    public void SetMoney(int amount) => _money = amount;
    
}
