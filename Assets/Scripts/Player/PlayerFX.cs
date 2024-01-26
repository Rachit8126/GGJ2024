using System;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    private const string SQUISH_ANIM_TRIGGER = "Squish";

    [SerializeField] private EventsSo eventsSo;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private ParticleSystem[] leftBlowSFXArray;
    [SerializeField] private ParticleSystem[] rightBlowSFXArray;

    private void Start()
    {
        eventsSo.OnPlayerMove += PlayAnimation;
        eventsSo.OnPlayerMove += PlayBlowFX;
    }

    private void OnDestroy()
    {
        eventsSo.OnPlayerMove -= PlayAnimation;
        eventsSo.OnPlayerMove -= PlayBlowFX;
    }

    private void PlayBlowFX(int direction)
    {
        if (direction == 1)
        {
            int randomIDX = UnityEngine.Random.Range(0, leftBlowSFXArray.Length);
            leftBlowSFXArray[randomIDX].Play();
        }
        else if (direction == -1)
        {
            int randomIDX = UnityEngine.Random.Range(0, rightBlowSFXArray.Length);
            rightBlowSFXArray[randomIDX].Play();
        }
    }

    private void PlayAnimation(int direction)
    {
        playerAnimator.SetTrigger(SQUISH_ANIM_TRIGGER);
    }
}
