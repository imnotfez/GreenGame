using UnityEngine;

public class ClickToInstantiate : MonoBehaviour
{
    public GameObject objectToInstantiate; // The object to instantiate
    public Vector3 instantiationOffset; // Offset from the clicked position where the new object will be instantiated

    void Update()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera through the mouse cursor position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits an object
            if (Physics.Raycast(ray, out hit))
            {
                // Instantiate the object at the position of the hit point with the specified offset
                Instantiate(objectToInstantiate, hit.point + instantiationOffset, Quaternion.identity);
            }
        }
    }
}
