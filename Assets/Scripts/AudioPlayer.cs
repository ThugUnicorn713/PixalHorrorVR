using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audioSource;
    
    public AudioClip footstepsAudio;

    public XROrigin rig;

    private DynamicMoveProvider moveBrain;


    void Start()
    {
        if (audioSource == null )
        {
            Debug.LogError("AudioSources are not properly assigned.");
        }

        if (rig != null)
        {
            moveBrain = rig.GetComponentInChildren<DynamicMoveProvider>();
        }
        else
        {
            Debug.Log("Audio cant find the player!");
        }
    }


    void Update()
    {
        if(moveBrain != null)
        {
            if(moveBrain.rightHandMovementDirection > 0)
            {
                FootstepsAudio();
            }
            else
            {
                StopFootstepsAudio();
            }
        }

    }

    public void FootstepsAudio()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(footstepsAudio);
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
