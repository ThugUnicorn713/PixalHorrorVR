using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class PlayerScript : MonoBehaviour
{
    public Collider hearMeCollider;
    public XROrigin rig;

    public float fullSpeedMax = 3.0f;
    public float colActiveDuration = 15f;
    public float timeAtFullSpeed = 15f;

    private CharacterController characterController;
    private float activeSpeedTime = 0f;
    public bool canHearMe = false; 

    
    void Start()
    {
            
        characterController = rig.GetComponent<CharacterController>();

        if (hearMeCollider != null)
        {
            hearMeCollider.enabled = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        float speed = characterController.velocity.magnitude;

        if(!hearMeCollider.enabled && speed >= fullSpeedMax)
        {
            activeSpeedTime += Time.deltaTime;

            if (activeSpeedTime >= timeAtFullSpeed)
            {
                beastCanHearPlayer();

            }
        }
        
    }

    void beastCanHearPlayer()
    {
        if (hearMeCollider != null)
        {
            canHearMe = true;
            hearMeCollider.enabled = true;

            StartCoroutine(DisableHearMeCollider());   

        }
    }

    IEnumerator DisableHearMeCollider()
    {
        yield return new WaitForSeconds(colActiveDuration);

        if(hearMeCollider != null)
        {
            activeSpeedTime = 0;
            hearMeCollider.enabled=false;
            canHearMe = false;
        }
    }
}
