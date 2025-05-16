using System.Collections;
using UnityEngine;

public class StartWallFall : MonoBehaviour
{
    public AudioSource introClip;
    public GameObject wallObj;

    private bool hasTriggered = false;

     void Update()
     {
        if(!hasTriggered && !introClip.isPlaying && introClip.time > 0f)
        {
            wallObj.SetActive(false);
            hasTriggered = true;
            
        } 

     }


    
}
