using UnityEngine;

public class SubHouseOff : MonoBehaviour
{
    public Collider houseCollider;
    public GameObject houseSound;
    public GameObject houseNote;
    void Start()
    {
        if(houseCollider == null)
        {
            Debug.Log("I cant find the sub house!");
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            houseCollider.enabled = false;
            houseSound.SetActive(true);
            houseNote.SetActive(true);
            Debug.Log("I turned off the sub house collider,sound is on and Note is up!");
        }

    }


}
