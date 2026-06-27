using UnityEngine;
using System.Collections.Generic;

public class SinkManager : MonoBehaviour
{
    [Header("game settings")]
    [Tooltip("number of cans required to open exit")]
    public int targetCount = 5;
    
    [Tooltip("tag used to identify trash items")]
    public string trashTag = "Trash";

    [Header("interaction objects")]
    [Tooltip("door game object to deactivate when solved")]
    public GameObject exitDoor;
    
    [Tooltip("ui canvas to display upon winning")]
    public GameObject winCanvas;

    [Header("audio settings")]
    [Tooltip("sound to play when item is added")]
    public AudioSource successSound;

    private List<GameObject> cansInSink = new List<GameObject>();
    private bool isUnlocked = false;

    void Start()
    {
        if (winCanvas != null)
        {
            winCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isUnlocked) return;

        if (other.CompareTag(trashTag))
        {
            if (!cansInSink.Contains(other.gameObject))
            {
                cansInSink.Add(other.gameObject);
                Debug.Log("trash added! current count: " + cansInSink.Count + " / " + targetCount);

                if (successSound != null)
                {
                    successSound.Play();
                }

                checkWinCondition();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isUnlocked) return;

        if (other.CompareTag(trashTag))
        {
            if (cansInSink.Contains(other.gameObject))
            {
                cansInSink.Remove(other.gameObject);
                Debug.Log("trash removed! current count: " + cansInSink.Count + " / " + targetCount);
            }
        }
    }

    private void checkWinCondition()
    {
        if (cansInSink.Count >= targetCount)
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