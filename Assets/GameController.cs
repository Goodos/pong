using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject[] boards;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject leftWall;
    [SerializeField] GameObject rightWall;

    [SerializeField] Text scoreText;
    [SerializeField] Button mainMenuButton;

    private GameObject newBall;
    private Rigidbody2D[] rb = new Rigidbody2D[2];
    private Vector2 velocity = Vector2.left;
    private float speed = 5f;
    private Vector3 leftX;
    private Vector3 rightX;
    private Vector3 topY;
    private Vector3 botY;

    public static float score = 0f;

    void Start()
    {
        score = 0f;
        mainMenuButton.onClick.AddListener(MainMenu);

        leftX = Camera.main.ViewportToWorldPoint(new Vector3(0, .5f, 15f));
        rightX = Camera.main.ViewportToWorldPoint(new Vector3(1, .5f, 15f));
        topY = Camera.main.ViewportToWorldPoint(new Vector3(.5f, 1f, 15f));
        botY = Camera.main.ViewportToWorldPoint(new Vector3(.5f, 0, 15f));

        leftWall.transform.position = leftX;
        rightWall.transform.position = rightX;

        rb[0] = boards[0].GetComponent<Rigidbody2D>();
        rb[1] = boards[1].GetComponent<Rigidbody2D>();

        newBall = Instantiate(ball);
        newBall.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(SaveController.GetBallColor(), 1, 1);
    }

    private void Update()
    {
        scoreText.text = "Счет: " + score.ToString();
        if (newBall.transform.position.y <= botY.y || newBall.transform.position.y >= topY.y)
        {
            if (SaveController.GetBestScore() < score)
            {
                SaveController.SetBestScore(score);
            }
            score = 0f;
            Destroy(newBall);
            newBall = Instantiate(ball);
            newBall.GetComponent<SpriteRenderer>().color = Color.HSVToRGB(SaveController.GetBallColor(), 1, 1);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0, 15f));

            if (rb[0].position.x >= leftX.x + 1f & rb[0].position.x <= rightX.x - 1f)
            {
                rb[0].MovePosition(new Vector3(Mathf.Lerp(rb[0].position.x, mousePos.x, Time.fixedDeltaTime * 5f), rb[0].position.y, 0));
            }
            else
            {
            }
            /*
            if (Input.mousePosition.x <= Screen.width / 2)
            {
                if (rb[0].position.x >= leftX.x + 1f)
                    rb[0].MovePosition(rb[0].position + velocity * speed * Time.fixedDeltaTime);
            } 
            else 
            if (Input.mousePosition.x >= Screen.width / 2)
            {
                if (rb[0].position.x <= rightX.x - 1f)
                    rb[0].MovePosition(rb[0].position + -velocity * speed * Time.fixedDeltaTime);
            }*/
        }
        rb[1].position = new Vector2(rb[0].position.x, rb[1].position.y);
    }

    void MainMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
