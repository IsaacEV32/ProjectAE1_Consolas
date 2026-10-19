using UnityEngine;
using System.IO;
public class SaveSystemPC : SaveSystem, ISaveSystem
{
    public override void Save()
    {
        data = new SaveSystemData();
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
            JsonUtility.FromJsonOverwrite(savePath, data);

            GameManager.Instance.inventory.SetData(data);
        }
    }
}
