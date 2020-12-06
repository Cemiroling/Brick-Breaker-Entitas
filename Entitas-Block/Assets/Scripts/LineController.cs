using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Texture[] textures;

    private int _animationStep;
    private float _fpsCounter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _fpsCounter += Time.deltaTime;
        if(_fpsCounter >= 1f / 30)
        {
            _animationStep++;
            line.material.SetTexture("_MainTex", textures[_animationStep % 4]);

            _fpsCounter = 0;
        }
    }
}
