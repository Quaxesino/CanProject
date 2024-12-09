using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Boss : Enemy
{
    protected override void Start()
    {
        base.Start();
        attackDamage = 80;  // Boss i�in hasar de�eri
        moveSpeed = 1.5f;  // Boss i�in hareket h�z�
        playerCheckDistance = 8f;  // Boss i�in alg�lama mesafesi
        minAttackDistance = 3.5f;
        currentHealth = 200;
    }

    protected override void Update()
    {
        base.Update();

        // Boss'a �zel ba�ka kodlar eklenebilir.
    }
}

