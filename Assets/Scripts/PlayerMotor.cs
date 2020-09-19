using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// for controlling player movement sliding, running, jumping
/// </summary>
public class PlayerMotor : MonoBehaviour {

    [SerializeField] FloatVariable speed;
    [SerializeField] BoolValue gameRunning;
    [SerializeField] Vector3Variable playerPos;
    float laneDistance = 2f;
    //animation 
    Animator anim;
    //Movement 
    CharacterController controller;
    float jumpForce = 2.0f;
    float gravity = 7f;
    float verticalVelocity;
    int desiredLane=1;

	void Start () {
        controller = transform.GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        gameRunning.Value = false;
        playerPos.Value = Vector3.zero;
    }
	
	void Update ()
    {
        //Running
        if (MultiInput.Instance.Tap && !gameRunning.Value)
        {
            gameRunning.Value = true;
            anim.SetTrigger("Running");
        }

        if (!gameRunning.Value)
            return;
        //which lane we should be 
        if (MultiInput.Instance.SwipeLeft)
            MoveLane(false);
        if (MultiInput.Instance.SwipeRight )
            MoveLane(true );
        
        //where we should be 
        Vector3 targetPosition = transform.position.z * Vector3.forward;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else  if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;
        //calculate our move delta 
        Vector3 moveVector = Vector3.zero;
        moveVector.x = (targetPosition - transform.position).x;

        bool isGrounded = IsGrounded();
        anim.SetBool("Grounded",isGrounded);
        //calculate y
        if (IsGrounded())
        {
            verticalVelocity = -.1f;
            if (MultiInput.Instance.SwipeUp )
            {
                //jump 
                anim.SetTrigger("Jump");
                verticalVelocity = jumpForce;
            }
            else if (MultiInput.Instance.SwipeDown )
            {
                //slide
                StartSliding();
            }

        }
        else
        {
            verticalVelocity -= (gravity * Time.deltaTime);
            //fast falling mechanic 
            if (MultiInput.Instance.SwipeDown )
            {
                verticalVelocity = -jumpForce;
            }
        }
        moveVector.y = verticalVelocity;
        moveVector.z = 1f;
        controller.Move(moveVector * speed.Value * Time.deltaTime);

        //Rotate the player to where is going
        Vector3 dir = controller.velocity;
        if (dir != Vector3.zero)
        {
            dir.y = 0;
            transform.forward = Vector3.Lerp(transform.forward, dir, .05f);
        }
        playerPos.Value = transform.position;
    }

    private void MoveLane(bool goingRight)
    {
        desiredLane += (goingRight) ? 1 : -1;
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);
    }

    bool IsGrounded()
    {
        Ray groundRay = new Ray(new Vector3 (controller.bounds.center.x ,
            (controller.bounds.center.y-controller.bounds.extents.y)+.2f,
            controller.bounds.center.z ),Vector3.down );
        Debug.DrawRay(groundRay.origin,groundRay.direction , Color.cyan,1.0f);
        return Physics.Raycast(groundRay, .3f);
    }
  
    #region sliding function
    void StartSliding()
    {
        anim.SetBool("Sliding", true);
        controller.height /= 4;
        controller.center = new Vector3(controller.center.x ,controller.center.y /4,controller.center.z);
        StartCoroutine(StopSliding());
    }

    IEnumerator StopSliding()
    {
        yield return new WaitForSeconds(1);
        anim.SetBool("Sliding", false);
        controller.height *= 4;
        controller.center = new Vector3(controller.center.x, controller.center.y * 4, controller.center.z);
    }
    #endregion
}
