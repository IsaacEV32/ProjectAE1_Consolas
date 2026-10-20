using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public void ResumeGame()
    {
        EventSystem.current.SetSelectedGameObject(null);
        Time.timeScale = 1f;
        InvokePauseMenu.instance.SetGamePaused(false);
        gameObject.SetActive(false);
    }
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        InvokePauseMenu.instance.SetGamePaused(false);
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        GameManager.Instance.saveSystem.Save();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
