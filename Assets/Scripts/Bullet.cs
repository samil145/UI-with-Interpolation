using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody rgd;



    // Start is called before the first frame update
    void Start()
    {
        

        rgd = GetComponent<Rigidbody>();
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
        if (other.tag == "enemy")
        {
            

            //if (PlayerController.ultimateCounter == 3)
            //{
            //    //PlayerController.ultimateCounter = 1;
            //    //PlayerController.flag_ultimate2 = true;
            //} else
            //{
            

            PlayerController.ultimateCounter += 10;
            PlayerController.flag_ultimate = true;
            if (PlayerController.ultimateCounter == 30)
            {
                PlayerController.flag_ultimate2 = true;
                //PlayerController.ultimateCounter = 0;
               
            }
            gameObject.SetActive(false);
        }

         
        
    }
}
