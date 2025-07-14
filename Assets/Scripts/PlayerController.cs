using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    float currentSpeed; 
    Rigidbody rb;
    Vector3 direction; 
    [SerializeField] float shiftSpeed = 10f;
    [SerializeField] float jumpForce = 7f;
    bool isGrounded = true;
    float stamina = 5f;
    [SerializeField] GameObject pistol, rifle;
    [SerializeField] Animator anim;
    bool isPistol, isRifle;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
              if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= Time.deltaTime;
                currentSpeed = shiftSpeed;

            }

            else
            {
                currentSpeed = movementSpeed;
            }

        }

        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
            currentSpeed = movementSpeed;
        }


    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }

    public void ChooseWeapon(string weapons)
    {
        switch (weapons)
        {
            case "Pistol":
            anim.SetBool("Pistol", true);
            anim.SetBool("Assault", false);
            anim.SetBool("NoWeapon", false);
            pistol.SetActive(true);
            rifle.SetActive(false);
            break;
            case "Rifle":
            anim.SetBool("Pistol", false);
            anim.SetBool("Assault", true);
            anim.SetBool("NoWeapon", false);
            pistol.SetActive(false);
            rifle.SetActive(true);
            break;
            case "NoWeapon":
            anim.SetBool("Pistol", false);
            anim.SetBool("Assault", false);
            anim.SetBool("NoWeapon", true);
            pistol.SetActive(false);
            rifle.SetActive(false);
            break;
        }
    }
}
