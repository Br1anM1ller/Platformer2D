using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public FixedJoint2D fixedJoint;
    public TargetJoint2D targetJoint;
    public PointEffector2D pointEffector;
    public float effectorDuration = 2f;
    private bool isPlayerNear = false;
    private bool isArrowLaunched = false;

    private void Update()
    {
        if (isPlayerNear && fixedJoint != null)
        {
            Destroy(fixedJoint);
            fixedJoint = null;
            isArrowLaunched = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
        }
        else if (other.CompareTag("Target") && isArrowLaunched)
        {
            Collider2D arrowCollider = GetComponent<Collider2D>();
            if (arrowCollider != null)
            {
                arrowCollider.enabled = false;
            }

            StartCoroutine(ActivateEffector());
        }
    }

    private IEnumerator ActivateEffector()
    {
        pointEffector.enabled = true;
        yield return new WaitForSeconds(effectorDuration);
        pointEffector.enabled = false;
    }
}
