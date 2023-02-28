using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public GameManager gameManager;
    public int myBuilder;
    public WorldScore worldScore;

    public float speed;
    public Animator animator;

    public void Drift()
    {
        worldScore = gameManager.worldScore;
        speed = gameManager.ThisGameSet.Speed;
        animator = transform.GetComponent<Animator>();
        animator.speed = animator.speed * speed;
    }
}
