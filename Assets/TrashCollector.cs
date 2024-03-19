using UnityEngine;
using TMPro;

public class TrashCollector : MonoBehaviour
{
    public static int TotalTrashCollected; // Static variable to track total trash collected across all instances
    public int TotalTrashCount;
    public bool HasCollectedAllTrash;
    [SerializeField] private TextMeshProUGUI yourTextVariable;

    public GameObject firstObjectPrefab; // Reference to the first prefab to instantiate
    public GameObject secondObjectPrefab; // Reference to the second prefab to instantiate

    public Transform instantiateLocation1; // Position for the first instance
    public Transform instantiateLocation2; // Position for the second instance

    private int trashCollectedCounter = 0;

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
            trashCollectedCounter++;

            if (trashCollectedCounter == 1)
            {
                // Instantiate the first object at the first location
                InstantiateNewObject(firstObjectPrefab, instantiateLocation1.position, instantiateLocation1.rotation);
            }
            else if (trashCollectedCounter == 2)
            {
                // Instantiate the second object at the second location
                InstantiateNewObject(secondObjectPrefab, instantiateLocation2.position, instantiateLocation2.rotation);
            }

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
            yourTextVariable.text = "Seeds Planted: " + TrashCollected.ToString();
        }
    }

    void InstantiateNewObject(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        // Check if the prefab is assigned
        if (prefab != null)
        {
            // Instantiate the prefab at the specified position and rotation
            Instantiate(prefab, position, rotation);
        }
        else
        {
            Debug.LogWarning("Prefab is not assigned!");
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

    // Instance variable to track trash collected by this instance
    private int TrashCollected;

    // Update the total trash collected across all instances when this instance is destroyed
    private void OnDestroy()
    {
        TotalTrashCollected += TrashCollected;
    }
}
