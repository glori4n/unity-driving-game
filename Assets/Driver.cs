using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 1;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float slowdownSpeed = 10f;
    [SerializeField] float timer;
    float moveAmount;
    float steerAmount;
    float actualSpeed;
    bool isBoosted;
    bool isSlowed;
    Delivery delivery;
    void Start()
    {

    }

    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        } else {
            isBoosted = false;
            isSlowed = false;
        }

        if (isBoosted && timer > 0) {
            actualSpeed = boostSpeed;
        }

        if (isSlowed && timer > 0) {
            actualSpeed = slowdownSpeed;
        }

        if (!isBoosted && !isSlowed) {
            actualSpeed = moveSpeed;
        }

        moveAmount = Input.GetAxis("Vertical") * actualSpeed * Time.deltaTime;
        steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Boost")
        {
            isBoosted = true;
            timer = 7;
            Destroy(other.gameObject, 0.1f);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        isSlowed = true;
        timer = 7;
        Debug.Log("I bumped into something.");
    }
}
