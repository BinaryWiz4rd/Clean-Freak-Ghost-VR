using UnityEngine;

public class TrashCollector : MonoBehaviour
{
    [Header("game settings")]
    public int targetCount = 5;

    [Header("interaction objects")]
    public GameObject exitDoor;
    public GameObject winCanvas;

    [Header("audio settings")]
    public AudioSource successSound;

    private int currentCount = 0;
    private bool isUnlocked = false;

    public void collectTrash(GameObject trashItem)
    {
        if (isUnlocked) return;

        currentCount++;
        Debug.Log("trash collected! current count: " + currentCount + " / " + targetCount);

        if (successSound != null)
        {
            successSound.Play();
        }

        Destroy(trashItem);

        if (currentCount >= targetCount)
        {
            isUnlocked = true;
            openExit();
        }
    }

    private void openExit()
    {
        Debug.Log("puzzle solved! exit open.");

        if (exitDoor != null)
        {
            exitDoor.SetActive(false);
        }

        if (winCanvas != null)
        {
            winCanvas.SetActive(true);
        }
    }
}