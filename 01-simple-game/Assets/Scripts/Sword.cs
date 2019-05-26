using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private const float defaultAttackLength = 0.5f;
    private float attackLength = defaultAttackLength;

    // Update is called once per frame
    void Update()
    {
        attackLength -= Time.deltaTime;

        if (attackLength <= 0.0f)
        {
            gameObject.SetActive(false);
            attackLength = defaultAttackLength;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
