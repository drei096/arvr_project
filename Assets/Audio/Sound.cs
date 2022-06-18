using UnityEngine;
using UnityEngine.Audio;

public enum SoundCode
{
    NONE = -1,
    CRY_BULBASAUR,
    CRY_CHARMANDER,
    CRY_SQUIRTLE,
    CRY_PIDGEY,
    CRY_PIKACHU,
    CRY_NIDORANF,
    CRY_VULPIX,
    CRY_ODDISH,
    CRY_PSYDUCK,
    CRY_GROWLITHE,
    CRY_POLIWAG,
    CRY_MACHOP,
    CRY_FARFETCHD,
    CRY_SEEL,
    CRY_CUEBONE,
    CRY_EEVEE,
    MOVE_SCRATCH,
    MOVE_EMBER,
    MOVE_TACKLE,
    MOVE_WATER_GUN,
    MOVE_VINE_WHIP,
    MOVE_GUST,
    MOVE_THUNDER_SHOCK,
    MOVE_QUICK_ATTACK,
    MOVE_POISON_STING,
    MOVE_ABSORB,
    MOVE_ACID,
    MOVE_CONFUSION,
    MOVE_BITE,
    MOVE_POUND,
    MOVE_KARATE_CHOP,
    MOVE_LOW_KICK,
    MOVE_PECK,
    MOVE_FURY_ATTACK,
    MOVE_HEADBUTT,
    MOVE_BONE_CLUB,
    EFF_BLANK,
    BGM_EXPLORING,
    BGM_ENCOUNTER_START,
    BGM_VICTORY,
    SFX_ENCOUNTER_ALERT,
    SFX_MENU_ACCESS,
    SFX_UI_CLICK
}

[System.Serializable]
public class Sound
{
    public SoundCode code = SoundCode.NONE;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1.0f;
    [Range (.1f, 3f)]
    public float pitch = 1.0f;

    public bool loop;

    [HideInInspector]
    public AudioSource source;
     
}
