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
    
    private void AddMoney(int amount) => _money += amount;
    private void RemoveMoney(int amount) => _money -= amount;
    private void SetMoney(int amount) => _money = amount;
    
}
