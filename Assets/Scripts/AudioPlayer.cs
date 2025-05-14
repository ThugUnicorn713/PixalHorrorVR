using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    
    public AudioClip footstepsAudio;

    public XROrigin rig;

    private CharacterController characterController;


    void Start()
    {
        if (audioSource == null )
        {
            Debug.LogError("AudioSources are not properly assigned.");
        }

        characterController = GetComponent<CharacterController>();
    }


    void Update()
    {
        if(characterController != null)
        {
            if (characterController.velocity.magnitude >= 0.3f)
            {
                StartFootstepsAudio();
            }
            else
            {
                StopFootstepsAudio();
            }
        }

    }

    public void StartFootstepsAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.clip = footstepsAudio;
            audioSource.loop = true;
            audioSource.Play(); 
        }
    }

    public void StopFootstepsAudio()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

   

}
