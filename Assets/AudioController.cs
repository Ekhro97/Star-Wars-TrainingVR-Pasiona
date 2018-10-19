using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour {

    [SerializeField]
    private AudioClip droneShot;

    public AudioClip DroneShot
    {
        get { return droneShot; }
        set { droneShot = value; }
    }

    [SerializeField]
    private AudioClip saberCollision;

    public AudioClip SaberCollision
    {
        get { return saberCollision; }
        set { saberCollision = value; }
    }

    [SerializeField]
    private AudioClip lightsaberLoop;

    public AudioClip LightsaberLoop
    {
        get { return lightsaberLoop; }
        set { lightsaberLoop = value; }
    }

    [SerializeField]
    private AudioClip lightsaberOn;

    public AudioClip LightsaberOn
    {
        get { return lightsaberOn; }
        set { lightsaberOn = value; }
    }

    [SerializeField]
    private AudioClip lightsaberOff;

    public AudioClip LightsaberOff
    {
        get { return lightsaberOff; }
        set { lightsaberOff = value; }
    }

    [SerializeField]
    private AudioClip lightsaberSwing;

    public AudioClip LightsaberSwing
    {
        get { return lightsaberSwing; }
        set { lightsaberSwing = value; }
    }

    [SerializeField]
    private AudioClip saberStrike;

    public AudioClip SaberStrike
    {
        get { return saberStrike; }
        set { saberStrike = value; }
    }

    public float masterVolume;

    private void Awake()
    {
        masterVolume = PlayerPrefs.GetFloat("MusicVolume");
    }
}
