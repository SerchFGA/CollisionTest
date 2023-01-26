using UnityEngine;

public class MainObjectMovement : MonoBehaviour
{
    [Header("Points to travel the MainObject")]
    [SerializeField]
    private Transform[] Points;
    private int numPoints;

    [SerializeField]
    private float speedMovement;


    public bool isMoving = false;
    private Vector3 currentPoint = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        numPoints = 0;
        //Start Movement to the first Point
        goToPoint(Points[0].position);
    }

    public void goToPoint(Vector3 point)
    {
        transform.LookAt(point);
        numPoints++;
        currentPoint = point;
        isMoving= true;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, currentPoint);
        if (isMoving && distance > 0.05f && numPoints < Points.Length)
        {
            transform.Translate(Vector3.forward * speedMovement * Time.deltaTime);
        }else if (distance < 0.05f && numPoints < Points.Length)
        {
            goToPoint(Points[numPoints].position);
        }
        else
        {
            SoundsVFX.Instance.playWin();
            //Destroy MainObject
            Destroy(this);
        }
        
    }
}
