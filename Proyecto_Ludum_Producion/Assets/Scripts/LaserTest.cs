using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTest : MonoBehaviour
{
    public GameObject LaserParticles;
    public SpriteRenderer SpriteRend;
    public float LaserLength;
    public float TimeAlive = 5.0f;

    private RaycastHit2D _hit;
    private bool _particlesActive;
    private GameObject _particles;


    private void Start()
    {
        transform.localScale = new Vector3(1f, LaserLength, 1f);
        InvokeRepeating("Autodestroy", TimeAlive, 1);
    }

    private void Update()
    {
        if (_hit.collider != null && _hit.transform.gameObject.tag == "Wall")
        {
            transform.localScale = new Vector3(1f, Vector2.Distance(_hit.point, transform.position) / SpriteRend.size.y, 1f);

            LaserParticles.SetActive(true);
            LaserParticles.transform.position = _hit.point;
        }
        else
        {
            if (_hit.transform.gameObject.tag == "Player")
            {
                _hit.transform.GetComponent<PlayerDeath>().Die = true;
            }

            transform.localScale = new Vector3(1f, LaserLength, 1f);
            LaserParticles.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        _hit = Physics2D.Raycast(transform.position, transform.up, SpriteRend.size.y * transform.localScale.y);
    }

    public void SetLaserLength(int length)
    {
        LaserLength = length;
    }

    public void Autodestroy()
    {
        Destroy(transform.parent.gameObject);
    }
}