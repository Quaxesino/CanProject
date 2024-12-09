using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemy_Sam : Enemy
{
    protected override void Start()
    {
        base.Start();
        attackDamage = 40;  // Sam için hasar deðeri
        moveSpeed = 3f;  // Sam için hareket hýzý
        playerCheckDistance = 5f;  // Sam için algýlama mesafesi
    }

    protected override void Update()
    {
        base.Update();

        // Sam'e özel baþka kodlar eklenebilir.
    }
}


