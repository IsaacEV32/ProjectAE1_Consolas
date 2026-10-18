using UnityEngine;
public class Inventory : MonoBehaviour
{
    static int coins;
    static int cassete;
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else 
        {
            Destroy(this.gameObject);
        }
    }
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
    public int GetCoins()
    {
        return coins;
    }
    public int GetCassete()
    {
        return cassete;
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
