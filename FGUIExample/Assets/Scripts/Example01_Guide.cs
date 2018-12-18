using UnityEngine;
using System.Collections;
using FairyGUI;

public class Example01_Guide : MonoBehaviour {

    private GComponent mainUi;
    private Controller controller;

    private float timer = 0;
    private float changeTime = 1.0f;
	// Use this for initialization
	void Start () {
        Debug.Log("Example01_Guide");
        mainUi = GetComponent<UIPanel>().ui;
        controller = mainUi.GetController("c1");
	}
	
	// Update is called once per frame
	void Update () {
        //1s后，切换c1控制器的状态为1
        timer += Time.deltaTime;

        if( timer >= changeTime)
        {
            timer = 0;
            controller.selectedIndex = 1;
        }
	}
}
