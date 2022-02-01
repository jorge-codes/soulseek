using System;
using System.Net.NetworkInformation;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace Soulseek
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rigidBody;
        [SerializeField] private float speed = 0.5f;
        [SerializeField] private float jump = 100f;
        private Vector2 direction;
        private int layerPlatform;
        private float mass;

        private void Start()
        {
            if (rigidBody == null)
            {
                Debug.LogError("No rigidbody assigned");
            }

            mass = rigidBody.mass;
            layerPlatform = LayerMask.NameToLayer("Platform");
        }

        private void Update()
        {
            direction.x = Input.GetAxis("Horizontal");
            if (Input.GetButtonDown("Jump"))
            {
                Debug.Log("JUMP!!!");
                rigidBody.AddForce(Vector2.up * jump, ForceMode2D.Impulse);
            }
        }

        private void LateUpdate()
        {
            direction.Normalize();
            rigidBody.AddForce(direction * speed, ForceMode2D.Force);
            if (direction.magnitude > 0f)
            {
                
            }
        }
    }
}
