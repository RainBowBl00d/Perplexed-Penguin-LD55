using UnityEngine.Tilemaps;
using UnityEngine;

public class sazPower : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    public void Power()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 selectedGrid = new(Mathf.FloorToInt(mousePos.x)+0.5f, Mathf.FloorToInt(mousePos.y) + 0.5f);
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
