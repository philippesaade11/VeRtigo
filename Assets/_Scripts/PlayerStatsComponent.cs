using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsComponent : MonoBehaviour
{
    private GameObject danger;
    private GameObject settings;
    private GameObject reticalpoint;
    private MovementComponent movement;
    private TraceComponent trace;

    private bool settingIsOpen = false;
    public float health = 100;
    public float score = 0;

    public float minFallDamage = 15;
    public float fallDamageImpact = 3;
    // Start is called before the first frame update
    void Start()
    {
        danger = GameObject.Find("Danger");
        settings = GameObject.Find("Settings");
        reticalpoint = GameObject.Find("GvrReticlePointer");
        movement = GetComponent<MovementComponent>();
        if (GameObject.Find("Trace") != null)
            trace = GameObject.Find("Trace").GetComponent<TraceComponent>();

        danger.SetActive(false);
        settings.SetActive(false);
    }

    void Settings()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button11) || Input.GetKeyDown(KeyCode.JoystickButton11))
        {
            if (settingIsOpen)
            {
                movement.enabled = true;
                reticalpoint.SetActive(true);
                if (trace != null)
                    trace.pinpoint = true;
                settings.SetActive(false);

            }
            else
            {
                settings.SetActive(true);
                reticalpoint.SetActive(false);
                movement.Animation(false, false);
                if (trace != null)
                    trace.pinpoint = false;
                movement.enabled = false;
            }
            settingIsOpen = !settingIsOpen;
        }
    }

    void Health()
    {
        if (health < 100)
        {
            health += 0.01f;
        }
        else if (health > 100)
        {
            health = 100;
        }

        danger.SetActive(health <= 10);
    }

    private void OnCollisionEnter(Collision other)
    {
        float force = other.relativeVelocity.x + other.relativeVelocity.y + other.relativeVelocity.z;
        if (force > minFallDamage)
        {
            health -= (force - minFallDamage) * fallDamageImpact;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Settings();
        Health();
    }
}
