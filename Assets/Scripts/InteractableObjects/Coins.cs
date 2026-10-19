using UnityEngine;

public class Coins : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        GameManager.Instance.inventory.IncreaseCoins();
        if (GameManager.Instance.inventory.GetCoins() > 100)
        {
            GameManager.Instance.inventory.IncreaseCassete();
            GameManager.Instance.inventory.ResetCoins();
        }
    }
}
