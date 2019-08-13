using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public GameObject Hand;
    public Weapon myWeapon;
    Animator handAnim;

    private float attackTimer;
    
    void Start()
    {
        handAnim = Hand.GetComponent<Animator>();
        myWeapon = Hand.GetComponentInChildren<Weapon>();
    }

    void Update()
    {
        attackTimer += Time.deltaTime;
        if (Input.GetMouseButton(0) && attackTimer >= myWeapon.attackCoolDown)
        {
            DoAttack();
        }

        //Attack Animation
        if (Input.GetMouseButton(0))
        {
            handAnim.SetTrigger("attack");
        }
    }

    private void DoAttack()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, myWeapon.attackRange))
        {
            if(hit.collider.tag == "Enemy")
            {
                EnemyHealth ehealth = hit.collider.GetComponent<EnemyHealth>();
                ehealth.TakeDamage(myWeapon.attackDamage);
            }
        }
    }
}
