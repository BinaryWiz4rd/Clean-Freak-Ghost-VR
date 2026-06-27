using UnityEngine;
using System.Collections.Generic;

public class SinkManager : MonoBehaviour
{
    [Header("game settings")]
    public string trashTag = "Trash";

    private TrashCollector mainManager;
    private List<GameObject> cansInSink = new List<GameObject>();

    void Start()
    {
        mainManager = Object.FindFirstObjectByType<TrashCollector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(trashTag))
        {
            if (!cansInSink.Contains(other.gameObject))
            {
                cansInSink.Add(other.gameObject);
                if (mainManager != null)
                {
                    mainManager.addTrash(other.gameObject);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(trashTag))
        {
            if (cansInSink.Contains(other.gameObject))
            {
                cansInSink.Remove(other.gameObject);
                if (mainManager != null)
                {
                    mainManager.removeTrash();
                }
            }
        }
    }
}