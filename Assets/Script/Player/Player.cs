using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (animator.GetBool("run") == false)
        {
            Run();
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
