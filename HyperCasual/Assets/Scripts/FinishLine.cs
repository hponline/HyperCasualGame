using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class FinishLine : MonoBehaviour
{
    
    PlayerController playerController;
    CinemachineVirtualCamera virtualCamera;
    public GameObject finishScreen;
    public Animator animCamera;

    private void Start()
    {
       virtualCamera = GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
       animCamera =animCamera.GetComponent<Animator>();

    }
    private void OnTriggerEnter(Collider other)
    {
        Animator animator = other.GetComponent<Animator>();
        playerController = other.GetComponent<PlayerController>();
        if (other.CompareTag("Player"))
        {
            animator.SetBool("isRunning", false);            
            animator.SetBool("isWin", true);

            if (playerController)
            {
                playerController.z_speed = 0;
                playerController.transform.rotation = Quaternion.Euler(0, -180, 0);
                virtualCamera.Follow = null;

                animCamera.SetBool("isFinish", true );
                Invoke("WaitForSecond", 4);
            }
        }                
    }

    void WaitForSecond()
    {
        finishScreen.SetActive(true);
    }
}
