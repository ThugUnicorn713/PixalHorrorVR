using UnityEngine;

public class ObjectHeard : MonoBehaviour
{
    public GameObject enemyObj;
    private Vector3 beastPos;
    private Vector3 objPos;

     void OnCollisionEnter(Collision other)
     {   
        if (other.gameObject.CompareTag("Ground"))
        {
            //play sound
            Debug.Log("Object touched the Ground");

            beastPos = enemyObj.transform.position;
            objPos = this.transform.position;

            float distance = Vector3.Distance(objPos, beastPos);

            if (distance <= 30f)
            {
                BeastScript.GetInstance().GoToObject(objPos);
            }
        }
     }
}
