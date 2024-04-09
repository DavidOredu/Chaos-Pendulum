using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField]
    private LineRenderer line;
    [SerializeField]
    private HingeJoint2D joint;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private Transform ceiling;

    [SerializeField]
    private BobType bobType = BobType.Main;

    [SerializeField]
    private Vector2 startingForce;
    // Start is called before the first frame update
    void Start()
    {
        switch (bobType)
        {
            case BobType.Main:
                joint.connectedAnchor = ceiling.position;
                break;
            case BobType.Connected:
                joint.connectedBody = ceiling.GetComponent<Rigidbody2D>();
                break;
            default:
                break;
        }
        rb.AddForce(startingForce);

        line.positionCount = 2;

        line.SetPosition(0, transform.position);
        switch (bobType)
        {
            case BobType.Main:
                line.SetPosition(1, joint.connectedAnchor);
                break;
            case BobType.Connected:
                line.SetPosition(1, joint.connectedBody.position);
                break;
            default:
                break;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        line.positionCount = 2;

        line.SetPosition(0, transform.position);
        switch (bobType)
        {
            case BobType.Main:
            line.SetPosition(1, joint.connectedAnchor);
                break;
            case BobType.Connected:
            line.SetPosition(1, joint.connectedBody.position);
                break;
            default:
                break;
        }
    }
}
public enum BobType
{
    Main,
    Connected,
}
