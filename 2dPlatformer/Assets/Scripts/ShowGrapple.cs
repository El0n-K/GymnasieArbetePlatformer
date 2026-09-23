using UnityEngine;

public class ShowGrapple : MonoBehaviour
{
    [SerializeField] SpringJoint2D spring;
    [SerializeField] LineRenderer line;

    void Start()
    {
        spring = GetComponent<SpringJoint2D>();
        line = GetComponent<LineRenderer>();

        line.positionCount = 2;
    }

    void Update()
    {
        line.SetPosition(0, transform.position);

        if (spring.connectedBody != null)
        {
            line.SetPosition(1, spring.connectedBody.transform.position);
        }
    }
}