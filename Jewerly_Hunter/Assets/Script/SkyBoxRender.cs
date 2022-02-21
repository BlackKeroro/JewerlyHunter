using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxRender : MonoBehaviour
{
    public Material TwoSkyboxMaterial;
    public Material ThreeSkyboxMaterial;

    GameObject player;
    TrailRenderer Tr;
    PlayerController PC;

    public GameObject Particle;
    ParticleSystem PS; // 바람


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
        if(transform.position.x >= 190)
        {
            RenderSettings.skybox = TwoSkyboxMaterial;
            if(PC.UpSpeed == 0)
            {
                PC.MoveSpeed = 11f;
                PS.startSpeed = 20.0f;
                ParticleSystem.TrailModule trails = PS.trails;
                trails.ratio = 0.24f;
                PC.UpSpeed++;
            }
        }
        if(transform.position.x >= 520)
        {
            RenderSettings.skybox = ThreeSkyboxMaterial;
            transform.GetChild(0).gameObject.SetActive(true);
            if (PC.UpSpeed == 1)
            {
                PC.MoveSpeed = 14f;
                PS.startSpeed = 26.0f;
                ParticleSystem.TrailModule trails = PS.trails;
                trails.ratio = 0.36f;
                PC.UpSpeed++;
            }
        }
    }
}
