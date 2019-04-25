using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MovementComponent : MonoBehaviour
{
    private Transform cam_Trans;
    private Animator Head_Anim;
    private Animator Sword_Anim;
    private Rigidbody rigidbody;
    private AudioSource walkAudio;
    private AudioSource runAudio;
    private LayerMask terrainLayers;

    public bool isWalking = false;
    public bool isRunning = false;
    public bool isNotJumping = true;
    public bool isHitting = true;
    public int HitTime = 25;

    public float jumpF = 1f;
    public float walkspeed = 0.075f;
    public float runspeed = 0.15f;
    public bool allowMovement = true;

    // Start is called before the first frame update
    void Start()
    {
        cam_Trans = transform.Find("Head").Find("Main Camera");
        Head_Anim = transform.Find("Head").GetComponent<Animator>();
        Sword_Anim = transform.Find("Body").Find("Sword").GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        terrainLayers = LayerMask.GetMask("Terrain");
        walkAudio = transform.Find("Walk Audio").GetComponent<AudioSource>();
        runAudio = transform.Find("Run Audio").GetComponent<AudioSource>();
    }

    void Walk()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        isRunning = (h != 0 || v != 0) && (Input.GetKey(KeyCode.Joystick1Button13) || Input.GetKey(KeyCode.JoystickButton13) || Input.GetKey(KeyCode.JoystickButton8) || Input.GetKey(KeyCode.Joystick1Button8));
        isWalking = (h != 0 || v != 0);

        if (isRunning)
        {
            transform.Translate(Vector3.forward * v * runspeed);
            transform.Translate(Vector3.right * h * runspeed);
        }
        else if (isWalking)
        {
            transform.Translate(Vector3.forward * v * walkspeed);
            transform.Translate(Vector3.right * h * walkspeed);
        }

        if (!isNotJumping)
        {
            Animation(false, false);
        }
        else
        {
            Animation(isWalking, isRunning);
        }
    }

    void Jump()
    {
        isNotJumping = Physics.Raycast(transform.position, Vector3.down, 2f, terrainLayers);
        if (isNotJumping && (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            Animation(false, false);
            rigidbody.AddForce(new Vector3(0, jumpF, 0), ForceMode.VelocityChange);
        }
    }

    public void Animation(bool isWalking, bool isRunning)
    {
        Head_Anim.SetBool("isWalking", isWalking);
        Head_Anim.SetBool("isRunning", isRunning);
        Sword_Anim.SetBool("isWalking", isWalking);
        Sword_Anim.SetBool("isRunning", isRunning);

        if (!isWalking)
        {
            walkAudio.Stop();
        }
        else if (!walkAudio.isPlaying)
        {
            walkAudio.Play();
        }

        if (!isRunning)
        {
            runAudio.Stop();
        }
        else if (!runAudio.isPlaying)
        {
            runAudio.Play();
        }
    }

    void Attack()
    {
        if ((Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.JoystickButton1)))
        {
            HitTime = 0;
        }
        HitTime += 1;
        if (!isHitting && HitTime < 25)
        {
            isHitting = true;
            Sword_Anim.SetBool("isHitting", true);
        }
        else if (isHitting && HitTime >= 25)
        {
            isHitting = false;
            Sword_Anim.SetBool("isHitting", false);
        }
    }

    void Turn()
    {
        float h = Input.GetAxis("Horizontal2");
        float v = Input.GetAxis("Vertical2");
        transform.Rotate(new Vector3(-v, h, 0));
    }

    IEnumerator GrabSword()
    {
        Transform target = transform.Find("Body").Find("Sword");
        float positionStep = 0.1f;
        float rotationStep = 5f;

        GameObject sword = GameObject.Find("Sword Object");
        while (Quaternion.Angle(sword.transform.rotation, target.rotation) > rotationStep || Vector3.Distance(sword.transform.position, target.position) > positionStep)
        {
            sword.transform.rotation = Quaternion.RotateTowards(sword.transform.rotation, target.rotation, rotationStep);
            sword.transform.position = Vector3.MoveTowards(sword.transform.position, target.position, positionStep);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(sword);
        target.gameObject.SetActive(true);
        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        if (allowMovement)
        {
            Walk();
            Jump();
        }
        Attack();
        Turn();
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine("GrabSword");
        }

        //foreach (KeyCode kcode in Enum.GetValues(typeof(KeyCode)))
        //{
        //    if (Input.GetKey(kcode))
        //        Debug.Log("KeyCode down: " + kcode);
        //}
    }
}
