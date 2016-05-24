using UnityEngine;
using System.Collections;

public class LookAt : MonoBehaviour {

    //public Quaternion lookRotation = new Quaternion();
    //private Vector2 _direction = Vector2.zero;
    public Vector3 dir;
    public Transform target;
    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 vectorToTarget = target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - 90f;
        Debug.Log(angle);
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 100);
    }

    /*public void lookAt(Vector2 target, bool instant = false)
    {
        //find the vector pointing from our position to the target
        _direction = (target - transform.position).normalized;

        if (_direction != Vector2.zero) {
            //create the rotation we need to be in to look at the target
            lookRotation = Quaternion.LookRotation(_direction);

            if (instant) {
                transform.rotation = new Quaternion(transform.rotation.x, lookRotation.y, transform.rotation.z, lookRotation.w);
            }
        }

    }*/
}

/*Vector3 dir = target.position - transform.position;
 float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
 transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);*/


/* Vector2 LookAtPoint = new Vector2(Target.transform.position.z, Target.transform.position.y);
transform.LookAt(new Vector3(0,LookAtPoint.y,LookAtPoint.x)*/
