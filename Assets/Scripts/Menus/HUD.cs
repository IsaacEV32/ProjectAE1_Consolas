using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] TMP_Text coinText;
    [SerializeField] TMP_Text casseteText;
    public static HUD instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UpdateCoinText(GameManager.Instance.inventory.GetCoins().ToString());
        UpdateCasseteText(GameManager.Instance.inventory.GetCassete().ToString());
    }
    public void UpdateCoinText(string value)
    {
        coinText.text = "Coins: " + value;
    }
    public void UpdateCasseteText(string value)
    {
        casseteText.text = "Cassetes: " + value;
    }
}
