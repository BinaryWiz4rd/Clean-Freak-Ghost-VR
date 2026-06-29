using UnityEngine;

public class VRFootsteps : MonoBehaviour
{
    public AudioSource footstepAudioSource;
    public float stepInterval = 0.5f;
    public float speedThreshold = 0.1f;

    private Transform cameraTransform;
    private Vector3 lastPosition;
    private float stepTimer;

    void Start()
    {
        if (Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
            lastPosition = cameraTransform.position;
        }
        else
        {
            cameraTransform = transform;
            lastPosition = transform.position;
        }

        if (footstepAudioSource != null)
        {
            footstepAudioSource.loop = false;
            footstepAudioSource.playOnAwake = false;
        }
    }

    void Update()
    {
        if (cameraTransform == null) return;

        Vector3 currentPosition = cameraTransform.position;
        currentPosition.y = 0;
        Vector3 previousPosition = lastPosition;
        previousPosition.y = 0;

        float distanceMoved = Vector3.Distance(currentPosition, previousPosition);
        float currentSpeed = distanceMoved / Time.deltaTime;

        if (currentSpeed > speedThreshold)
        {
            stepTimer += Time.deltaTime;
            if (stepTimer >= stepInterval)
            {
                playFootstep();
                stepTimer = 0f;
            }
        }
        else
        {
            stepTimer = stepInterval;
        }

        lastPosition = cameraTransform.position;
    }

    private void playFootstep()
    {
        if (footstepAudioSource != null && !footstepAudioSource.isPlaying)
        {
            footstepAudioSource.pitch = Random.Range(0.85f, 1.15f);
            footstepAudioSource.Play();
        }
    }
}