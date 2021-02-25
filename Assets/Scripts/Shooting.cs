using System.Collections;
using UnityEngine;

public class Shooting: MonoBehaviour
{
    private Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Managers.Inventory.equippedItem == "Arrow")
        {
            if (Input.GetMouseButtonDown(0))
            {


                // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                Vector4 point = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2,0) ;
                // calculating the ray in the middle point 
               Ray ray = camera.ScreenPointToRay(point);


                RaycastHit hit;
              

                // get the target point 
                if (Physics.Raycast(ray, out hit))
                {
                    // Debug.Log(" we hit " + hit.point);
                   GameObject hitObject = hit.transform.gameObject;
                    TargetReact target = hitObject.GetComponent<TargetReact>();

                    if (target != null)
                    {
                        //call the function of the target that shoted
                        target.HitReact();
                    }
                    // call SphereIndicator for visual indicators showing exactly where the ray hit.
                    else
                    {
                        StartCoroutine(SphereIndicator(hit.point));

                    }
                }
            }

        }
    }

    private IEnumerator SphereIndicator(Vector3 pos)
    {
       // pos.x =pos.x+ 3.5f;
        pos.z = pos.z + 15.0f;

        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(1);
        Destroy(sphere);
       

    }

    private void OnGUI()
    {
        if (Managers.Inventory.equippedItem == "Arrow")
        {
            // aiming in the center of a screen 
            int size = 12;
            float centerX = camera.pixelWidth / 2;
            float centerY = camera.pixelHeight / 2;
            GUI.Label(new Rect(centerX, centerY, size, size), "*");

            // make the mouse invisible , but not in the inventory data.
            Vector3 mouse = Input.mousePosition;
            Vector2 position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

           // Debug.Log(" Mouse X :" + Input.mousePosition.x + " y : " + Input.mousePosition.y);
            if (Input.mousePosition.x < 500 && Input.mousePosition.y > 300)
            {
                Cursor.visible = true;

            }
            else
            {
                if (Cursor.visible == true)
                    Cursor.visible = false;
            }

        }
    }
}
