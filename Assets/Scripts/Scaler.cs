using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scaler : MonoBehaviour {
    /// <summary>
    /// Fill screen with SpriteRenderer (it should be at 0,0,0)
    /// </summary>
    public void ResizeToFitScreen() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        transform.localScale = Vector3.one;

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        Vector3 xWidth = transform.localScale;
        xWidth.x = worldScreenWidth / width;
        transform.localScale = xWidth;
        Vector3 yHeight = transform.localScale;
        yHeight.y = worldScreenHeight / height;
        transform.localScale = yHeight;
    }

    public Vector3 GetObjectBounds(GameObject gameObject) {
        Vector3 objectBounds = Vector3.one;
        float width = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.x;
        float height = gameObject.GetComponent<SpriteRenderer>().sprite.bounds.size.y;

        float worldScreenHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        objectBounds.x = worldScreenWidth / width;
        objectBounds.y = worldScreenHeight / height;
        return objectBounds;
    }
}
