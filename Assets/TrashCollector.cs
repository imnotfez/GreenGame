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

            // Instantiate a new object at a specific position
            InstantiateNewObject();

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

    void InstantiateNewObject()
    {
        // Check if the newObjectPrefab is assigned
        if (newObjectPrefab != null)
        {
            // Instantiate the prefab at a specific position (you can adjust the position as needed)
            Instantiate(newObjectPrefab, transform.position + new Vector3(1, 0, 0), Quaternion.identity);
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
