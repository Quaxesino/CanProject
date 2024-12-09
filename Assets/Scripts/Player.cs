using UnityEngine;

public class Player : Entity
{
    [Header("Move Info")]
    public float moveSpeed;
    public float jumpForce;
    public bool healthUp = false;

    private float xInput;




    [Header("Dash Info")]
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    private float dashTime;

    [Header("Attack Info")]
    [SerializeField] private float comboTime = .3f;
    private bool isAttacking;
    private int comboCounter;
    private float ComboTimeWindow;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 40;

    [SerializeField] private float dashCooldown;
    private float dashCooldownTimer;

    public bool Key = false;


    protected override void Start()
    {
        base.Start();
        currentHealth = 100;
    }
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        Movement();
        CheckInput();
        CollisionChecks();
        FlipController();
        AnimatorController();

        if(healthUp)
        {
            currentHealth = 100;
            healthUp = false;
        }

    }

    private void CheckInput()
    {
        xInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartAttackEvent();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }


        dashTime -= Time.deltaTime;
        dashCooldownTimer -= Time.deltaTime;
        ComboTimeWindow -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            DashAbility();
        }
    }

    private void StartAttackEvent()//Yerde olduðu sürece saldýrý yapmaya yarar
    {
        if (!isGrounded)
                return;
        if (ComboTimeWindow < 0)
        {
            comboCounter = 0;
        }
        isAttacking = true;
        ComboTimeWindow = comboTime;
    }

    private void DashAbility()
    {
        if (dashCooldownTimer < 0 && !isAttacking)
        {

            dashCooldownTimer = dashCooldown;
            dashTime = dashDuration;
        }
    }

    private void Movement()
    {
        if (isAttacking)
        {
            rb.velocity = new Vector2 (0, 0);
        }

        else if (dashTime > 0)
        {
            rb.velocity = new Vector2(facingDir * dashSpeed, 0);
        }
        else
        {
            rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
        }
    }

    private void AnimatorController()//animatördeki variable'lar ile koddaki variable'lar arasýnda baðlantý.Hoþ görünsün diye yaptým.
    {
        bool isMoving = rb.velocity.x != 0;
        animator.SetBool("IsMoving?", isMoving);
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetBool("IsAttacking", isAttacking);
        animator.SetInteger("ComboCounter", comboCounter);
        animator.SetBool("IsDashing", dashTime > 0); 
    }


    private void FlipController()
    {
        if (rb.velocity.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (rb.velocity.x < 0 && facingRight)
        {
            Flip();
        }
    }

 

    public void AttackOver()
    {
        isAttacking = false;

        comboCounter++;

        if (comboCounter > 1)
        {
            comboCounter = 0;
        }

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy.TryGetComponent<Entity>(out Entity enemyEntity))
            {
                enemyEntity.TakeDamage(attackDamage);
            }
        }
    }
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);

        if (animator != null)
        {
            animator.SetTrigger("Hurt");
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
