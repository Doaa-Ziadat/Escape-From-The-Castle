using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scope : MonoBehaviour
{
    public Animator animator;
    private bool isScpoed = false;
    public GameObject WeaponCamera;
    public GameObject scopeOverlay;
    public Camera mainCamera;
    public float ScopedFieldOfView = 15f;
    private float NormalFOV;

    void Update()
    {
        //scopeOverlay.SetActive(isScpoed);
        if (Managers.Inventory.equippedItem == "Arrow")
        {
            if (Input.GetMouseButtonDown(1))
            {
                isScpoed = !isScpoed;
                animator.SetBool("Scoped", isScpoed);
                if (isScpoed)
                    StartCoroutine(onScoped());
                else
                    onUnsoped();
            }
        }

      if (Managers.Inventory.equippedItem != "Arrow" &&  Input.GetMouseButtonDown(1) && isScpoed==true)
            {
                onUnsoped();

            }
 

    }

    IEnumerator onScoped()
    {
        yield return new WaitForSeconds(0.2f);
        scopeOverlay.SetActive(true);
       WeaponCamera.SetActive(true);
        // zoom in when shooting 
       NormalFOV = mainCamera.fieldOfView;
       mainCamera.fieldOfView = ScopedFieldOfView;

    }

    void onUnsoped()
    {

        scopeOverlay.SetActive(false);
        WeaponCamera.SetActive(false);
        // zoom out 
        mainCamera.fieldOfView = NormalFOV;

    }
}
