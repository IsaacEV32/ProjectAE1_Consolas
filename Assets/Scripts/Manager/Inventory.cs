using UnityEngine;
public class Inventory : MonoBehaviour
{
    static int coins;
    static int cassete;
    Vector3 checkpoint;
    
    void Start()
    {
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

            coins = 0;
            cassete = 5;
        }
    }
    public Vector3 GetCheckPosition()
    {
        return checkpoint;
    }
    public int GetCoins()
    {
        return coins;
    }
    public int GetCassete()
    {
        return cassete;
    }
    public void SetCheckpoint(Transform newCheckPoint)
    {
        checkpoint = newCheckPoint.position;
    }
    public void SetData(SaveSystemData savedData)
    {
        checkpoint = savedData.checkpointPosition;
        coins = savedData.coins;
        cassete = savedData.cassetes;
    }
    public void SpawnPlayer()
    {
        this.transform.position = checkpoint;
    }
    public void IncreaseCassete()
    {
        cassete++;
        HUD.instance.UpdateCasseteText(cassete.ToString());
    }
    public void DecreaseCasseteLifes()
    { 
        cassete--;
        HUD.instance.UpdateCasseteText(cassete.ToString());
        
    }
    public void IncreaseCoins()
    {
        coins++;
        HUD.instance.UpdateCoinText(coins.ToString());
    }
    public void ResetCoins()
    {
        coins -= coins;
        HUD.instance.UpdateCoinText(coins.ToString());
    }
}
public interface ICollectable
{
    void Collect();
}
