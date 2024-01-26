using System;
using UnityEngine;

public class PlayerFX : MonoBehaviour
{
    private const string SQUISH_ANIM_TRIGGER = "Squish";

    [SerializeField] private EventsSo eventsSo;
    [SerializeField] private Animator playerAnimator;

    private void Start()
    {
        eventsSo.OnPlayerMove += PlayAnimation;
    }

    private void OnDestroy()
    {
        eventsSo.OnPlayerMove -= PlayAnimation;
    }

    private void PlayAnimation()
    {
        playerAnimator.SetTrigger(SQUISH_ANIM_TRIGGER);
    }
}
