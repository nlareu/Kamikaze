using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float debugvar = 10f;

    public AppController AppController;
    public bool AxisEnable = false;
    public float AxisSensitiveValue = 0.7f;
    public float Speed = 6.0F;
    public float Health = 500f;
    public float EnemyHitPower = 25f;

    protected PlayerStates state = PlayerStates.Normal;
    public PlayerStates State
    {
        get
        {
            return this.state;
        }
        set
        {
            if (this.state != value)
            {
                this.state = value;

                //Set variables depending new state.
                switch (this.state)
                {
                    #region Normal
                    case PlayerStates.Normal:
                        {
                            //this.spriteRendered.color = Color.white;

                            //this.rigidBody.gravityScale = 1f;

                            ////Enable again collision with other avatars, except with those that are stunned.
                            //this.AppController
                            //    .GetPlayers()
                            //    .ForEach(item =>
                            //    {
                            //        if ((item.PlayerNumber != this.PlayerNumber) && (item.State != PlayerStates.Stunned))
                            //        {
                            //            Physics2D.IgnoreCollision(this.boxCollider, item.boxCollider, false);
                            //        }
                            //    });

                            break;
                        }
                    #endregion
                    //#region Stunned
                    //case PlayerStates.Stunned:
                    //    {
                    //        this.spriteRendered.color = Color.red;

                    //        this.stunningTime = 0f;

                    //        //Ignore collision with other avatars.
                    //        this.AppController
                    //            .GetPlayers()
                    //            .ForEach(item =>
                    //            {
                    //                if (item.PlayerNumber != this.PlayerNumber)
                    //                {
                    //                    Physics2D.IgnoreCollision(this.boxCollider, item.boxCollider, true);
                    //                }
                    //            });

                    //        break;
                    //    }
                    //    #endregion
                }
            }
        }
    }

    public event EventHandler Died;
    public event EventHandler HitEnemy;

    protected Animator animator;
    internal BoxCollider2D boxCollider;
    protected internal PlayerStates previousState;
    protected SpriteRenderer spriteRendered;
    protected internal Rigidbody2D rigidBody;

    protected virtual void Awake()
    {
        this.animator = GetComponent<Animator>();
        this.boxCollider = GetComponent<BoxCollider2D>();
        this.rigidBody = GetComponent<Rigidbody2D>();
        this.spriteRendered = GetComponent<SpriteRenderer>();
        this.tag = Tags.PLAYER;
    }

    protected virtual void FixedUpdate()
    {
        switch (this.State)
        {
            #region Normal
            case PlayerStates.Normal:
                {
                    this.CheckAvatarMove();
                    break;
                }
            #endregion
            //#region Stunned
            //case PlayerStates.Stunned:
            //    {
            //        this.stunningTime += Time.deltaTime;

            //        if (this.stunningTime > this.StunnedMaxTime)
            //        {
            //            this.State = PlayerStates.Normal;
            //        }

            //        this.ejectionVelocity = this.rigidBody.velocity;

            //        break;
            //    }
            //#endregion
        }


        this.previousState = this.State;

        //Debug.Log("Velocity: " + this.rigidBody.velocity.ToString());
        //if (this.rigidBody.velocity.x != 0) 
        //    Debug.Log("Velocity: " + this.rigidBody.velocity.ToString());
        //Debug.Log(string.Format("Axis H: {0}, V: {1}.", (float)Input.GetAxis("Horizontal"), (float)Input.GetAxis("Vertical")));
    }

    private void CheckAvatarMove()
    {
        Vector2 moveVector = new Vector2();
        float axisHor = Input.GetAxis("Horizontal");
        float axisVer = Input.GetAxis("Vertical");

        if (Input.GetButton("Left"))// || (this.AxisEnable == true && axisHor <= -this.AxisSensitiveValue))
        {
            moveVector += Vector2.left * this.Speed * Time.deltaTime;

            this.animator.SetBool("Moving", true);
            this.animator.SetFloat("MoveX", -1.5f);
        }
        else if (Input.GetButton("Right"))// || (this.AxisEnable == true && axisHor >= this.AxisSensitiveValue))
        {
            moveVector += Vector2.right * this.Speed * Time.deltaTime;

            this.animator.SetBool("Moving", true);
            this.animator.SetFloat("MoveX", 1.5f);
        }

        if (Input.GetButton("Up"))// || (this.AxisEnable == true && axisVer <= -this.AxisSensitiveValue))
        {
            moveVector += Vector2.up * this.Speed * Time.deltaTime;

            this.animator.SetBool("Moving", true);
            this.animator.SetFloat("MoveY", -1.5f);
        }
        else if (Input.GetButton("Down"))// || (this.AxisEnable == true && axisVer >= this.AxisSensitiveValue))
        {
            moveVector += Vector2.down * this.Speed * Time.deltaTime;

            this.animator.SetBool("Moving", true);
            this.animator.SetFloat("MoveY", 1.5f);
        }

        //else
        //{
        //    this.animator.SetBool("Moving", false);
        //    //this.animator.SetFloat("MoveX", 0.5f);
        //}

        this.transform.Translate(moveVector);
    }
    public void EnemyHit()
    {
        this.Health -= this.EnemyHitPower;

        this.OnHitEnemy();

        if (this.Health <= 0)
            this.Kill();

    }
    public void Kill()
    {
        this.gameObject.SetActive(false);

        this.OnDied();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        CollisionsManager.ResolveCollision(this.gameObject, col.gameObject, col);
    }
    private void OnDied()
    {
        if (this.Died != null)
            this.Died(this, new EventArgs());
    }
    private void OnHitEnemy()
    {
        if (this.HitEnemy != null)
            this.HitEnemy(this, new EventArgs());
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        CollisionsManager.ResolveCollision(this.gameObject, col.gameObject, col);
    }
}
