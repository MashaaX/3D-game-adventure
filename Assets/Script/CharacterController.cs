using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
  public class MoveSettings
  {
    public static float fowardVel = 12;
    public static float rotateVel = 100;
    public static float jumpVel = 5;
  }

  public class InputSettings
  {
    public static float inputDelay = 0.1f;
    public static string FOWARD_AXIS = "Vertical";
    public static string TURN_AXIS = "Horizontal";
    public static string JUMP_AXIS = "Jump";
  }
  Quaternion targetRotation;
  Rigidbody rBody;

  Vector3 velocity = Vector3.zero;

  float fowardInput, turnInput, jumpInput;

  public bool isOnGround = true;

  public Quaternion TargetRotation
  {
    get { return targetRotation; }
  }

  private void Start()
  {
    targetRotation = transform.rotation;
    rBody = GetComponent<Rigidbody>();
  }

  void Update()
  {
    GetInput();
  }

  void FixedUpdate()
  {
    Run();
    Jump();
    Turn();
  }

  void GetInput()
  {
    fowardInput = Input.GetAxis(InputSettings.FOWARD_AXIS);
    turnInput = Input.GetAxis(InputSettings.TURN_AXIS);
    jumpInput = Input.GetAxisRaw(InputSettings.JUMP_AXIS);
  }

  void Run()
  {
    velocity.y = rBody.velocity.y;
    velocity.z = MoveSettings.fowardVel * fowardInput;
    rBody.velocity = transform.TransformDirection(velocity);
  }

  void Jump()
  {
    if (jumpInput > 0 && isOnGround)
    {
      rBody.AddForce(new Vector3(0, MoveSettings.jumpVel, 0), ForceMode.Impulse);
    }
  }

  void Turn()
  {
    if (Mathf.Abs(turnInput) > InputSettings.inputDelay)
    {
      targetRotation *= Quaternion.AngleAxis(MoveSettings.rotateVel * turnInput * Time.deltaTime, Vector3.up);
    }
    transform.rotation = targetRotation;
  }

  void OnTriggerEnter(Collider other)
  {
    isOnGround = true;
  }

  void OnTriggerExit(Collider other)
  {
    isOnGround = false;
  }
}