using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Player player;
    public GameObject Slowness;


    private void Start()
    {
        // Player referans�n� al�yoruz (bu sat�r player'� do�ru �ekilde bulmal�s�n�z)
        player = FindObjectOfType<Player>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.moveSpeed = 1;
            player.jumpForce = 1;
            Slowness.SetActive(true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        player.moveSpeed = 10;
        player.jumpForce = 5;
        Slowness.SetActive(false);
    }
}
