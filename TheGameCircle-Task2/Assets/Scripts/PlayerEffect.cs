using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class PlayerEffect : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera vcam;
    private Rigidbody rb;
    private PlayerMovement playerMovement;
    [SerializeField] private TMP_Text tmp;


    private void Awake()
    {
        rb = gameObject.transform.GetComponent<Rigidbody>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        tmp.text = PlayerDatas.Score.ToString();
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
            SceneManager.gameOver = true;
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
            SceneManager.nextScene = true;
        }

        if (other.CompareTag("MergePlus"))
        {
            Debug.Log("Mergelendin");
            gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            Destroy(other.gameObject);
        }

        if (other.CompareTag("Box"))
        {
            PlayerDatas.Score++;
            gameObject.transform.localScale = new Vector3(0.79f, 0.79f, 0.79f);
        }
    }
}
