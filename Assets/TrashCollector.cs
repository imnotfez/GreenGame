using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrashCollector : MonoBehaviour
{
    public int TrashCollected;
    [SerializeField] public int TotalTrashCount;
    public bool HasCollectedAllTrash;
    [SerializeField] private TextMeshProUGUI yourTextVariable;

    public GameObject newObjectPrefab; // Reference to the prefab to instantiate

    public Transform instantiateLocation1; // Position for the first instance
    public Transform instantiateLocation2; // Position for the second instance

    // Start is called before the first frame update
    void Start()
    {
        UpdateText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Box" tag
        if (collision.CompareTag("Box"))
        {
            // Increment the TrashCollected count
            TrashCollected++;

            // Instantiate new objects at specified locations
            InstantiateNewObject(instantiateLocation1.position, instantiateLocation1.rotation);
            InstantiateNewObject(instantiateLocation2.position, instantiateLocation2.rotation);

            // Destroy the collided object
            Destroy(collision.gameObject);

            // Update the TMP Text
            UpdateText();
        }
    }

    void UpdateText()
    {
        // Check if the yourTextVariable reference is not null
        if (yourTextVariable != null)
        {
            // Update the text with the number of trash collected
            yourTextVariable.text = "Trash Collected: " + TrashCollected.ToString();
        }
    }

    void InstantiateNewObject(Vector3 position, Quaternion rotation)
    {
        // Check if the newObjectPrefab is assigned
        if (newObjectPrefab != null)
        {
            // Instantiate the prefab at the specified position and rotation
            Instantiate(newObjectPrefab, position, rotation);
        }
        else
        {
            Debug.LogWarning("New object prefab is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if all trash has been collected
        if (TrashCollected >= TotalTrashCount)
        {
            HasCollectedAllTrash = true;
            // You can add additional logic here when all trash is collected
        }
    }
}
