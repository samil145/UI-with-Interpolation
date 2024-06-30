using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    private Rigidbody rgd2;
    PlayerController playerController;
    
    // Start is called before the first frame update
    void Start()
    {
        rgd2 = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    GameObject.Find("Sphere(Clone)").SetActive(false);
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall")
        {
            gameObject.SetActive(false);
        }
        if (other.name == "Boi")
        {
            PlayerController.flag_bullet2 = true;
            gameObject.SetActive(false);
        }
    }
}
