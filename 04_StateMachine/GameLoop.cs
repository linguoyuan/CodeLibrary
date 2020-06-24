using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private GameStateController controller = null;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {
        controller = new GameStateController();
        controller.SetState(new StartState(controller));
    }

    // Update is called once per frame
    void Update()
    {
        if (controller != null)
            controller.StateUpdate();
    }
}
