using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{

    public Slider volume;
    public AudioSource audio1;

    public float Backvolume = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        Backvolume = PlayerPrefs.GetFloat("backvol", 1f);
        volume.value = Backvolume;
        audio1.volume = volume.value;
    }

    // Update is called once per frame
    void Update()
    {
        soundSlider();
    }
    public void soundSlider()
    {
        audio1.volume = volume.value;
        Backvolume = volume.value;
        PlayerPrefs.SetFloat("backvol", Backvolume);

    }
}
