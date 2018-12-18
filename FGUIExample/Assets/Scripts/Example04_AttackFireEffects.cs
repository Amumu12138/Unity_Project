using UnityEngine;
using System.Collections;
using FairyGUI;
using DG.Tweening;

public class Example04_AttackFireEffects : MonoBehaviour {

    private GComponent mainUi;
    private float startAttack;
    private float endAttack;
	// Use this for initialization
	void Start () {
        Debug.Log("Example04_AttackFireEffects");

        GRoot.inst.SetContentScaleFactor(1334, 750);
        UIPackage.AddPackage("UI/Example04_AttackFireEffects");
        mainUi = UIPackage.CreateObject("Example04_AttackFireEffects", "Main").asCom;
        mainUi.GetTransition("t0").SetHook("addAttack", AddAttackValue);
        GRoot.inst.AddChild(mainUi);

        startAttack = 10000;
        int addAttack = Random.Range(1000, 3000);
        endAttack = startAttack + addAttack;
        Transition t = mainUi.GetTransition("t0");
        mainUi.GetChild("n2").text = startAttack.ToString();
        mainUi.GetChild("n3").text = "+" + addAttack.ToString();
        t.Play();
	}

    private void AddAttackValue()
    {
        DOTween.To(() => startAttack, x => { mainUi.GetChild("n2").text = Mathf.Floor(x).ToString(); },
            endAttack, 0.3f).SetEase(Ease.Linear).SetUpdate(true);
    }
	
}
