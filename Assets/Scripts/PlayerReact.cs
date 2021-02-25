using System.Collections;

using UnityEngine;

public class PlayerReact : MonoBehaviour
{
    private int health;
    Texture2D image;
    // Start is called before the first frame update
    void Start()
    {
       health = 3;

    }

    // Update is called once per frame
    void Update()
    {
       
    }
    public void HurtPlayer(int damage)
    {
        health -= damage;
        Debug.Log("Health:" + health);
        Managers.Player.ChangeLives();


    }


}
