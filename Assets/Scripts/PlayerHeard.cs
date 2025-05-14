using UnityEngine;

public class PlayerHeard : MonoBehaviour
{
    public Collider hearMeCollider;
    private Vector3 playerPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log(" The Beast heard me");

           playerPos = gameObject.transform.position;

           BeastScript.GetInstance().GoToPlayer(playerPos);
        }
        
    }

    
}
