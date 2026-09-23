using UnityEngine;

public class Grappling : MonoBehaviour
{
    [SerializeField] float grappleRange;
    [SerializeField] SpringJoint2D joint;
    [SerializeField] float desiredDistance;
    [SerializeField] LayerMask grapplable;
    [SerializeField] PlayerMovement player;
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
    }

    void Grapple()
    {
        Vector2 MouseDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, MouseDirection, grappleRange, grapplable);
        if (hit)
        {
            joint.enabled = true;
            joint.connectedAnchor = hit.point;
            joint.distance = Vector2.Distance(hit.point, transform.position) * desiredDistance;
            player.isGrappling = true;
        }
    }

    void StopGrapple()
    {
        joint.enabled = false;
        player.isGrappling = false;
    }
}
