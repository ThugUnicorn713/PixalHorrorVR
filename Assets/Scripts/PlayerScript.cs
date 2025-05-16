using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class PlayerScript : MonoBehaviour
{
    //public Collider hearMeCollider;
    public XROrigin rig;

    public float fullSpeedMax = 3.0f;
    public float colActiveDuration = 15f;
    public float timeAtFullSpeed = 15f;

    private CharacterController characterController;
    private float activeSpeedTime = 0f;
    public bool canHearMe = false;

    private Vector3 playerPos;
    private Vector3 beastPos;
    public GameObject beast;

    public GameObject noiseIcon;


    void Start()
    {

        characterController = rig.GetComponent<CharacterController>();

    }

    
    void Update()
    {
        float speed = characterController.velocity.magnitude;

        if( speed >= fullSpeedMax)
        {
            activeSpeedTime += Time.deltaTime;

            if (activeSpeedTime >= timeAtFullSpeed)
            {
                beastCanHearPlayer();

            }
        }
        

        if (canHearMe)
        {
            if (noiseIcon != null)
            {
                noiseIcon.SetActive(true);
            }

        }
        else
        {
            noiseIcon.SetActive(false);
        }


    }

    void beastCanHearPlayer()
    {
        beastPos = beast.transform.position;
        playerPos = gameObject.transform.position;

        float distance = Vector3.Distance(beastPos, playerPos);

        if (distance <= 100f)
        {
            canHearMe = true;
            BeastScript.GetInstance().GoToPlayer(playerPos);
            StartCoroutine(DisableHearMe());
        }
        else
        {
            Debug.Log("The Beast is too far");
            activeSpeedTime = 0f;
        }

    }

    IEnumerator DisableHearMe()
    {
        yield return new WaitForSeconds(15f);
        canHearMe = false;
        activeSpeedTime = 0f;
        Debug.Log("Beast can no longer hear me");
        
    }
}
