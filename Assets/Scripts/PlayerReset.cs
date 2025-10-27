using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using HutongGames.PlayMaker;

public class PlayerReset : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameScene") // atau GameMode, sesuaikan nama scene gameplay kamu
        {
            var player = GameObject.Find("Player");
            if (player != null)
            {
                var fsms = player.GetComponents<PlayMakerFSM>();
                foreach (var fsm in fsms)
                {
                    if (fsm.FsmName == "PlayerLife")
                    {
                        //fsm.SendEvent("Reset");
                        fsm.enabled = false;
                        fsm.enabled = true;
                        Debug.Log("FSM PlayerLife di-reset ulang.");
                    }
                        
                }
            }
        }
    }
}
