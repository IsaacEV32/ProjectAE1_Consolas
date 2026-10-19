using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{

    [SerializeField] LayerMask deathLayer;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void SafeCheckpointPosition()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            Inventory player = FindFirstObjectByType<Inventory>();
            if (player != null)
            {
                player.SpawnPlayer();
                Debug.Log("Player successfully spawned");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((deathLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            GameManager.Instance.inventory.DecreaseCasseteLifes();
            if (GameManager.Instance.inventory.GetCassete() < 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    GameManager.Instance.inventory.IncreaseCassete();
                }
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


}
