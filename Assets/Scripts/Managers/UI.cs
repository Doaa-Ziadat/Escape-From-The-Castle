using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    int index=-1;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 1;
            
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 2;

        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 3;

        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 4;

        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            index = 5;

        }


    }
    private void OnGUI()
    {
        int xpos = 10;
        int ypos = 10;
        int width = 100;
        int height = 40;
        int space = 10;

        Texture2D imagee = Resources.Load<Texture2D>("Icons/" + "Heart");
        GUI.Box(new Rect(0, 100, 100, 40), new GUIContent(" (" + Managers.Player.lives + ")", imagee));

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
        int c = 0;
        foreach (string item in Items)
        {
            c++;
            if (GUI.Button(new Rect(xpos, ypos, width, 30), "Equip " + (item)))
            Managers.Inventory.EquipItem(item);
            //add also equib option by numbers
            if (index != -1 && c==index)
            {
                Managers.Inventory.EquipItem(item);
                index = -1;
            }
            xpos += width + space;

        }

 

       



    }
}
