using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float timeToDestroy = 0.1f;
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(0, 0, 0, 0);
    public bool hasPackage;
    SpriteRenderer spriteRenderer;
    private void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("I bumped into something.");
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Debug.Log("Package picked up.");
            Destroy(other.gameObject, timeToDestroy);
        }

        if (other.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package delivered.");
        }
    }
}
