using UnityEngine.InputSystem;
using UnityEngine;

public class sazPower : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    public void Power()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        Vector3 wMousePos = Camera.main.ScreenToWorldPoint(new(mousePos.x, mousePos.y, 10f));

        Vector2 selectedGrid = new(Mathf.FloorToInt(wMousePos.x)+0.5f, Mathf.FloorToInt(wMousePos.y) + 0.5f);
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
