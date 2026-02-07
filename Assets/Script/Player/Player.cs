using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    private HashSet<Monster> detectedMonsters = new HashSet<Monster>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("run") == false && detectedMonsters.Count == 0)
        {
            Run();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Monster detectedMonster = collision.GetComponent<Monster>();
        if (detectedMonster != null)
        {
            detectedMonster.Target = this;

            detectedMonsters.Add(detectedMonster);
            Stop();
        }
    }

    private void Run()
    {
        animator.SetBool("run", true);
    }

    private void Stop()
    {
        animator.SetBool("run", false);
    }
}
