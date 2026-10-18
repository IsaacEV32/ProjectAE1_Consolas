using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] Transform checkpoint;
    [SerializeField] LayerMask deathLayer;

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    static void SafeCheckpointPosition()
    {
        DeathPlayer player = FindFirstObjectByType<DeathPlayer>();
        if (player != null)
        {
            player.SpawnPlayer();
            Debug.Log("Player successfully spawned");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if ((deathLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            Inventory.Instance.DecreaseCasseteLifes();
            if (Inventory.Instance.GetCassete() < 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    Inventory.Instance.IncreaseCassete();
                }
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    public void SetCheckpoint(Transform newCheckPoint)
    {
        checkpoint = newCheckPoint;
    }
    public void SpawnPlayer()
    {
        this.transform.position = checkpoint.position;
    }

}
