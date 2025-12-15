using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class UiGameOver : MonoBehaviour
{
    public Button quitButton;   

    public Button newGameButton;
    public Button restartButton;  
    void Start()
    {
        quitButton.onClick.AddListener(QuitGame);
        newGameButton.onClick.AddListener(StartNewGame);
        restartButton.onClick.AddListener(RestartGame);
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

    

    void StartNewGame()
    {
        SceneManager.LoadScene("UniqueAssetHouse");  
    }

    void RestartGame()
    {
        SceneManager.LoadScene("Maze"); 
    }
}
