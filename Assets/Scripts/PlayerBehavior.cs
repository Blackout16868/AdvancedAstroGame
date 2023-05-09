using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode sprintKey = KeyCode.LeftShift;
    public KeyCode poundKey = KeyCode.LeftControl;

    [Header("Movement")]
    private float moveSpeed;
    public float walkSpeed;
    public float sprintSpeed;

    public float groundDrag;
    public float airDrag;

    [Header("Jumping")]
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplier;
    bool readyToJump;

    [Header("Ground Pound")]
    public float poundSpeed;
    bool readyToPound;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    public LayerMask ice;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    public MovementState state;

    public float maxAirTimeInFrames = 450f;
    private float curTimeInair = 0f;
    private float maxAirVelocity;
    private float jetPackStartup = 10f;
    private float currentStartup = 0f;
    public float jetpackAcceleration = 0.5f;

    private Vector3 prevVelocity;


    public enum MovementState
    {
        walking,
        sprinting,
        air
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
        maxAirVelocity = jumpForce;
    }

    void Update()
    {
        MyInput();
        SpeedControl();
        StateHandler();

        grounded = isGrounded();
        
        if (grounded){
            readyToPound = true;
        }
        else
            rb.drag = airDrag;

        prevVelocity = rb.velocity;
    }

    bool isGrounded(){


        if (Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ice)){
            rb.drag = -groundDrag;
            return true;
        }

        if (Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ground)){
            rb.drag = groundDrag;
            return true;
        }


        return false;
    }
    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        if(Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump();
            Invoke(nameof(ResetJump), jumpCooldown);
        }

         jetpack();

        
        if(Input.GetKey(poundKey) && readyToPound && !grounded)
        {
            readyToPound = false;
            Pound();
            
        }
        
    }

    void StateHandler()
    {
        if(grounded && Input.GetKey(sprintKey))
        {
            state = MovementState.sprinting;
            moveSpeed = sprintSpeed;
        }
        else if (grounded)
        {
            state = MovementState.walking;
            moveSpeed = walkSpeed;
        }
        else{
            state = MovementState.air;
        }
    }

    void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        Debug.Log("Direction:"+rb.velocity);
        if(grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else if(!grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    void Pound()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        rb.AddForce(-transform.up * poundSpeed, ForceMode.Impulse);
    }

    void ResetJump()
    {
        readyToJump = true;
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    public Vector3 getMoveDiection()
    {
        return moveDirection;
    }

    void jetpack(){

        if (curTimeInair<maxAirTimeInFrames&&!grounded&&Input.GetKey(jumpKey)&&currentStartup>=jetPackStartup&&ItemCollector.hasJetpack==true){

            float upVelocity = rb.velocity.y+jetpackAcceleration;

            if (upVelocity > maxAirVelocity){
                upVelocity = maxAirVelocity;
            }

            rb.velocity = new Vector3(rb.velocity.x,upVelocity, rb.velocity.z);
            curTimeInair++;
            return;
        }
        if (grounded&curTimeInair>0f)
        {
            curTimeInair --;
            
        }

        if (grounded&&currentStartup!=0f)
        {
            currentStartup = 0f;
        }

        if (!grounded){
            currentStartup ++;
        }
    }

    public float getMaxAirtime(){
        return maxAirTimeInFrames;
    }

    public float getCurAirtime(){
        return curTimeInair;
    }

    public float getPlayerHeight(){
        return playerHeight;
    }
}

