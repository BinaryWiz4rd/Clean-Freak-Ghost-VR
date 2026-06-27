using UnityEngine;
using TMPro;

public class TrashCollector : MonoBehaviour
{
    [Header("game settings")]
    public int targetCount = 5;
    public float timeLimit = 60f; 

    [Header("ui elements")]
    public TextMeshProUGUI checklistText;
    public TextMeshProUGUI timerText;
    public GameObject introCanvas;
    public GameObject winCanvas;
    public GameObject loseCanvas;

    [Header("interaction objects")]
    public GameObject exitDoor;

    [Header("audio settings")]
    public AudioSource successSound;
    public AudioSource ghostAngrySound;

    private int currentCount = 0;
    private float timeRemaining;
    private bool isGameActive = false;
    private bool isGameOver = false;

    void Start()
    {
        timeRemaining = timeLimit;
        
        if (introCanvas != null) introCanvas.SetActive(true);
        if (winCanvas != null) winCanvas.SetActive(false);
        if (loseCanvas != null) loseCanvas.SetActive(false);
        
        updateUI();
    }

    void Update()
    {
        if (!isGameActive || isGameOver) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining < 0) timeRemaining = 0;
            updateUI();
        }
        else
        {
            gameOverLose();
        }
    }

    public void startGame()
    {
        if (introCanvas != null) introCanvas.SetActive(false);
        isGameActive = true;
    }

    public void addTrash(GameObject trashItem)
    {
        if (isGameOver || !isGameActive || trashItem == null) return;

        currentCount++;
        Debug.Log("trash added! current count: " + currentCount + " / " + targetCount);

        if (successSound != null) successSound.Play();
        
        Destroy(trashItem);
        
        updateUI();

        if (currentCount >= targetCount)
        {
            gameOverWin();
        }
    }

    public void removeTrash()
    {
        if (isGameOver || !isGameActive) return;

        currentCount = Mathf.Max(0, currentCount - 1);
        Debug.Log("trash removed! current count: " + currentCount + " / " + targetCount);
        updateUI();
    }

    private void updateUI()
    {
        if (checklistText != null)
        {
            checklistText.text = "• clean cans: " + currentCount + " / " + targetCount;
        }

        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60F);
            int seconds = Mathf.FloorToInt(timeRemaining % 60F);
            timerText.text = string.Format("time left: {0:00}:{1:00}", minutes, seconds);
        }
    }

    private void gameOverWin()
    {
        isGameOver = true;
        Debug.Log("puzzle solved! exit open.");

        if (exitDoor != null) exitDoor.SetActive(false);
        if (winCanvas != null) winCanvas.SetActive(true);
    }

    private void gameOverLose()
    {
        isGameOver = true;
        Debug.Log("game over! ghost lost patience.");

        if (loseCanvas != null) loseCanvas.SetActive(true);
        if (ghostAngrySound != null) ghostAngrySound.Play();
    }
}