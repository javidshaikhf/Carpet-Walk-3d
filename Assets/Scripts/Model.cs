using System;
using System.Collections;
using System.Collections.Generic;
using Lean.Transition;
using UnityEngine;
using UnityEngine.AI;


public class Model : MonoBehaviour
{
    public float turnSpeed = 1.5f;

    [SerializeField] private Animator mAnimator;

    public Transform followPosition;
    public NavMeshAgent mNavMeshAgent;

    private bool mIsFollowing, mIsDead;

    // Start is called before the first frame update
    void Start()
    {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!mIsDead)
        {
            if (!mIsFollowing)
            {
                if (Vector3.Distance(transform.position, Carpet.Instance.gameObject.transform.position) < 1.0f)
                {
                    mIsFollowing = true;
                    Carpet.Instance.AddModel(this);
                    PlayWalkAnimation();
                }
                else
                {
                    transform.LookAt(Carpet.Instance.gameObject.transform.position);
                }
            }
            else
            {
                if (GameController.Instance.GameState == GameStates.Playing)
                {
                    if (followPosition != null)
                    {
                        PlayWalkAnimation();
                        transform.rotation = Quaternion.Slerp(transform.rotation,
                            Quaternion.LookRotation(followPosition.position), turnSpeed * Time.deltaTime);
                        mNavMeshAgent.SetDestination(followPosition.position);
                    }
                }
                else
                {
                    PlayIdleAnimation();
                }
            }
        }
        else
        {
            PlayFallAnimaiton();
        }
    }

    public void PlayWalkAnimation()
    {
        mAnimator.SetTrigger("Walk");
    }

    public void PlayIdleAnimation()
    {
        mAnimator.SetTrigger("Idle");
    }

    public void StopWalking()
    {
        mIsDead = true;
    }
    
    public void PlayFallAnimaiton()
    {
        mAnimator.SetTrigger("Fall");
    }

    public void DestroyModel()
    {
        Debug.Log("Destroy Model : ****" + gameObject.name + "****");
        Destroy(gameObject);
    }
}