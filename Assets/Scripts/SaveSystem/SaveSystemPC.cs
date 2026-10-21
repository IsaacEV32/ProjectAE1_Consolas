using System.IO;
using UnityEngine;
public class SaveSystemPC : SaveSystem, ISaveSystem
{
    public override void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        if (File.Exists(savePath))
        {
            data = JsonUtility.FromJson<SaveSystemData>(File.ReadAllText(savePath));
        }
        else
        {
            data = new SaveSystemData();
        }
        base.Awake();
    }
    public override void Save()
    {
        data.checkpointPosition = inventory.GetCheckPosition();
        data.coins = inventory.GetCoins();
        data.cassetes = inventory.GetCassete();

        string jsonInventory = JsonUtility.ToJson(data);
        File.WriteAllText(savePath, jsonInventory);

    }
    public override bool HasSaved()
    {
        if (File.Exists(savePath))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public override void Load()
    {
        if (HasSaved())
        {
            string json = File.ReadAllText(savePath);
            JsonUtility.FromJsonOverwrite(json, data);

            GameManager.Instance.inventory.SetData(data);
        }
    }
}
