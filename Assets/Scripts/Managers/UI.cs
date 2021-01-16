using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private void OnGUI()
    {
        int xpos = 10;
        int ypos = 10;
        int width = 100;
        int height = 40;
        int space = 10;

        List<string> Items = Managers.Inventory.GetItems();
        if(Items.Count==0)
        {
            GUI.Box(new Rect(xpos, ypos, width, height), "No Items");
        }

        foreach(string item in Items)
        {
            int count = Managers.Inventory.GetItemCount(item);
            Texture2D image = Resources.Load<Texture2D>("Icons/" + item);
            GUI.Box(new Rect(xpos, ypos, width, height), new GUIContent(" (" + count + ")", image));
            //GUI.Box(new Rect(xpos, ypos, width, height), new GUIContent(item  +"(" + count + ")"));
            xpos += width + space;


        }

        string equipped = Managers.Inventory.equippedItem;
        if(equipped!=null)
        {
            xpos = 1000;
            Texture2D image = Resources.Load("Icons/" + equipped) as Texture2D;
            GUI.Box(new Rect(xpos, ypos, width, height), new GUIContent(" Equipped", image));

        }

        xpos = 10;
        ypos += height + space;
        foreach (string item in Items)
        {
            if (GUI.Button(new Rect(xpos, ypos, width, 30), "Equip " + (item)))
            Managers.Inventory.EquipItem(item);
            xpos += width + space;

        }
    }
}
