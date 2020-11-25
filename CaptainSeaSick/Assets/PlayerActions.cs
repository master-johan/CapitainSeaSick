using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public enum PlayerState { free, carrying, interacting, climbing, steering };
public class PlayerActions : MonoBehaviour
{
    public float speed = 6;
    public float boostFactor = 100;
    public float stunImmunityTimer;
    Vector3 direction, movementVector, boostvector;
    PlayerInputs playerInputs;
    public Animator animator;
    public PlayerState playerState;
    public GameObject focusedObject;
    Vector2 focusedObjectOffset;
    public Rigidbody rb;
    GameObject ship;
    public GameObject rightHand;
    float movementMultiplier, boostMultiplier, stunTimer;
    public bool hasSword, isStunned, stunImmunity;
    AnimatorClipInfo[] myAnimatorClip;
    AnimatorStateInfo animationState;

    public bool isBoosting, isStill;
    // Start is called before the first frame update
    void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        playerInputs = GetComponent<PlayerInputs>();
        playerState = PlayerState.free;


    }

    // Update is called once per frame
    void Update()
    {
        switch (playerState)
        {
            case PlayerState.carrying:
                CarryFocusedObject();
                break;
            case PlayerState.free:
                break;
            case PlayerState.interacting:
                break;
            case PlayerState.steering:
                SnapToSteeringPosition();
                break;
            default:
                break;
        }

        if (GameAssets.instance.playersReady && playerState != PlayerState.steering)
        {
            PlayerMovement(playerInputs.LeftStick);
        }

        animationState = animator.GetCurrentAnimatorStateInfo(0);
        myAnimatorClip = animator.GetCurrentAnimatorClipInfo(0);

        if (myAnimatorClip[0].clip.name == "Upward Thrust")
        {
            float myTime = myAnimatorClip[0].clip.length * animationState.normalizedTime;

            if (myTime >= 1.167f)
            {
                animator.SetBool("isThrusting", false);
            }
        }

    }

    private void SnapToSteeringPosition()
    {
        transform.position = focusedObject.transform.position + new Vector3(1, 0, -1);
        transform.rotation = focusedObject.transform.rotation;
        transform.up = ship.transform.up;
        transform.Rotate(new Vector3(0, 90, 0));
    }

    void PlayerMovement(Vector2 input)
    {

        if (!isStunned)
        {
            if (playerState == PlayerState.climbing)
            {
                direction = focusedObject.transform.up * input.y * speed;

                if (Math.Abs(input.x) >= 0.125 || Math.Abs(input.y) >= 0.125)
                {
                    //direction.y = rb.velocity.y;
                    rb.velocity = direction;

                }
                else
                {
                    rb.velocity = Vector3.zero;
                }
            }
            else
            {
                if (boostMultiplier < 0.4f && boostMultiplier != 0)
                {

                }
                movementVector = new Vector3(input.x, 0, input.y) * speed;
                direction = (movementVector * movementMultiplier) + (boostvector * boostMultiplier);
                //direction = new Vector3(input.x, 0, input.y) * speed;

                MovementApplyToRigidbody(input);
            }
        }
        else
        {
            animator.SetBool("isStunned", true);
            stunTimer += Time.deltaTime;
            if (stunTimer >= 3)
            {
                isStunned = false;
                stunImmunity = true;
                stunTimer = 0;
            }
        }
        if (stunImmunity)
        {
            animator.SetBool("isStunned", false);
            stunImmunityTimer += Time.deltaTime;
            if (stunImmunityTimer >= 3)
            {
                stunImmunity = false;
                stunImmunityTimer = 0;
            }
        }
    }

    private void FixedUpdate()
    {
        if (movementMultiplier < 1)
        {
            movementMultiplier += .025f;
        }
        else
        {
            movementMultiplier = 1;
        }


        if (boostMultiplier >= .01)
        {
            boostMultiplier -= .025f;
        }
        else
        {
            boostMultiplier = 0;
        }

        if (boostMultiplier <= .5f)
        {
            animator.SetBool("isBoosting", false);
        }

        if (boostMultiplier == 0)
        {
            isBoosting = false;
        }
    }

    private void MovementApplyToRigidbody(Vector2 input)
    {
        if (direction != Vector3.zero)
        {
            transform.forward = direction.normalized;

            animator.SetBool("isRunning", true);
        }
        else
        {
            rb.velocity = Vector3.zero;
            animator.SetBool("isRunning", false);
        }

        if (Math.Abs(input.x) >= 0.125 || Math.Abs(input.y) >= 0.125)
        {
            direction.y = rb.velocity.y;
            rb.velocity = direction;
        }
    }

    public void SetFocus(GameObject target, float offsetX, float offsetY)
    {
        if (playerState == PlayerState.free)
        {
            if (target != focusedObject)
            {
                if (focusedObject != null)
                {
                    if (focusedObject.GetComponentInParent<Outline>())
                    {
                        if (focusedObject.tag == "Mast" || focusedObject.tag == "Steeringwheel" || focusedObject.tag == "Container")
                        {
                            focusedObject.GetComponentInParent<Outline>().OutlineMode = Outline.Mode.OutlineHidden;
                            focusedObject.GetComponentInParent<Outline>().OutlineColor = new Color(1, 1, 1, 0);
                        }
                        else
                        {
                            focusedObject.GetComponentInParent<Outline>().OutlineMode = Outline.Mode.SilhouetteOnly;
                        }
                    }
                }
            }
            focusedObject = target;
            focusedObjectOffset = new Vector2(offsetX, offsetY);

            Debug.Log("Got a new focus" + focusedObject.name);

            if (focusedObject != null)
            {
                if (focusedObject.GetComponentInParent<Outline>())
                {
                    if (focusedObject.tag == "Mast" || focusedObject.tag == "Steeringwheel" || focusedObject.tag == "Container")
                    {
                        focusedObject.GetComponentInParent<Outline>().OutlineMode = Outline.Mode.OutlineVisible;
                        focusedObject.GetComponentInParent<Outline>().OutlineColor = new Color(1, 1, 1, 1);
                    }
                    else
                    {
                        focusedObject.GetComponentInParent<Outline>().OutlineMode = Outline.Mode.OutlineAndSilhouette;
                    }
                }
            }
        }
        else
        {
            return;
        }
    }

    public void PickUp()
    {
        switch (playerState)
        {
            case PlayerState.carrying:
                ReleaseItem();
                break;
            case PlayerState.free:
                if (focusedObject != null)
                {
                    if (focusedObject.tag == "PickableObject")
                    {
                        PickingUpObject();
                    }
                    else if (focusedObject.tag == "Container")
                    {
                        SpawingFromContainer();
                    }
                }
                break;
            case PlayerState.interacting:
                break;
            default:
                break;
        }
    }

    private void SpawingFromContainer()
    {
        GameObject toSpawn = focusedObject.GetComponent<Barrell_Script>().CreateObject(gameObject);
        SetFocus(toSpawn, toSpawn.GetComponent<OffsetScript>().GetOffsets()[0], toSpawn.GetComponent<OffsetScript>().GetOffsets()[1]);
        PickingUpObject();
    }

    private void PickingUpObject()
    {
        playerState = PlayerState.carrying;
        focusedObject.GetComponentInChildren<PickUp_Trigger_Script>().PickedUp(gameObject);
        if (focusedObject.GetComponent<SwordTag_Script>())
        {
            focusedObject.transform.parent = rightHand.transform;
        }
    }

    private void ReleaseItem()
    {
        focusedObject.GetComponentInChildren<PickUp_Trigger_Script>().Released();
        playerState = PlayerState.free;
        hasSword = false;
        if (focusedObject.GetComponent<SwordTag_Script>())
        {
            focusedObject.transform.parent = null;
        }
    }

    private void CarryFocusedObject()
    {
        if (focusedObject != null)
        {
            if (!focusedObject.GetComponent<SwordTag_Script>())
            {

                focusedObject.transform.position = transform.position +
                                                   (transform.forward *
                                                   focusedObjectOffset.x) +
                                                   new Vector3(0, focusedObjectOffset.y,
                                                   0);
                focusedObject.transform.right = transform.forward;
            }
            else
            {
                hasSword = true;
                focusedObject.transform.position = rightHand.transform.position;
                focusedObject.transform.up = rightHand.transform.forward;
            }
        }
    }

    public void Interact()
    {
        if (focusedObject != null)
        {

            if (playerState == PlayerState.free)
            {
                if (focusedObject.GetComponent<MastBot_Trigger_Script>())
                {
                    StartClimb();
                    return;
                }

                else if (focusedObject.GetComponent<Interactable_Script>())
                {
                    playerState = focusedObject.GetComponent<Interactable_Script>().Interact();
                    return;
                }
                if (focusedObject.name == "Steer_Trigger")
                {
                    playerState = PlayerState.steering;
                    animator.SetBool("isRunning", false);
                    focusedObject.GetComponent<SteeringScript>().controllingPlayer = this.gameObject;

                    return;
                }
            }
            else if (focusedObject.GetComponent<SwordTag_Script>())
            {
                animator.SetBool("isThrusting", true);
            }


            if (playerState == PlayerState.steering)
            {
                focusedObject.GetComponent<SteeringScript>().controllingPlayer = null;
                playerState = PlayerState.free;
            }

            if (playerState == PlayerState.climbing)
            {
                StopClimb();
            }
        }

        //GameAssets.instance.windActivated ^= true;
    }

    public void StartClimb()
    {
        playerState = PlayerState.climbing;
        rb.useGravity = false;
    }

    public void StopClimb()
    {
        playerState = PlayerState.free;
        rb.useGravity = true;
    }

    public void Boost()
    {
        if (playerState != PlayerState.climbing)
        {
            int boostSpeed;

            if (GameAssets.instance.windActivated)
            {
                boostSpeed = 10;
            }
            else
            {
                boostSpeed = 15;
            }

            Vector3 direction = transform.forward;
            boostvector = direction * boostSpeed;
            //rb.AddForce(rb.velocity + direction * 500, ForceMode.Impulse);
            boostMultiplier = 1;
            movementMultiplier = 0;
            animator.SetBool("isBoosting", true);
            isBoosting = true;
            SoundManager.Instance.PlaySoundEffect(GameAssets.instance.soundEffects[1], 0.5f);
        }

        if (animationState.IsName("Idle"))
        {
            isBoosting = true;
        }
    }
    public void Clear()
    {
        if (focusedObject != null)
        {
            ReleaseItem();
        }
    }
    public Vector2 GetPlayerAxisInput()
    {
        return playerInputs.LeftStick;
    }

}


