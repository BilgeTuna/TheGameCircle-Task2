using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    private Rigidbody rb;
    private PlayerMovement playerMovement;

    private void Awake()
    {
        rb = gameObject.transform.GetComponent<Rigidbody>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obs")
        {
            vcam.GetComponent<CinemachineVirtualCamera>().LookAt = null;
            vcam.GetComponent<CinemachineVirtualCamera>().Follow = null;
            Vector3 force = new Vector3(0f, 1f, -10f);
            rb.AddForce(force, ForceMode.Impulse);
            playerMovement.enabled = false;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Debug.Log("Finish");
            vcam.GetComponent<CinemachineVirtualCamera>().LookAt = null;
            vcam.GetComponent<CinemachineVirtualCamera>().Follow = null;
            playerMovement.enabled = false;
        }
    }
}
