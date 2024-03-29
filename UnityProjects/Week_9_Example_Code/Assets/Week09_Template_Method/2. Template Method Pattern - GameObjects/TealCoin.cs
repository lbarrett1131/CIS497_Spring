﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TealCoin : PickupCoinSuperclass
{
    public GameObject tutorialText;

    public AudioClip coinPickup;
    AudioSource audioSource;

    public ParticleSystem particleEffect;

    void Awake()
    {
        tutorialText = GameObject.FindGameObjectWithTag("CoinPickupTutorialText");
    }

    void Start()
    {
        if (tutorialText.activeSelf)
        {
            tutorialText.SetActive(false);
        }

        audioSource = GetComponent<AudioSource>();
    }

    public override IEnumerator ShowTutorialText()
    {
        tutorialText.SetActive(true);
        yield return new WaitForSeconds(5);
        tutorialText.SetActive(false);
    }

    public override IEnumerator PlayParticleEffect()
    {
        particleEffect.Play();
        yield return new WaitForSeconds(8);
        particleEffect.Stop();
    }

    public override void PlaySoundEffect()
    {
        audioSource.PlayOneShot(coinPickup);
    }
}
