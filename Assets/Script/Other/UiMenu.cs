using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;  
#endif

public class UiMenu : MonoBehaviour
{
    public Button quitButton;  

    public Button playButton;   

    void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        playButton.onClick.AddListener(PlayGame);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }




    void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;  
        #else
            Application.Quit();  
        #endif
    }

    void PlayGame()
    {
        SceneManager.LoadScene("UniqueAssetHouse");
    }
}
