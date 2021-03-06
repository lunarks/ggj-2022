using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

/**=====================================
Class DeathLogic
-------------------------
Description:

Death logic. Display the victory menu and disable the player's character
--------------------------
Author(s):
Bryan Curchod
Selin Kaya
=====================================*/
public class DeathLogic : MonoBehaviour
{
    private Rigidbody2D rb;

    public StudioEventEmitter deathSound;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("DoNotTouch")){
            deathSound.Play();
            Die();
        }
    }

    private void Die(){
        // Debug.Log("haha ya dead lul");

        // TODO  trigger death animation
        LevelManager.instance.GameOver();
        GetComponent<PlayerControls>().detachCamera();
        PlayerControls.isAlive = false;
        
        CapsuleCollider2D collider = GetComponent<CapsuleCollider2D>();
        collider.enabled = false;
        // rb.bodyType = RigidbodyType2D.Static;
        // gameObject.SetActive(false);
    }
}
