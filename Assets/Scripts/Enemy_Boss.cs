using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : Enemy
{
    protected override void Start()
    {
        base.Start();
        attackDamage = 80;  // Boss için hasar deðeri
        moveSpeed = 1.5f;  // Boss için hareket hýzý
        playerCheckDistance = 8f;  // Boss için algýlama mesafesi
        minAttackDistance = 3.5f;
        currentHealth = 200;
    }

    protected override void Update()
    {
        base.Update();

        // Boss'a özel baþka kodlar eklenebilir.
    }
}

