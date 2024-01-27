using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Assets/SFX Asset", fileName = "new SFX Asset")]
public class SFX_SO : ScriptableObject
{
    [SerializeField] private List<AudioClip> balloonSFXClips;
    [SerializeField] private List<AudioClip> deathSfx;

    public AudioClip GetPlayerDeathSfx()
    {
        int index = Random.Range(0, deathSfx.Count);
        return deathSfx[index];
    }

    public AudioClip GetBalloonSquishSFX()
    {
        int index = Random.Range(0, balloonSFXClips.Count);
        return balloonSFXClips[index];
    }
}
