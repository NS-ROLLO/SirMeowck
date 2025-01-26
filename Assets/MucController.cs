using Controller;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MucController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _sprite;

    private bool _isCharging = false;
    private float _chargeTime = 0f;
    public float _maxChargeTime = 2f;
    public float projectileSpeed = 10f;

    public Sprite[] spritesMuc;

    public AudioSource _source;
    public AudioClip _clipCharge;
    public AudioClip _clipShoot;

    public GameObject[] projectilePrefabs; 


    private IPlayerController _player;
    private PlayerController PlayerController;

    private void Awake()
    {
        _player = GetComponentInParent<IPlayerController>();
        PlayerController = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        if (_player == null) return;

        HandleSpriteFlip();
        if (PlayerController.Grounded())
        {
            HandleInput();
        }
    }

    private void HandleInput()
    {
        float chargeRatio = Mathf.Clamp01(_chargeTime / _maxChargeTime);

        if (chargeRatio == 0f)
        {
            _sprite.sprite = spritesMuc[0];
        }
        else if (chargeRatio < 0.33f)
        {
            _sprite.sprite = spritesMuc[1];
        }
        else if (chargeRatio < 0.66f)
        {
            _sprite.sprite = spritesMuc[2];
        }
        else if(_chargeTime < _maxChargeTime)
        {
            _sprite.sprite = spritesMuc[3];
        }
        else
        {
            _sprite.sprite = spritesMuc[4];
        }

        if (Input.GetMouseButtonDown(0))
        {
            _isCharging = true;
            _chargeTime = 0f;
            _source.PlayOneShot(_clipCharge);
        }

        if (Input.GetMouseButton(0) && _isCharging)
        {
            _chargeTime += Time.deltaTime;

            if (_chargeTime >= _maxChargeTime)
            {
                ShootProjectile();
            }
        }

        if (Input.GetMouseButtonUp(0) && _isCharging)
        {
            ShootProjectile();
        }
    }

    private void HandleSpriteFlip()
    {
        if (_player.FrameInput.x != 0)
        {
            if (_sprite.flipX != _player.FrameInput.x < 0)
            {
                Vector3 position = transform.localPosition;
                position.x *= -1;
                transform.localPosition = position;
                _sprite.flipX = _player.FrameInput.x < 0;
            }
        }
    }

    private void ShootProjectile()
    {
        _source.Stop();
        _isCharging = false;

        _source.PlayOneShot(_clipShoot);

        float chargeRatio = Mathf.Clamp01(_chargeTime / _maxChargeTime);

        Debug.Log(chargeRatio);

        if (chargeRatio < 0.33f)
        {
            GameObject projectile = Instantiate(projectilePrefabs[0], transform.position, transform.rotation);
            var script = projectile.GetComponent<Projectile>();
            script.setJumpForce(30f);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.right * projectileSpeed;
            }

            _chargeTime = 0f;
        }
        else if (chargeRatio < 0.66f)
        {
            GameObject projectile = Instantiate(projectilePrefabs[1], transform.position, transform.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            var script = projectile.GetComponent<Projectile>();
            script.setJumpForce(35f);
            if (rb != null)
            {
                rb.velocity = transform.right * projectileSpeed;
            }

            _chargeTime = 0f;
        }
        else
        {
            GameObject projectile = Instantiate(projectilePrefabs[2], transform.position, transform.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            var script = projectile.GetComponent<Projectile>();
            script.setJumpForce(43f);
            if (rb != null)
            {
                rb.velocity = transform.right * projectileSpeed;
            }

            _chargeTime = 0f;
        }

    }

}
