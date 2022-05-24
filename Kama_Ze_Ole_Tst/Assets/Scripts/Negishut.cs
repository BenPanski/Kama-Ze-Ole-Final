using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Negishut : MonoBehaviour
{
    [SerializeField] List<GameObject> NegishutProd;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void ToggleOpen()
    {
        animator.SetBool("Open", !animator.GetBool("Open"));

        if (NegishutProd != null)
        {
            foreach (GameObject gameObject in NegishutProd)
            {
                gameObject.SetActive(animator.GetBool("Open"));
            }
        }
    }

    public void ToggleOpenB()
    {
        animator.SetBool("OpenB", !animator.GetBool("OpenB"));

        if (NegishutProd != null)
        {
            foreach (GameObject gameObject in NegishutProd)
            {
                gameObject.SetActive(animator.GetBool("OpenB"));
            }
        }
    }

    public void ToggleEng()
    {
        animator.SetBool("Eng", !animator.GetBool("Eng"));
    }

}