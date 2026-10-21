using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    [SerializeField] int returnSceneIndex = 0;
    private void OnTriggerEnter(Collider other)
    {
        if ((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            GameManager.Instance.inventory.SetCheckpoint(Vector3.zero);
            GameManager.Instance.saveSystem.Save();
            SceneManager.LoadScene(returnSceneIndex);
        }

    }
}
