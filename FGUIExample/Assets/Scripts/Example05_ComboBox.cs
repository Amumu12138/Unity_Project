using UnityEngine;
using System.Collections;
using FairyGUI;
using System;

public class Example05_ComboBox : MonoBehaviour {

    private GComponent mainUi;
    private GProgressBar progressBar;
    private GComboBox comboBox;
	// Use this for initialization
	void Start () {
        Debug.Log("Example05_ComboBox");

        mainUi = GetComponent<UIPanel>().ui;
        progressBar = mainUi.GetChild("n0").asProgress;
        progressBar.TweenValue(100, 5);

        comboBox = mainUi.GetChild("n1").asComboBox;
        comboBox.onChanged.Add(SetCompleteTime);
	}
	
    private void SetCompleteTime()
    {
        progressBar.value = 0;
        progressBar.TweenValue(100, Convert.ToInt32(comboBox.value));
    }
}
