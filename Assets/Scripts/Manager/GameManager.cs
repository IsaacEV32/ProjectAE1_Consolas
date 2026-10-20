using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public SaveSystem saveSystem;
    public Inventory inventory;
    public static GameManager Instance;
    [SerializeField] TMP_Text applicationVersionText;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
#if DEVELOPMENT_PC
        this.gameObject.AddComponent(typeof(SaveSystemPC));
        saveSystem = GetComponent<SaveSystem>();
        applicationVersionText.text = "Platform Version: " + Application.platform + " Version: " + Application.version;

#elif PC_RELEASE

        this.gameObject.AddComponent(typeof(SaveSystemPC));
        saveSystem = GetComponent<SaveSystem>();
        Destroy(applicationVersionText.gameObject);
#elif UNITY_EDITOR
        this.gameObject.AddComponent(typeof(SaveSystemPC));
        saveSystem = GetComponent<SaveSystem>();
        applicationVersionText.text = "Platform Version: " + Application.platform + " Version: " + Application.version;
#endif
        inventory = GetComponent<Inventory>();
        saveSystem.Load();
    }
}
