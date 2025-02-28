using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public Button startButton;
    public Button exitButton;

    private void Awake()
    {
        startButton.onClick.AddListener(OnStartPressed);
        exitButton.onClick.AddListener(OnExitPressed);
    }

    private void OnStartPressed()
    {
        SceneManager.LoadScene(1);
    }

    private void OnExitPressed()
    {
        Application.Quit();
    }
}
