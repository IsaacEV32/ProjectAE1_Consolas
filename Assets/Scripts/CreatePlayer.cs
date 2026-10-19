using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        GameObject playerInstance = Instantiate(player, this.transform.position, this.transform.rotation);
        GameManager.Instance.inventory.SetCheckpoint(this.transform);
    }

}
