using UnityEngine;
using System.Collections;
using DG.Tweening;

public class MultipleSpike : MonoBehaviour {

    public CircleCollider2D multipleSpikeCol;
    public float startColRadius;
    public float activatedColRadius;
    public bool attackActivated;
    // Use this for initialization
    void Start ()
    {
        transform.DOScale(new Vector3(.35f,.35f,0), .5f).SetEase(Ease.OutQuint);
        multipleSpikeCol.radius = startColRadius;
        attackActivated = false;
    }

    void Update()
    {
        if (attackActivated)
        {
            StartCoroutine(RotateSpike());
        }
    }

    public IEnumerator RotateSpike()
    {
        transform.Rotate(new Vector3(0, 0, 45) * Time.deltaTime * 3);
        multipleSpikeCol.radius = activatedColRadius;
        yield return new WaitForSeconds(10);
        attackActivated = false;
        multipleSpikeCol.radius = startColRadius;
    }

}
