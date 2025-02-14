﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  public class AudioManager : MonoBehaviour
  {
    private static AudioManager instance;
    [SerializeField]
    private bool muteSound;

    [SerializeField]
    private int objectPoolLength = 20;

    [SerializeField]
    private float soundDistance = 7f;

    [SerializeField]
    private bool logSounds = false;

    private List<AudioSource> pool = new List<AudioSource>();

    [SerializeField]
    private List<string> clipNames = new List<string>();

    [SerializeField]
    private List<AudioClip> clips = new List<AudioClip>();

    private void Awake()
    {
      instance = this;

      for (int i = 0; i < objectPoolLength; i++)
      {
        GameObject soundObject = new GameObject();
        soundObject.transform.SetParent(instance.transform);
        soundObject.name = "Sound Effect";
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f;
        audioSource.minDistance = instance.soundDistance;
        audioSource.gameObject.SetActive(false);
        pool.Add(audioSource);
      }
    }

    public static void PlaySound(string clip, Vector3 pos, ulong delay)
    {
        PlaySound(instance.clips[instance.clipNames.IndexOf(clip)], pos, delay);
    }

    public static void PlaySound(string clip, Vector3 pos)
    {
        PlaySound(instance.clips[instance.clipNames.IndexOf(clip)], pos);
    }

    public static void PlaySound(AudioClip clip, Vector3 pos, ulong delay)
    {
        if (!instance)
        {
            Debug.LogError("No Audio Manager found in the scene, make sure to add one if you want sound");
            return;
        }

        if (instance.muteSound)
        {
            return;
        }

        if (!clip)
        {
            Debug.LogError("Clip is null");
            return;
        }

        if (instance.logSounds)
        {
            Debug.Log("Playing Audio: " + clip.name);
        }

        for (int i = 0; i < instance.pool.Count; i++)
        {
            if (!instance.pool[i].gameObject.activeInHierarchy)
            {
                instance.pool[i].clip = clip;
                instance.pool[i].transform.position = Camera.main.transform.position;
                instance.pool[i].gameObject.SetActive(true);
                instance.pool[i].PlayScheduled(delay);
                instance.StartCoroutine(instance.ReturnToPool(instance.pool[i].gameObject, clip.length + delay));
                return;
            }
        }

        GameObject soundObject = new GameObject();
        soundObject.transform.SetParent(instance.transform);
        soundObject.name = "Sound Effect";
        AudioSource audioSource = soundObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 1f;
        audioSource.minDistance = instance.soundDistance;
        instance.pool.Add(audioSource);
        audioSource.clip = clip;
        soundObject.transform.position = pos;
        audioSource.PlayScheduled(delay);
        instance.StartCoroutine(instance.ReturnToPool(soundObject, clip.length + delay));
    }
    public static void PlaySound(AudioClip clip, Vector3 pos)
    {
        AudioManager.PlaySound(clip, pos, 0);
    }

    private IEnumerator ReturnToPool(GameObject obj, float delay)
    {
      yield return new WaitForSeconds(delay);
      obj.SetActive(false);
    }
  }