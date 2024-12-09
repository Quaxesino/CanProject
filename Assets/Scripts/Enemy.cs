using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{
    [SerializeField] protected float minAttackDistance = 1f;
    protected bool isAttacking;

    [Header("Move Info")]
    [SerializeField] protected float moveSpeed;

    [Header("Player Detection")]
    [SerializeField] protected float playerCheckDistance;
    [SerializeField] protected LayerMask whatIsPlayer;

    protected RaycastHit2D IsPlayerDetected;
    protected int attackDamage;

    protected virtual void Start()
    {
        base.Start();
    }

    protected virtual void Update()
    {
        base.Update();

        if (IsPlayerDetected)
        {
            if (IsPlayerDetected.distance > minAttackDistance)
            {
                rb.velocity = new Vector2(moveSpeed * 1.5f * facingDir, rb.velocity.y);
                isAttacking = false;
            }
            else
            {
                if (!isAttacking)
                {
                    Attack(IsPlayerDetected.collider.gameObject);

                }
            }
        }

        if (!isGrounded || isWallDetected)
            Flip();

        Movement();
    }

    private void Movement()
    {
        rb.velocity = new Vector2(moveSpeed * facingDir, rb.velocity.y);
    }

    protected override void CollisionChecks()
    {
        base.CollisionChecks();
        IsPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, playerCheckDistance * facingDir, whatIsPlayer);
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + playerCheckDistance * facingDir, transform.position.y));
    }

    protected void Attack(GameObject target)
    {
        isAttacking = true;
        animator.SetTrigger("Attack");

        // Oyuncuya hasar ver
        if (target.TryGetComponent<Entity>(out Entity targetEntity))
        {
            targetEntity.TakeDamage(attackDamage);
        }

        // Bir süre sonra tekrar saldýrabilir
        Invoke(nameof(ResetAttack), 3f); // 3 saniyede bir saldýrý yapabilir
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (animator != null)
        {
            animator.SetTrigger("Hurt"); // "Hurt" tetikleyicisini çalýþtýr
        }
    }

    protected override void Die()
    {
        base.Die();
    }
}


