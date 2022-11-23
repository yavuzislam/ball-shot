using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Top : MonoBehaviour
{
    public GameManager gameManager;
    Rigidbody rb;
    private void Start()
    {
        rb= GetComponent<Rigidbody>();//bunu burda bir kere �rnekledik performanstan kazand�k.
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Kova"))
        {
            gameObject.transform.localPosition= Vector3.zero;
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            rb.velocity= Vector3.zero;
            rb.angularVelocity= Vector3.zero;
            gameObject.SetActive(false);
            gameManager.TopGirdi();
        }
        else if (other.CompareTag("AltObje"))
        {
            gameObject.transform.localPosition = Vector3.zero;
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            gameObject.SetActive(false);
            gameManager.TopGirmedi();
        }
    }
}
