using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
  Animator animator;

  void Start()
  {
    animator = GetComponent<Animator>();
  }

  void Update()
  {

    //Attack Animation
    if (Input.GetMouseButtonDown(0))
    {
      animator.SetTrigger("attack");
    }
  }

  private bool isAttacking()
  {
    return animator.GetCurrentAnimatorStateInfo(0).IsName("Attack");
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Enemy") && isAttacking())
    {
      Destroy(other.gameObject);
    }
  }

  private void OnTriggerStay(Collider other)
  {
    if (other.CompareTag("Enemy") && isAttacking())
    {
      other.gameObject.transform.position = new Vector3(
        Random.Range(5, 450),
        0.84f,
        Random.Range(5, 450)
      );
    }
  }
}
