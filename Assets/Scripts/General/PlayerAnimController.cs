using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour {

    public Animator anim;
    public static bool win;
    public float moveSpeed;
    public float jumpSpeed;
    public float gravity;
    public CharacterController playerController;

    private Vector3 moveDirection = Vector3.zero;

    public Transform pivot;
    public float rotSpeed;

    public GameObject playerModel;

    Vector3 startPosisitonPlayer;

    AudioSource audioSourcePlayer;

    public AudioClip timeOut;
    public AudioClip winner;

    public Collider metaCol;

    public GameObject deadEffect;
    bool bDeadEffect;

    // Use this for initialization
    void Start () {

        win = false;
        //anim = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();

        startPosisitonPlayer = transform.position;

        audioSourcePlayer = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update()
    {
        // Al iniciar una nueva vida (tiempo actual = a tiempo inicial) recolocamos al player a su posición inicial con PositionPlayer();
        if ( Timer.startTime - Timer.currentTime < 0.1)
        {
            Debug.Log("Restablecer posición del player");
            PosicionPlayer();
            bDeadEffect = false;
        }
        if (playerController.isGrounded)
        {
            if (Timer.tiempoAgotado == true)
            {                
                anim.SetBool("isRunning", false);
                anim.SetBool("isJumping", false);
                if (bDeadEffect == false)
                {
                    Instantiate(deadEffect, transform.position, transform.rotation);
                    bDeadEffect = true;
                }
                if (ContadorVidas.currentLife == 0)
                {
                    anim.SetBool("isDying", true);
                }
                return;
            }
            else
            {
                anim.SetBool("isDying", false);
                if (ChangeCamera.isFPS == true)
                {
                    moveDirection = Vector3.zero;
                }
                else
                {
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
                    moveDirection = transform.TransformDirection(moveDirection).normalized;
                    moveDirection *= moveSpeed;
                }


                if (moveDirection == Vector3.zero)
                {
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isJumping", false);
                }
                else
                {
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isJumping", false);
                }
                if (Input.GetButtonDown("Jump"))
                {
                    anim.SetBool("isRunning", false);
                    anim.SetBool("isJumping", true);

                    moveDirection.y = jumpSpeed;
                }
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;
        playerController.Move(moveDirection * Time.deltaTime);

        //Mover player en diferentes direcciones basadas en la dirección que apunta la cámara
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            transform.rotation = Quaternion.Euler(0f, pivot.rotation.eulerAngles.y, 0f);
            Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x, 0f, moveDirection.z));
            playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotSpeed * Time.deltaTime);
        } 
    }

    // Metodo para controlar las interacciones del player con el entorno
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Meta")
        {
            audioSourcePlayer.clip = winner;
            audioSourcePlayer.Play();
            win = true;
            Debug.Log("YOU WIN");
            metaCol.enabled = false;
            
        }
    }

    void PosicionPlayer()
    {
        transform.position = startPosisitonPlayer;
    }
}
