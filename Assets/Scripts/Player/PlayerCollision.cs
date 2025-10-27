using UnityEngine;
using System.Linq;
using HutongGames.PlayMaker.Actions;

public class PlayerCollision : MonoBehaviour
{
    // public PlayerMovement movement;
    // // public GameManager manage; ini komen
    
    /*public AudioSource audioSource;      // Drag AudioSource via Inspector
    public AudioClip hitClip;

    void OnCollisionEnter (Collision collisionInfo) 
    {

        // if (collisionInfo.collider.tag == "Obstacle")
        if (collisionInfo.collider.CompareTag("Obstacle"))
        {
            // Debug.Log("YOU HIT A WALL"); ini komen
            // movement.enabled = false;
            // FindObjectOfType<GameManager>().EndGame();

            if (audioSource != null && hitClip != null)
            {
                audioSource.PlayOneShot(hitClip);
            }

            PlayMakerFSM obsHit = GameObject.Find("Player").GetComponents<PlayMakerFSM>()
                .FirstOrDefault(fsm => fsm.FsmName == "LifeDecrement");

            if (obsHit != null)
            {
                obsHit.SendEvent("Hit");
            }

        }
    }*/

}
