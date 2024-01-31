using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceScript : MonoBehaviour
{
    [HideInInspector]
    public bool draggable;
    [HideInInspector]
    public bool isDragging;

    public bool isHighlighted;

    public Vector3 currentRot;

    // Start is called before the first frame update
    void Start()
    {
        //draggable = true;
        //currentRot = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = RoundPosition(transform.position);
        currentRot = RoundRotation(currentRot);
        transform.rotation = Quaternion.Euler(currentRot);
        isHighlighted = false;
    }

    private void LateUpdate()
    {
        if (transform.position.y > 5.4f)
        {
            transform.position = new Vector3(transform.position.x, 5.4f, transform.position.z);
        }
        if (transform.position.y < 5.1f)
        {
            transform.position = new Vector3(transform.position.x, 5.1f, transform.position.z);
        }
    }

    public void Rotate()
    {
        currentRot.y += 90f;
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z));
    }

    public void Flip()
    {
        currentRot.x += 180f;
        //transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.eulerAngles.x + 180f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z));
    }

    public static Vector3 RoundPosition(Vector3 position)
    {
        // Rounds to nearest 0.2f;
        return new Vector3(Mathf.Round(position.x * (1f/0.2f)) / (1f / 0.2f), position.y, Mathf.Round(position.z * (1f / 0.2f)) / (1f / 0.2f));
    }

    public static Vector3 RoundRotation(Vector3 rotation)
    {
        // Rounds to nearest allowed rotations.
        return new Vector3(Mathf.Round(rotation.x * (1f/180f)) / (1f / 180f), Mathf.Round(rotation.y * (1f / 90f)) / (1f / 90f), rotation.z);
    }

    public void Highlight()
    {
        if (!isHighlighted)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).GetComponent<Outline>().enabled = true;
            }
            isHighlighted = true;
        }
        
    }

    public void Unhighlight()
    {
        if (isHighlighted)
        {
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                this.gameObject.transform.GetChild(i).GetComponent<Outline>().enabled = false;
            }
            isHighlighted = false;
        }
        
    }
}
