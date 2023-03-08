using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdsSounds : MonoBehaviour
{
    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip[] birdsClips;
    [SerializeField] private float minDelay = 1.5f;
    [SerializeField] private float maxDelay = 5f;
    [SerializeField] private float minSphereRadius = 10f;
    [SerializeField] private float maxSphereRadius = 50f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
        StartCoroutine(BirdCoroutine());
    }

    private IEnumerator BirdCoroutine()
    {
        Vector3 randomDirection = Random.onUnitSphere;
        randomDirection.y = Mathf.Abs(randomDirection.y);
        Vector3 position = (float)Random.Range(minSphereRadius, maxSphereRadius) * randomDirection;
        transform.position = position + startPosition;


        audiosource.PlayOneShot(birdsClips[Random.Range(0, birdsClips.Length)]);
        yield return new WaitForSeconds((float)Random.Range(minDelay, maxDelay));


        StartCoroutine(BirdCoroutine());
    }
}
