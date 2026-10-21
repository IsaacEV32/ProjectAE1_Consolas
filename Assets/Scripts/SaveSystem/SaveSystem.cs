
using UnityEngine;
public class SaveSystem : MonoBehaviour, ISaveSystem
{
    protected SaveSystemData data;
    protected Inventory inventory;
    protected static string savePath;
    public virtual void Awake()
    {
        inventory = GetComponent<Inventory>();
    }

    public virtual void Save()
    {

    }
    public virtual bool HasSaved()
    {
        return true;
    }
    public virtual void Load()
    {

    }
}
