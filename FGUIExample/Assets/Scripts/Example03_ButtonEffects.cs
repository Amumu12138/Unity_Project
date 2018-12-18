using UnityEngine;
using System.Collections;
using FairyGUI;

public class Example03_ButtonEffects : MonoBehaviour {
    private GButton button;
    private GComponent bossCom;
	// Use this for initialization
	void Start () {
        Debug.Log("Example03_ButtonEffects");
        GRoot.inst.SetContentScaleFactor(1334, 750);
        UIPackage.AddPackage("UI/Example03_ButtonEffects");
        GComponent component = UIPackage.CreateObject("Example03_ButtonEffects", "Button").asCom;
        GRoot.inst.AddChild(component);

        button = component.asButton;
        bossCom = UIPackage.CreateObject("Example03_ButtonEffects", "Boss").asCom;
        button.onClick.Add(() => { PlayUI(bossCom); });     //() => {};lambda表达式
        //button.onClick.Add(Example);
    }
    /// <summary>
    /// 测试用例
    /// </summary>
    private void Example()
    {
        Debug.Log("Example");
    }

    private void PlayUI(GComponent targetCom)
    {
        Debug.Log("PlayUI");
        button.visible = false;
        GRoot.inst.AddChild(targetCom);
        Transition t = targetCom.GetTransition("t0");
        t.Play(() =>
        {
            button.visible = true;
            GRoot.inst.RemoveChild(targetCom);       
        });
    }
}
