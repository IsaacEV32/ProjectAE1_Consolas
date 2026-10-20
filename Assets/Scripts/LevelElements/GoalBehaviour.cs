using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalBehaviour : MonoBehaviour
{
    [SerializeField] LayerMask playerLayer;
    int mainMenuSceneIndex = 0;
    private void OnTriggerEnter(Collider other)
    {
        if ((playerLayer.value & (1 << other.gameObject.layer)) != 0)
        {
            GameManager.Instance.saveSystem.Save();
            SceneManager.LoadScene(mainMenuSceneIndex);
        }

    }
}
