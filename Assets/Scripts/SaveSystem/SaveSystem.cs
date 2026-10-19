
using UnityEngine;
using System.IO;
public class SaveSystem : MonoBehaviour, ISaveSystem
{
    protected SaveSystemData data;
    protected Inventory inventory;
    protected string savePath;
    private void Start()
    {
        inventory = GetComponent<Inventory>();
        savePath = Application.persistentDataPath + "/savefile.json";
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
