using System.Collections;
using System.Collections.Generic;
using HutongGames.PlayMaker.Actions;
using UnityEngine;
using System.Linq;

public class PlayerMovement : MonoBehaviour
{

    private float jumpForce = 15f;
    private bool isGrounded = false;
    public Rigidbody rb;
    private string previousLayerName;


    public float laneDistance = 4; // Distance between lanes
    private int desiredLane = 1; // 0 = Left, 1 = Middle, 2 = Right
    private float switchlaneCd = 0.15f;
    private float cdTimer = 0f;

    private Animator animator;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        cdTimer -= Time.deltaTime;

        // rb = GetComponent<Rigidbody>();

        if (cdTimer <= 0f)
        {
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                desiredLane--;
                cdTimer = switchlaneCd;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                desiredLane++;
                cdTimer = switchlaneCd;
            }
        }

        // Clamp the desiredLane value to prevent going out of bounds
        desiredLane = Mathf.Clamp(desiredLane, 0, 2);

        // Mekanik Lompat
        Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);
        // Debug.Log("isGrounded = " + isGrounded);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // GetComponent<Rigidbody>().velocity = new Vector3(0, jumpForce, 0);
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            Debug.Log("Lompat!");
            animator.SetTrigger("Jump");

            // Simpan layer sebelumnya (misal Default)
            // previousLayerName = LayerMask.LayerToName(gameObject.layer);

            // // Ganti sementara ke PlayerJump
            // SetLayerRecursively(gameObject, LayerMask.NameToLayer("PlayerJump"));
            // // gameObject.layer = LayerMask.NameToLayer("PlayerJump");

            // Invoke("ResetLayer", 0.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayMakerFSM obstacleHit = GameObject.Find("Player").GetComponents<PlayMakerFSM>()
            .FirstOrDefault(fsm => fsm.FsmName == "LifeDecrement");

        PlayMakerFSM obstacleSpawnQuiz = GameObject.Find("Player").GetComponents<PlayMakerFSM>()
            .FirstOrDefault(fsm => fsm.FsmName == "QuizSettingsNew");

        PlayMakerFSM obsAudio = GameObject.Find("Player").GetComponents<PlayMakerFSM>()
            .FirstOrDefault(fsm => fsm.FsmName == "HitDetect");

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Tabrakan terdeteksi (trigger)!");
            // Kirim event ke FSM
            obstacleHit.SendEvent("Hit");
            obsAudio.SendEvent("Hit_Audio");

            obstacleSpawnQuiz.SendEvent("Hit");
            var seq = FindObjectOfType<LearningSequence>();
            if (seq != null) seq.paused = true;

            // animator.SetTrigger("Hit"); // Jika punya animasi hit
            // Tambahkan penurunan nyawa di FSM atau script

            // Memberikan reaksi terpental pada object
            Rigidbody obstacleRb = other.GetComponent<Rigidbody>();
            if (obstacleRb != null)
            {
                obstacleRb.isKinematic = false; // pastikan tidak kinematic
                Vector3 ragdollDirection = (other.transform.position - transform.position).normalized + Vector3.up;
                obstacleRb.AddForce(ragdollDirection * 10f, ForceMode.Impulse); // arah + kekuatan
            }
        }
    }

    private void FixedUpdate()
    {

        // Gabungan Control Kanan-Kiri
        Vector3 targetPosition = transform.position;
        targetPosition.x = (desiredLane - 1) * laneDistance;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);

    }

    // void ResetLayer()
    // {
    //     SetLayerRecursively(gameObject, LayerMask.NameToLayer(previousLayerName));
    //     // gameObject.layer = LayerMask.NameToLayer("Default"); // Atau layer sebelumnya
    // }

    // void SetLayerRecursively(GameObject obj, int newLayer)
    // {
    //     obj.layer = newLayer;
    //     foreach (Transform child in obj.transform)
    //     {
    //         SetLayerRecursively(child.gameObject, newLayer);
    //     }
    // }

    // private void OnCollisionEnter(Collision collision)
    // {
    //     if (collision.gameObject.tag == "Ground")
    //     isGrounded = true;
    // }
}
