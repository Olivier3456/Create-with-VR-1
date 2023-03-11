using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Rigidbody rigid;

    [SerializeField] private AudioClip[] audioClips;


    private void OnCollisionEnter(Collision collision)
    {
        float volume = Mathf.Clamp(rigid.velocity.magnitude * 0.4f, 0, 1);
        
        Debug.Log("rigid.velocity.magnitude of the ball's rigidbody: " + rigid.velocity.magnitude);
        audioSource.volume = volume;
        audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
    }
}
