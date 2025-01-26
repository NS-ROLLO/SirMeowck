using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatAnimator : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Animator _anim;

    [SerializeField] private SpriteRenderer _sprite;

    [Header("Settings")]
    [SerializeField, Range(1f, 3f)]
    private float _maxIdleSpeed = 2;

    private IPlayerController _player;
    private bool _grounded;

    private void Awake()
    {
        _player = GetComponentInParent<IPlayerController>();
    }

    private void OnEnable()
    {
        _player.GroundedChanged += OnGroundedChanged;
    }

    private void OnDisable()
    {
        _player.GroundedChanged -= OnGroundedChanged;
    }

    private void Update()
    {
        if (_player == null) return;


        HandleSpriteFlip();

        HandleIdleSpeed();

    }

    private void HandleSpriteFlip()
    {
        if (_player.FrameInput.x != 0) _sprite.flipX = _player.FrameInput.x < 0;
    }

    private void HandleIdleSpeed()
    {
        var inputStrength = Mathf.Abs(_player.FrameInput.x);
        float speed = Mathf.Lerp(1, _maxIdleSpeed, inputStrength);
        _anim.SetFloat(SpeedKey, speed);
    }

    private void OnGroundedChanged(bool grounded, float impact)
    {
        _grounded = grounded;

        _anim.SetBool(InAirKey, !grounded);
    }
   
    private static readonly int SpeedKey = Animator.StringToHash("speed");
    private static readonly int InAirKey = Animator.StringToHash("inAir");
}
