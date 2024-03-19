using UnityEngine;

public class GrabController : MonoBehaviour
{
    public Transform grabDetect;
    public Transform boxHolder;
    public float rayDist;

    void Update()
    {
        RaycastHit2D grabCheck = Physics2D.Raycast(grabDetect.position, Vector2.right * transform.localScale.x, rayDist);

        if (grabCheck.collider != null && grabCheck.collider.tag == "Box")
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                GrabBox(grabCheck.collider.gameObject);
            }
            else if (Input.GetKeyUp(KeyCode.G))
            {
                ReleaseBox(grabCheck.collider.gameObject);
            }
        }
    }

    void GrabBox(GameObject box)
    {
        box.transform.parent = boxHolder;
        box.transform.position = boxHolder.position;
        box.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    void ReleaseBox(GameObject box)
    {
        box.transform.parent = null;
        box.GetComponent<Rigidbody2D>().isKinematic = false;
    }

    // Draw Gizmos for both grabDetect and boxHolder
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(grabDetect.position, 0.1f);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(boxHolder.position, 0.1f);
    }
}
