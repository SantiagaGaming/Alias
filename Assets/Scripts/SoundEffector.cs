using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffector : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip start, nextLevel, rightAnswer,wrongAnswer;

    public void PlayStartSound()
    {
        audioSource.PlayOneShot(start);
    }

    public void PlayNextLevelSound()
    {
        audioSource.PlayOneShot(nextLevel);
    }

    public void PlayRightAnswerSound()
    {
        audioSource.PlayOneShot(rightAnswer);
    }
    public void PlayWrondAnswerSound()
    {
        audioSource.PlayOneShot(wrongAnswer);
    }

}
