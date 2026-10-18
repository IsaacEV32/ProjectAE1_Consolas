using UnityEngine;

public class Coins : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        Inventory.Instance.IncreaseCoins();
        if (Inventory.Instance.GetCoins() > 100)
        {
            Inventory.Instance.IncreaseCassete();
            Inventory.Instance.ResetCoins();
        }
    }
}
