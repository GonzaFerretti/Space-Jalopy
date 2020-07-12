using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairMinigame : MonoBehaviour
{
    public ShipPart part;
    public InterfaceColorSettings colors;
    public MinigameDirection[] possibleDirections;
    public List<MinigameArrow> currentDirections = new List<MinigameArrow>();
    public GameObject arrowContainer;
    public float outerMargin;
    public float innerMargin;
    public int arrowsLength;
    public float playerHeightMargin;
    public Vector2 lastSize;
    public void Init(ShipPart _part, int _length)
    {
        part = _part;
        arrowsLength = _length;
        GenerateDirections();
        GetComponent<Transform>().position = part.transform.parent.position - Vector3.up * playerHeightMargin;
        gameObject.SetActive(true);
    }

    public void Update()
    {

        GetComponent<Transform>().position = part.transform.parent.position - Vector3.up * playerHeightMargin;
    }

    void GenerateDirections()
    {
        float containerSize = arrowContainer.GetComponent<RectTransform>().sizeDelta.x;
        for (int i = 0; i < arrowsLength; i++)
        {
            int index = Random.Range(0, possibleDirections.Length - 1);
            MinigameDirection dir = possibleDirections[index];
            GameObject go = Instantiate(arrowContainer, transform);
            MinigameArrow arrow = go.GetComponent<MinigameArrow>();
            arrow.Init(dir);
            go.GetComponent<RectTransform>().anchoredPosition = Vector2.right * (outerMargin + (i) * (innerMargin + containerSize));
            if (i == 0)
            {
                arrow.GetComponent<Image>().color = colors.firstArrowColor;
            }
            else
            {
                arrow.GetComponent<Image>().color = colors.baseArrowColor;
            }
            currentDirections.Add(arrow);
        }

        GetComponent<RectTransform>().sizeDelta = new Vector2(2 * outerMargin + arrowsLength * (innerMargin + containerSize), 2 * outerMargin + containerSize);
        lastSize = new Vector2(2 * outerMargin + arrowsLength * (innerMargin + containerSize), 2 * outerMargin + containerSize); 
    }

    public bool RemoveCurrentArrow()
    {
        GameObject go = currentDirections[0].gameObject;
        currentDirections.Remove(currentDirections[0]);
        Destroy(go);
        bool finished = currentDirections.Count == 0;
        for (int i = 0; i < currentDirections.Count; i++)
        {
            if (i == 0)
            {
                currentDirections[i].GetComponent<Image>().color = colors.firstArrowColor;
            }
            float containerSize = arrowContainer.GetComponent<RectTransform>().sizeDelta.x;
            currentDirections[i].GetComponent<RectTransform>().anchoredPosition = Vector2.right * (outerMargin + (i) * (innerMargin + containerSize));
        }
        if (finished)
        {
            Reset();
        }
        return finished;
    }

    public void Reset()
    {
        for (int i = 0; i < currentDirections.Count; i++)
        {
            GameObject go = currentDirections[0].gameObject;
            if (part.partStatus == repairState.isBeingRepaired)
            {
                part.Break();
            }
            currentDirections.Remove(currentDirections[0]);
        }
        gameObject.SetActive(false);
    }
}

