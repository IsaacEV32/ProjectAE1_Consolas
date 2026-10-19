using UnityEngine;

public class Cassets : MonoBehaviour, ICollectable
{
    public void Collect() 
    {
        if (GameManager.Instance.inventory.GetCassete() < 99)
        {
            GameManager.Instance.inventory.IncreaseCassete();
        }
    }
}
