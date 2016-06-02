using UnityEngine;
using System.Collections;
using DG.Tweening;
public class pointsMove : MonoBehaviour {

    // Use this for initialization
    public SpriteRenderer sr;

    public float minimum = 0.0f;
    public float maximum = 1f;
    public float duration = 1.0f;
    private float startTime;


    void Awake()
    {
        sr = gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
   
    }

	void Start ()
    {
        transform.DOLocalMoveY(transform.position.y + 1,1).OnComplete(DestroyPoint);
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        float t = (Time.time - startTime) / duration;
        Debug.Log(t);
        sr.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(maximum, minimum, t));

    }

    void DestroyPoint()
    {
        Destroy(gameObject);
    }
}
