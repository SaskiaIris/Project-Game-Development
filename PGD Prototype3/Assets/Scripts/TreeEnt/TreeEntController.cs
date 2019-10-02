using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeEntController : MonoBehaviour
{
    [SerializeField]
    private float turnSmoothTime = 0.1f, speedSmoothTime = 0.1f, walkSpeed = 2f, runSpeed = 5f;

    private float turnSmoothVelocity, speedSmoothVelocity, currentSpeed;
    private Vector2 input;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        GetInput();

        Move();
    }

    private void GetInput()
    {
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");

        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("AttackTrigger");
        }
    }

    private void Move()
    {
        Vector2 inputDir = input.normalized;

        if(input != Vector2.zero)
        {
            float targetRotation = Mathf.Atan2(inputDir.x, inputDir.y) * Mathf.Rad2Deg;
            //transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, turnSmoothTime);
        }

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = (running ? runSpeed : walkSpeed) * inputDir.magnitude;
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, speedSmoothTime);

        //transform.Translate(transform.forward * currentSpeed * Time.deltaTime, Space.World);

        float animationSpeedPercent = (running ? 1 : 0.5f) * inputDir.magnitude;
        anim.SetFloat("ForwardInput", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
    }
}
