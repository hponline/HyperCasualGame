using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class FinishLine : MonoBehaviour
{
    
    PlayerController playerController;
    CinemachineVirtualCamera virtualCamera;
    public GameObject finishScreen,pauseButton,timer;
    public Animator animCamera;
    private CinemachineBasicMultiChannelPerlin noise;
    
    private void Start()
    {
       virtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
       animCamera =animCamera.GetComponent<Animator>();
       noise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    }
    private void OnTriggerEnter(Collider other)
    {
        Animator animator = other.GetComponent<Animator>();
        playerController = other.GetComponent<PlayerController>();
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isRunning", false);            
            animator.SetBool("isWin", true);
            PauseButton();
            
            if (playerController)
            {
                playerController.z_speed = 0;
                playerController.transform.rotation = Quaternion.Euler(0, -180, 0);
                virtualCamera.Follow = null;

                // Kamera titresmesini durdurur
                noise.m_AmplitudeGain = 0;
                animCamera.SetBool("isFinish", true );
                timer.SetActive(false);

                Invoke("WaitForSecond", 4);
            }
        }       
    }

    void WaitForSecond()
    {
        finishScreen.SetActive(true);       
    }

    public void PauseButton()
    {
        pauseButton.SetActive(false);
    }
}
