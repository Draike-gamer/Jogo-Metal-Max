using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ArmaPlayer : MonoBehaviour
{

    SpriteRenderer sprite;

    public GameObject Bullet;
    public Transform spawnBullet;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, spawnBullet.position, transform.rotation);
            PlayAudio();
        }
    }

    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePos.x < screenPoint.x);
    }
    void PlayAudio()
    {
        if (audioClip != null)
        {
            AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        }
        else
        {
            Debug.LogWarning("Nenhum áudio atribuído ao script.");
        }
    }
}
