using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Button startGameButton;
    [SerializeField] Button settingsButton;
    [SerializeField] Button exitButton;

    [SerializeField] Text bestScoreText;

    [SerializeField] RectTransform settingsWindow;
    [SerializeField] Button acceptColorButton;
    [SerializeField] Image selectedColor;

    void Start()
    {
        bestScoreText.text = "Лучший счет: " + SaveController.GetBestScore().ToString();
        settingsWindow.gameObject.SetActive(false);
        startGameButton.onClick.AddListener(StartGame);
        settingsButton.onClick.AddListener(Settings);
        exitButton.onClick.AddListener(Exit);
        acceptColorButton.onClick.AddListener(AcceptColor);
    }

    void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Settings()
    {
        settingsWindow.gameObject.SetActive(true);
    }

    void AcceptColor()
    {
        SaveController.SetBallColor(selectedColor.color);
        settingsWindow.gameObject.SetActive(false);
    }

    void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
#if UNITY_ANDROID
        Application.Quit();
#endif
    }
}
