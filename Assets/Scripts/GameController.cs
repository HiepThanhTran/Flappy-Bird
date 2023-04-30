using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public bool isEndGame;
    public Text txtPoint;
    public Text txtEndPoint;
    public Button btnRestart;
    public GameObject pnlEndGame;
    public GameObject pnlStartGame;
    public Sprite btnRestartIdle;
    public Sprite btnRestartHover;
    public Sprite btnRestartClick;
    public GameObject birdController;

    GameObject obj;
    int gamePoint;

    // Start is called before the first frame update
    void Start()
    {
        gamePoint = 0;
        obj = gameObject;
        isEndGame = false;
        Time.timeScale = 0;
        pnlEndGame.SetActive(false);
        pnlStartGame.SetActive(true);
        birdController.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (!isEndGame)
            {
                StartGame();
            }
        }
    }

    public void GetPoint()
    {
        gamePoint++;
        txtPoint.text = "Point: " + gamePoint;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        pnlStartGame.SetActive(false);
        birdController.SetActive(true);
    }

    public void EndGame()
    {
        isEndGame = true;
        Time.timeScale = 0;
        pnlEndGame.SetActive(true);
        txtEndPoint.text = "Your point:\n" + gamePoint;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartButtonnIdle()
    {
        btnRestart.GetComponent<Image>().sprite = btnRestartIdle;
    }

    public void RestartButtonnHover()
    {
        btnRestart.GetComponent<Image>().sprite = btnRestartHover;
    }

    public void RestartButtonnClick()
    {
        btnRestart.GetComponent<Image>().sprite = btnRestartClick;
    }
}
