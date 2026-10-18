using UnityEngine;

public class Cassets : MonoBehaviour, ICollectable
{
    public void Collect() 
    {
        if (Inventory.Instance.GetCassete() < 99)
        {
            Inventory.Instance.IncreaseCassete();
        }
    }
}
