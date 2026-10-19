using System;
using UnityEngine;
[Serializable]
public class SaveSystemData
{
    public Vector3 checkpointPosition;
    public int coins;
    public int cassetes;
}
public interface ISaveSystem
{
    void Save();
    void Load();
    bool HasSaved();
}