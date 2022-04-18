using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Material[] Materials;
    public ParticleSystem Particle;
    [SerializeField] private float _movementSpeed;
    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        
        transform.position = new Vector3(transform.position.x + Horizontal * _movementSpeed * Time.deltaTime, transform.position.y, transform.position.z + Vertical * _movementSpeed * Time.deltaTime);
    }

    private void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.collider.CompareTag("Lava"))
        {
            if (transform.localScale.x <= 2)
            {
                transform.localScale *= 1.1f;
                transform.GetComponent<MeshRenderer>().material = Materials[0];
            }
            else if (transform.localScale.x <= 3)
            {
                transform.localScale *= 1.1f;
                transform.GetComponent<MeshRenderer>().material = Materials[1];
            }
            else if (transform.localScale.x <= 4.5f)
            {
                transform.GetComponent<MeshRenderer>().material = Materials[2];
                Particle.Play();
                gameObject.SetActive(false);
            }
        }
    }
}
