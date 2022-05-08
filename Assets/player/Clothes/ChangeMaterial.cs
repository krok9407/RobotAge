using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangingMaterial : MonoBehaviour
{
    private Renderer _renderer;
    [SerializeField] private Material _material;
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    public void ChangeMaterial(){
        _renderer.material = _material;
    }
}
