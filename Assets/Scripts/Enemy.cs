using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private GameObject prefab2;

    public static GameObject bullet2;
    // Start is called before the first frame update
    void Start()
    {
        bullet2 = prefab2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            bullet2 = Instantiate(prefab2);
            bullet2.transform.position = transform.position;
        }
    }

    private void FixedUpdate()
    {
        bullet2.transform.forward = transform.forward;
        bullet2.transform.position += transform.forward * 5f * Time.fixedDeltaTime;
    }
}
