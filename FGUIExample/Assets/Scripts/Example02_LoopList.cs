using UnityEngine;
using System.Collections;
using FairyGUI;

public class Example02_LoopList : MonoBehaviour {

    private GList list;
	// Use this for initialization
	void Start () {
        Debug.Log("Example02_LoopList");
        GRoot.inst.SetContentScaleFactor(1334, 750);
        UIPackage.AddPackage("UI/Example02_LoopList");
        GComponent component = UIPackage.CreateObject("Example02_LoopList", "Main").asCom;
        GRoot.inst.AddChild(component);
        //获取循环列表
        list = component.GetChild("n0").asList;
        list.SetVirtualAndLoop();
        list.itemRenderer = RenderListItem;
        list.numItems = 5;

        list.scrollPane.onScroll.Add(DoSpecialEffect);
        DoSpecialEffect();
	}
	
	private void RenderListItem(int index, GObject obj)
    {
        GButton button = obj.asButton;
        button.SetPivot(0.5f, 0.5f);        //设置Item描点为中心
        button.icon = UIPackage.GetItemURL("Example02_LoopList", "n" + (index + 1));
    }

    private void DoSpecialEffect()
    {
        float listCenter = list.scrollPane.posX + list.viewWidth / 2;

        for(int i = 0; i < list.numChildren; i++)
        {
            GObject item = list.GetChildAt(i);
            float itemCenter = item.x + item.width / 2;
            float itemWidth = item.width;
            float distance = Mathf.Abs(listCenter - itemCenter);
            if(distance < itemWidth)
            {
                //Item大小随中心距离而变化
                float distanceRange = 1 + (1 - distance / itemWidth) * 0.2f;
                item.SetScale(distanceRange, distanceRange);
            }
            else
            {
                item.SetScale(1, 1);
            }
        }
    }
}
