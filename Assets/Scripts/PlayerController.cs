using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    //Movimento
    [Header("Config Player")]
    public float moveSpeed = 3f;
    private Vector3 direction;
    private bool isWalk;

    //Input
    private float horizontal;
    private float vertical;

    [Header("Attack Config")]
    public ParticleSystem fxAttack;
    private bool isAttack;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        Inputs();
        MoveCharacter();
        UpdateAnimator();
        AttackIsDone();
    }

    #region Meus metodos

    // metodo responsavel pelas entradas de comando do usuario
    void Inputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Fire1") && isAttack == false)
        {
            Attack();
        }
    }


    void Attack()
    {

        isAttack = true;
        anim.SetTrigger("Attack");
        fxAttack.Emit(1);

    }

    // metodo responsavel por mover o personagem
    void MoveCharacter()
    {
        direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude > 0.1f)
        {
            float angulo = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angulo, 0);
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }

        controller.Move(direction * moveSpeed * Time.deltaTime);
    }

    // metodo responsavel em atualizar os animator
    void UpdateAnimator()
    {
        anim.SetBool("isWalk", isWalk);
    }

    void AttackIsDone()
    {
        isAttack = false;
    }

    #endregion
}
