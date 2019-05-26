using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody playerBody;

    [SerializeField] private Game game;

    [SerializeField] private TextMeshProUGUI coinText;

    private GameObject sword;

    private bool jump;

    private int coins;

    private Vector3 inputVector;

    // Start is called before the first frame update
    void Start()
    {
        sword = transform.GetChild(0).gameObject;
        playerBody = GetComponent<Rigidbody>();
        game = FindObjectOfType<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal") * 10f, playerBody.velocity.y, Input.GetAxis("Vertical") * 10f);
        transform.LookAt(transform.position + new Vector3(inputVector.x, 0, inputVector.z));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Attack"))
        {
            PerformAttack();
        }
    }

    void FixedUpdate()
    {
        playerBody.velocity = inputVector;
        if (jump && IsGrounded())
        {
            playerBody.AddForce(Vector3.up * 10f, ForceMode.Impulse);
            jump = false;
        }
    }

    bool IsGrounded()
    {
        float distance = GetComponent<Collider>().bounds.extents.y + 0.1f;
        Ray ray = new Ray(transform.position, Vector3.down);

        return Physics.Raycast(ray, distance);
    }

    private void PerformAttack()
    {
        if (!sword.activeSelf)
        {
            sword.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            game.ReloadCurrentLevel();
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            other.gameObject.GetComponent<Goal>().CheckForCompletion(coins);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Coin":
                coins++;
                //update the UI
                coinText.text = $"Coins\n{coins}";
                Destroy(other.gameObject);
                break;
        }
    }
}
