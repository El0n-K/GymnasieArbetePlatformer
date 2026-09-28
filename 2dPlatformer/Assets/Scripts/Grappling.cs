using UnityEngine;

public class Grappling : MonoBehaviour
{
    [SerializeField] float grappleRange;
    [SerializeField] SpringJoint2D joint;
    [SerializeField] float desiredDistance;
    [SerializeField] LayerMask grapplable;
    [SerializeField] PlayerMovement player;
    [SerializeField] LineRenderer lineRenderer;
    Vector3 grapplePoint;
    bool isGrappling;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        joint.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Grapple();

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            StopGrapple();
        }
        if (isGrappling)
        {
            ShowGrapple();
        }
    }

    void Grapple()
    {

        Vector2 MouseDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, MouseDirection, grappleRange, grapplable);
        if (hit)
        {
            isGrappling = true;
            grapplePoint = hit.point;
            joint.enabled = true;
            joint.connectedAnchor = hit.point;
            joint.distance = Vector2.Distance(hit.point, transform.position) * desiredDistance;
            player.isGrappling = true;
        }
    }

    void StopGrapple()
    {
        isGrappling = false;
        joint.enabled = false;
        player.isGrappling = false;
        lineRenderer.positionCount = 0;
    }

    void ShowGrapple()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, grapplePoint);
    }
}
