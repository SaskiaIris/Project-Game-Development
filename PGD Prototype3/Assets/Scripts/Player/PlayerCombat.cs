using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    Player player;
    public Animator anim;
    public int atk = 20;
    public bool hitEnemy = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0) && !anim.GetBool("attacking"))
        {
            Attack();
        }

        HandleAttack();
    }

    void HandleAttack()
    {
        if (anim.GetBool("attacking"))
        {
            if (!hitEnemy)
            {
                foreach (GameObject enemy in player.GetEnemiesInRange())
                {
                    enemy.GetComponent<Enemy>().TakeDamage(atk);
                    hitEnemy = true;
                }
            } 
        }
        else
        {
            hitEnemy = false;
        }
    }

    void Attack()
    {
        anim.SetTrigger("slash");
    }
}
