using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UIElements;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject speedBar;
    [SerializeField] UnityEngine.UI.Slider slider_speed;
    [SerializeField] UnityEngine.UI.Image fill_speed;
    [SerializeField] float currentVelocity_speed = -5;

    public float currentVelocity = 0.0f;
    public static bool flag_bullet2,flag_bar2,flag_ultimate,flag_ultimate2, flag_space;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;
    public HealthBar2 healthbar2;
    
    public UltimateBar2_1 ultimateBar2_1;
    public UltimateBar2_2 ultimateBar2_2;
    public UltimateBar2_3 ultimateBar2_3;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private GameObject prefab2;

    private Vector3 direction, movement = Vector3.zero, directionRight = Vector3.zero, directionForward = Vector3.zero;
    private CharacterController characterController;
    private bool forward, right,flag_healthbooster, flag_ultimatebooster, flag_speedbooster;
    public static GameObject bullet;
    public static int ultimateCounter = 0;
    private float speed = 5;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        healthbar2.SetMaxHealthh(maxHealth);

        ultimateBar2_1.SetMinAttack2_1(0);
        ultimateBar2_1.SetMaxAttack2_1(10);

        ultimateBar2_2.SetMinAttack2_2(10);
        ultimateBar2_2.SetMaxAttack2_2(20);

        ultimateBar2_3.SetMinAttack2_3(20);
        ultimateBar2_3.SetMaxAttack2_3(30);

        slider_speed.maxValue = 100;
        slider_speed.value = 0;

        bullet = prefab;
        ultimateCounter = 0;
        characterController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
       
        // Code For Movement

        if (Input.GetKeyDown(KeyCode.W))
        {
            directionForward = transform.forward;
            forward = true;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            directionForward = -transform.forward;
            forward = true;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            directionRight = transform.right;
            right = true;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            directionRight = -transform.right;
            right = true;

        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            directionForward = Vector3.zero;
            forward = false;

        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            directionRight = Vector3.zero;
            right = false;
        }

        if (flag_speedbooster)
        {
            currentVelocity_speed = -15;
            slider_speed.value = Mathf.SmoothDamp(slider_speed.value, 0, ref currentVelocity_speed, 0.3f);
            if(slider_speed.value < 0.5f)
            {
                slider_speed.value = 0;
                speed = 5;
                flag_speedbooster = false;
            }
        }

        if (flag_healthbooster)
        {
            healthBar.text.text = "" + (currentHealth);
            healthBar.slider.value = Mathf.Lerp(healthBar.slider.value,currentHealth,Time.deltaTime*10);
            healthBar.fill.color = healthBar.gradient.Evaluate(healthBar.slider.normalizedValue);
            if (Mathf.Abs(healthBar.slider.value-currentHealth) < 0.2f)
            {
                healthBar.slider.value = currentHealth;
                healthbar2.sliderr.value = currentHealth;
                flag_healthbooster = false;
            } 
        }

        if (flag_ultimate)
        {

            if (ultimateCounter == 10)
            {
                ultimateBar2_1.SetAttack2_1(ultimateCounter);
                if (ultimateBar2_1.slider2_1.value == 10)
                {
                    flag_ultimate = false;
                }
            }
            else if (ultimateCounter == 20)
            {
                ultimateBar2_2.SetAttack2_2(ultimateCounter);
                if (ultimateBar2_2.slider2_2.value == 20)
                {
                    flag_ultimate = false;
                }
            }
            else if (ultimateCounter == 30)
            {
                ultimateBar2_3.SetAttack2_3(ultimateCounter);
                if (ultimateBar2_3.slider2_3.value == 30)
                {
                    flag_ultimate = false;
                }
            }
            
            
            //if (flag_ultimate2)
            //{
            //    //ultimateBar.points[0].color = ultimateBar.points[2].color;
            //    //ultimateBar.points[1].color = ultimateBar.points[2].color;
            //    flag_ultimate = false;
            //}
            //else
            //{
            //ultimateBar.points[ultimateCounter - 1].enabled = true;
            //flag_ultimate = false;
            //}
            //ultimateBar.points[ultimateCounter - 1].enabled = true;
            //flag_ultimate = false;
        }

        if (flag_ultimatebooster)
        {
            ultimateBar2_1.SetAttack2_1(10);
            ultimateBar2_2.SetAttack2_2(20);
            ultimateBar2_3.SetAttack2_3(30);
            if (ultimateBar2_1.slider2_1.value > 9.6f && ultimateBar2_2.slider2_2.value > 19.6f &&
                ultimateBar2_3.slider2_3.value > 29.6f)
            {
                ultimateBar2_1.slider2_1.value = 10;
                ultimateBar2_2.slider2_2.value = 20;
                ultimateBar2_3.slider2_3.value = 30;
                flag_ultimate2 = true;
                flag_ultimatebooster = false;
            }
        }

        // Bullet Code
        if (Input.GetKeyDown(KeyCode.Space)){
            if (flag_ultimate2)
            {
                bullet = Instantiate(prefab2);
                flag_space = true;
                flag_ultimate2 = false;
                ultimateCounter = 0;

            } else
            {
                bullet = Instantiate(prefab);
            }
            bullet.transform.position = transform.position;
        }

        if (flag_space)
        {
            ultimateBar2_1.SetAttack2_1(0);
            ultimateBar2_2.SetAttack2_2(10);
            ultimateBar2_3.SetAttack2_3(20);
            if (ultimateBar2_1.slider2_1.value < 0.5f && ultimateBar2_2.slider2_2.value < 10.5f &&
                ultimateBar2_3.slider2_3.value < 20.5f)
            {
                ultimateBar2_1.slider2_1.value = 0;
                ultimateBar2_2.slider2_2.value = 10;
                ultimateBar2_3.slider2_3.value = 20;
                flag_space = false;
            }
            
        }
        

        if (flag_bullet2)
        {
            healthBar.SetHealth(currentHealth);
            if (currentHealth - 10 > healthBar.slider.value)
            {
                flag_bar2 = true;
            }
            if (currentHealth - 19f > healthBar.slider.value)
            {
                currentHealth = currentHealth - 20;
                healthBar.slider.value = currentHealth;
                flag_bullet2 = false;
            }

        }
        if (flag_bar2)
        {
            healthbar2.SetHealthh(currentHealth);
            if (currentHealth + 0.5f > healthbar2.sliderr.value)
            {
                healthbar2.sliderr.value = currentHealth;
                flag_bar2 = false;
            }
        }


    }

    private void FixedUpdate()
    {
        // Code For Movement And Rotation
        
        var mousePosition = Input.mousePosition;
        var capsuleWorldPosition = Camera.main.WorldToScreenPoint(transform.position);
        direction = mousePosition - capsuleWorldPosition;

        var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation,
            Quaternion.AngleAxis(-angle, Vector3.up), 10 * Time.fixedDeltaTime);

        if (forward && right)
        {
            movement = (directionRight + directionForward) * speed * Time.fixedDeltaTime;
        }
        else if (forward)
        {
            movement = directionForward * speed * Time.fixedDeltaTime;
        }
        else if (right)
        {
            movement = directionRight * speed * Time.fixedDeltaTime;
        }
        else
        {
            movement = Vector3.zero;
        }
        characterController.Move(movement);

        bullet.transform.forward = transform.forward;
        bullet.transform.position += transform.forward * 5f * Time.fixedDeltaTime;

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "HealthBooster")
        {
            if(currentHealth <= 80)     
            {
                currentHealth += 20;
            } else
            {
                currentHealth = 100;
            }
            flag_healthbooster = true;
            other.gameObject.SetActive(false);
        }

        if (other.tag == "UltimateBooster")
        {
            flag_ultimatebooster = true;
            other.gameObject.SetActive(false);
        }

        if(other.tag == "SpeedBooster")
        {
            speed = 10;
            slider_speed.value = 100;
            flag_speedbooster = true;
            other.gameObject.SetActive(false);
        }
        
    }
}
