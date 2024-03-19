using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float SpeedAdded = 10f;
    public float WaitTime = 5f;
    public float DisableTime = 10f;
    private float originalRunSpeed;
    private Movement playerMovementScript;
    private bool Disabled = false;
    public Color disabledColor = new Color(1f, 0f, 0f);
    private SpriteRenderer spriteRenderer;
    private Color originalSpriteColor;
    private void Start()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer component not found on SpeedBoost GameObject!");
        }


        originalSpriteColor = spriteRenderer.color;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!Disabled && other.CompareTag("Player"))
        {
            playerMovementScript = other.GetComponent<Movement>();
            if (playerMovementScript != null)
            {
                originalRunSpeed = playerMovementScript.runSpeed;
                playerMovementScript.runSpeed += SpeedAdded;
                StartCoroutine(RemoveSpeed());
                StartCoroutine(DisableSpeedBoost());
            }
        }
    }
    IEnumerator RemoveSpeed()
    {

        yield return new WaitForSeconds(WaitTime);


        if (playerMovementScript != null)
        {
            playerMovementScript.runSpeed -= SpeedAdded;
            if (playerMovementScript.runSpeed < originalRunSpeed)
            {
                playerMovementScript.runSpeed = originalRunSpeed;
            }
        }
    }
    IEnumerator DisableSpeedBoost()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = disabledColor;
        }

        Disabled = true;
        yield return new WaitForSeconds(DisableTime);
        Disabled = false;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = originalSpriteColor;
        }
    }
}
