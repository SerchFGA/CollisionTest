using UnityEngine;

public class MainObjectCollition : MonoBehaviour
{
    
    private MainObjectMovement MOMovement;
    // Start is called before the first frame update
    void Start()
    {
        MOMovement= GetComponentInParent<MainObjectMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Points")
        {
            //Debug.Log("Points Detection");
            //Stop Movement
            MOMovement.isMoving = false;
            SoundsVFX.Instance.playCrash();
            //Destroy MainObject
            Destroy(transform.parent.gameObject);
            
        }
    }
}
