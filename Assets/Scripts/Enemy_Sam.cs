using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy_Sam : Enemy
{
    protected override void Start()
    {
        base.Start();
        attackDamage = 40;  // Sam i�in hasar de�eri
        moveSpeed = 3f;  // Sam i�in hareket h�z�
        playerCheckDistance = 5f;  // Sam i�in alg�lama mesafesi
    }

    protected override void Update()
    {
        base.Update();

        // Sam'e �zel ba�ka kodlar eklenebilir.
    }
}


