using UnityEngine;

public class WhisperClue : MonoBehaviour
{
    public AudioSource whisperClip;
    public GameObject portal;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<AudioSource>().Play();
            portal.SetActive(true);
            Debug.Log("Portal is up!");
        }

    }
}
