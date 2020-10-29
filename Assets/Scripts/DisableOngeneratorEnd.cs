using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOngeneratorEnd : MonoBehaviour
{
    [SerializeField] GeneratorAni generator;

    private void Start()
    {
        generator.OnEndAnim += DisableObject;
    }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
}
