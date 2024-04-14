using UnityEngine.Tilemaps;
using UnityEngine;

public class sazPower : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    public void Power()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = new Vector3(mousePos.x, mousePos.y, 10f);
        Vector3 wMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 selectedGrid = new(Mathf.FloorToInt(wMousePos.x)+0.5f, Mathf.FloorToInt(wMousePos.y) + 0.5f);
        Debug.Log(mousePos);
        foreach (  GameObject gm in GameObject.FindGameObjectsWithTag("Ground"))
        {
            if ((Vector2)gm.transform.position == selectedGrid)
            {
                return;
            }
            
        }
        GameObject.Instantiate(prefab, selectedGrid, Quaternion.identity);
    }

}
