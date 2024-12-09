using System.Collections;
using UnityEngine;

public class Trap : MonoBehaviour
{
    private Player player;
    public GameObject Slowness;


    private void Start()
    {
        // Player referansýný alýyoruz (bu satýr player'ý doðru þekilde bulmalýsýnýz)
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
