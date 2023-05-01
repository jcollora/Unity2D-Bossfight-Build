using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    private GameObject finishLine = null;
    private GameObject player = null;
    private GameObject start = null;
    private RectTransform rectangle;
    private float startX;
    private float finishX;
    private float totalDistance;
    private float newWidth;
    private float barXOffset;
    private float progressBarWidth = 300f; //Manually set
    // Start is called before the first frame update
    void Start()
    {
        rectangle = GetComponent<RectTransform>();
        player = GameObject.Find("MainCharacter");
        finishLine = GameObject.Find("Finish");
        start = GameObject.Find("Start");
        startX = start.transform.position.x;
        finishX = finishLine.transform.position.x;
        totalDistance = finishX - startX;
    }

    // Update is called once per frame
    void Update()
    {
        newWidth = ((player.transform.position.x - startX)/totalDistance) * progressBarWidth;
        barXOffset = newWidth - rectangle.sizeDelta.x;
        rectangle.sizeDelta = new Vector2(newWidth, rectangle.sizeDelta.y);
        rectangle.transform.position = new Vector3(rectangle.transform.position.x + (barXOffset / 2), rectangle.transform.position.y, 0);
    }
}
