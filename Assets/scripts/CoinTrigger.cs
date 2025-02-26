using UnityEngine;
using UnityEngine.Events;

public class CoinTrigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public UnityEvent OnCoinPickedUp = new();
    public bool CoinPicked = false;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider triggeredObject)
    {
        
        if (triggeredObject.CompareTag("Player") && !CoinPicked)
        {
            CoinPicked = true;
            OnCoinPickedUp?.Invoke();
            Debug.Log($"{gameObject.name} has been picked up");

            if (audioSource != null && audioSource.clip != null)
            {
                GameObject tempAudioObject = new GameObject("CoinSound"); // 🎵 Create a new GameObject for sound
                AudioSource tempAudio = tempAudioObject.AddComponent<AudioSource>();
                tempAudio.clip = audioSource.clip;
                tempAudio.volume = audioSource.volume;
                tempAudio.pitch = audioSource.pitch;
                tempAudio.Play();
                Destroy(tempAudioObject, tempAudio.clip.length); // 🔥 Destroy the temporary audio after it finishes
            }

            Destroy(transform.parent.gameObject);

        }
        
    }

    // Update is called once per frame

}
