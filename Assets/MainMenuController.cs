using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] Button startGameButton;
    [SerializeField] Button settingsButton;

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
}
