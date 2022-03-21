using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRender : MonoBehaviour
{
    //다음 스테이지에 변경할 스카이박스
    public Material TwoSkyboxMaterial;
    public Material ThreeSkyboxMaterial;

    GameObject player;
    TrailRenderer Tr;
    PlayerController PC;

    public GameObject Particle;
    ParticleSystem PS; // 바람 파티클


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Tr = player.GetComponent<TrailRenderer>();
        PC = player.GetComponent<PlayerController>();
        PS = Particle.GetComponent<ParticleSystem>();
       
    }

    // Update is called once per frame
    void Update()
    {
        //스크립트가 들어있는 카메라의 X위치가 190이상일 때
        if(transform.position.x >= 190)
        {
            //스카이 박스에 2스테이지의 스카이박스 Material 대입
            RenderSettings.skybox = TwoSkyboxMaterial;
            if(PC.UpSpeed == 0)// UpSpeed(스테이지에 따른 속도 변화, 1stage == 0)
            {
                PC.MoveSpeed = 11f; //플레이어 이동 속도 증가
                PS.startSpeed = 20.0f; //바람 파티클 스피드
                ParticleSystem.TrailModule trails = PS.trails;
                trails.ratio = 0.24f;//파티클의 잔상을 남길 확률
                PC.UpSpeed++;
            }
        }
        //스크립트가 들어있는 카메라의 X위치가 520이상알 땨
        if(transform.position.x >= 520)
        {
            //스카이 박스에 3스테이지의 스카이박스 Material 대입
            RenderSettings.skybox = ThreeSkyboxMaterial;
            transform.GetChild(0).gameObject.SetActive(true); // 달 이미지 활성화
            if (PC.UpSpeed == 1) //UpSpeed가 1일 때(2stage)
            {
                PC.MoveSpeed = 14f;// 플레이어 이동 속도 증가
                PS.startSpeed = 26.0f;//바람 파티클 속도 증가
                ParticleSystem.TrailModule trails = PS.trails;
                trails.ratio = 0.36f;
                PC.UpSpeed++;
            }
        }
    }
}
