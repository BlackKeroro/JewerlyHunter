using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option : MonoBehaviour
{
    //배경음악 사운드 및 사용할 볼륨 슬라이더
    public Slider volume;
    public AudioSource audio1;

    public float Backvolume = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        //시작 시 사운드 1 적용
        Backvolume = PlayerPrefs.GetFloat("Backvolume", Backvolume);
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
        //사운드 슬라이더 만큼 볼륨 수치 변환
        audio1.volume = volume.value;
        Backvolume = volume.value;
        //볼륨 값을 저장하여 설정
        PlayerPrefs.SetFloat("Backvolume", Backvolume);

    }
}
