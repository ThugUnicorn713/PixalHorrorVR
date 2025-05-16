using UnityEngine;

public class ObjectHeard : MonoBehaviour
{
    public GameObject enemyObj;
    public AudioSource staticClip;

    private Vector3 beastPos;
    private Vector3 objPos;


     void OnCollisionEnter(Collision other)
     {   
        if (other.gameObject.CompareTag("Ground"))
        {
            GetComponent<AudioSource>().Play();

            Debug.Log("Object touched the Ground");

            beastPos = enemyObj.transform.position;
            objPos = this.transform.position;

            float distance = Vector3.Distance(objPos, beastPos);

            if (distance <= 50f)
            {
                BeastScript.GetInstance().GoToObject(objPos);
            }
        }
     }
}
