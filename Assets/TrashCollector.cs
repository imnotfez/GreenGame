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
