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
    public GameObject ghostCharacter;
    public float ghostSpeed = 2f;

    [Header("audio settings")]
    public AudioSource backgroundMusic; 
    public AudioSource canDropSound;     
    public AudioSource winMusic;         
    public AudioSource ghostAngrySound;  

    private int currentCount = 0;
    private float timeRemaining;
    private bool isGameActive = false;
    private bool isGameOver = false;
    private Transform centerEyeCamera;

    private bool ghostShouldMove = false;
    private float ghostTimer = 0f;

    void Start()
    {
        timeRemaining = timeLimit;
        
        if (Camera.main != null)
        {
            centerEyeCamera = Camera.main.transform;
        }

        if (introCanvas != null) introCanvas.SetActive(true);
        if (winCanvas != null) winCanvas.SetActive(false);
        if (loseCanvas != null) loseCanvas.SetActive(false);
        if (ghostCharacter != null) ghostCharacter.SetActive(false);
        
        updateUI();
    }

    void Update()
    {
        if (isGameOver && ghostShouldMove && ghostCharacter != null && centerEyeCamera != null)
        {
            ghostTimer += Time.deltaTime;
            if (ghostTimer >= 5f)
            {
                Vector3 targetPosition = centerEyeCamera.position;
                targetPosition.y = ghostCharacter.transform.position.y; 

                ghostCharacter.transform.position = Vector3.MoveTowards(
                    ghostCharacter.transform.position, 
                    targetPosition, 
                    ghostSpeed * Time.deltaTime
                );

                Vector3 lookDirection = targetPosition - ghostCharacter.transform.position;
                if (lookDirection != Vector3.zero)
                {
                    ghostCharacter.transform.rotation = Quaternion.LookRotation(lookDirection);
                }
            }
            return;
        }

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
        
        if (canDropSound != null) canDropSound.Play();

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

        if (backgroundMusic != null) backgroundMusic.Stop();
        if (winMusic != null)
        {
            winMusic.loop = true;
            winMusic.Play();
        }
    }

    private void gameOverLose()
    {
        isGameOver = true;
        Debug.Log("game over! ghost lost patience.");

        if (ghostCharacter != null) ghostCharacter.SetActive(true);
        ghostShouldMove = true;
        ghostTimer = 0f;

        positionCanvasInFrontOfPlayer(loseCanvas);
        if (loseCanvas != null) loseCanvas.SetActive(true);

        if (backgroundMusic != null) backgroundMusic.Stop();
        if (ghostAngrySound != null)
        {
            ghostAngrySound.loop = true;
            ghostAngrySound.Play();
        }
    }

    private void positionCanvasInFrontOfPlayer(GameObject canvas)
    {
        if (canvas == null || centerEyeCamera == null) return;

        Vector3 spawnPosition = centerEyeCamera.position + (centerEyeCamera.forward * 1.5f);
        spawnPosition.y = centerEyeCamera.position.y; 

        canvas.transform.position = spawnPosition;

        Vector3 lookAtDirection = canvas.transform.position - centerEyeCamera.position;
        lookAtDirection.y = 0; 
        canvas.transform.rotation = Quaternion.LookRotation(lookAtDirection);
    }
}