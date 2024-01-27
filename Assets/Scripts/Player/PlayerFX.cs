using System;
using System.Collections;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    private const string SQUISH_ANIM_TRIGGER = "Squish";

    [SerializeField] private EventsSo eventsSo;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private SFX_SO sfx_so;
    [SerializeField] private Animator[] leftBlowFXArray;
    [SerializeField] private Animator[] rightBlowFXArray;
    [SerializeField] private float audioChangeTimer;

    private AudioClip squishClip;

    private void Start()
    {
        eventsSo.OnPlayerMove += PlayAnimation;
        eventsSo.OnPlayerMove += PlayBlowFX;
        eventsSo.OnPlayerDie += OnPlayerDie;
        squishClip = sfx_so.GetBalloonSquishSFX();
        StartCoroutine(ChangeAudioClip());
    }

    private IEnumerator ChangeAudioClip()
    {
        while (true)
        {
            yield return new WaitForSeconds(audioChangeTimer);
            squishClip = sfx_so.GetBalloonSquishSFX();
        }
    }

    private void OnDestroy()
    {
        eventsSo.OnPlayerMove -= PlayAnimation;
        eventsSo.OnPlayerMove -= PlayBlowFX;
        eventsSo.OnPlayerDie -= OnPlayerDie;
        StopAllCoroutines();
    }

    private void OnPlayerDie()
    {
        audioSource.PlayOneShot(sfx_so.GetPlayerDeathSfx(), 1f);
    }

    private void PlayBlowFX(int direction)
    {
        audioSource.PlayOneShot(squishClip, 1f);

        if (direction == 1)
        {
            int randomIDX = UnityEngine.Random.Range(0, leftBlowFXArray.Length);
            leftBlowFXArray[randomIDX].SetTrigger("Fart");
        }
        else if (direction == -1)
        {
            int randomIDX = UnityEngine.Random.Range(0, rightBlowFXArray.Length);
            rightBlowFXArray[randomIDX].SetTrigger("Fart");
        }
    }

    private void PlayAnimation(int direction)
    {
        playerAnimator.SetTrigger(SQUISH_ANIM_TRIGGER);
    }
}
