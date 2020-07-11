using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairMinigame : MonoBehaviour
{
    public ShipPart part;
    public MinigameDirection[] possibleDirections;
    public List<MinigameArrow> currentDirections = new List<MinigameArrow>();
    public GameObject arrowContainer;
    public float outerMargin;
    public float innerMargin;
    public int arrowsLength;
    public void Init(ShipPart _part, int _length)
    {
        part = _part;
        arrowsLength = _length;
        GenerateDirections();
    }

    void GenerateDirections()
    {
        for (int i = 0;i < arrowsLength; i++)
        {
            int index = Random.Range(0, possibleDirections.Length - 1);
            MinigameDirection dir = possibleDirections[index];
            GameObject go = Instantiate(arrowContainer, transform);
            MinigameArrow arrow = go.GetComponent<MinigameArrow>();
            arrow.Init(dir);
            go.GetComponent<RectTransform>().anchoredPosition = Vector2.right *( outerMargin + (i) * (innerMargin + dir.icon.bounds.size.x));
            currentDirections.Add(arrow);
        }
    }

    void RemoveArrow()
    {
        GameObject go = currentDirections[0].gameObject;
        currentDirections.Remove(currentDirections[0]);
        Destroy(go);
    }

}

