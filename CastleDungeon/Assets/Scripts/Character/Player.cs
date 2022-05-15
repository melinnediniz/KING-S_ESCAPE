using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;  //velocidade
    public float JumpForce;  //força do pulo
    public bool OnGround;  //player encostando no chão
    private bool isAlive = true;
    public int currentHealth;
    public Transform GroundDetect;  //verifica o chão
    public LayerMask IsGround;  //verifica o que é chão
    public static Player instance;

    private Rigidbody2D Rig;  //colisor
    private BoxCollider2D BoxCol;
    private Animator Anim;  //relações de animação

    // Start is called before the first frame update
    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();  //pega o rigid body
        Anim = GetComponent<Animator>();  //pega as relações de animação
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        CheckLife();

        if (isAlive)
        {
            Move();
            Jump();
        }
    }

    void Move()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);  //pega o Input atual
        transform.position += movement * (Time.deltaTime * Speed);  //transforma(move) o objeto

        if(Input.GetAxis("Horizontal") > 0f){  //se Input horizontal for 1 (direita)
            transform.eulerAngles = new Vector3(0f,0f,0f);  //transforma a direção
            Anim.SetBool("walk", true);  //seta a animação "andando"
        }
        if(Input.GetAxis("Horizontal") < 0f){  //se Input horizontal for -1 (esquerda)
            transform.eulerAngles = new Vector3(0f,180f,0f);
            Anim.SetBool("walk", true);  //seta a animação "andando"
        }
        if(Input.GetAxis("Horizontal") == 0){  //se Input horizontal for 0 (parado)
            Anim.SetBool("walk", false);
        }
    }//end

    void Jump(){  //método Pular
        OnGround = Physics2D.OverlapCircle(GroundDetect.position, 0.1f, IsGround);  //variável recebe true/falso para detectar chão
        if(Input.GetButtonDown("Jump") && OnGround == true){  //se botão de pulo acionado e player não pulando
            Rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);  //adiciona força/impulso na direção Cima
            Anim.SetBool("jump", true);
        }
    }//end

    void CheckLife()
    {
        if (currentHealth <= 0)
        {
            isAlive = false;
            Debug.Log("Player is dead!"); // death test
            // die function
        }
    }

    public void TakeDamage(int damage)
    {
        Anim.SetTrigger("hit");
        currentHealth -= damage;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Anim.SetBool("jump", false);

        if (col.gameObject.CompareTag("Spike"))
        {
            GameController.Instance.ShowGameOver();
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Trap"))
        {
            GameController.Instance.ShowGameOver();
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Saw"))
        {
            GameController.Instance.ShowGameOver();
            Destroy(gameObject);
        }

        if (col.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(1);
        }
    }

    public void DoorIn(){
        Anim.SetTrigger("door_in");
        Destroy(gameObject, 1f);
    }
}