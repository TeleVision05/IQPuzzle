using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TouchDetector : MonoBehaviour
{
    /*
    float height;

    // Start is called before the first frame update
    void Start()
    {
        height = 5.16f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            height = 5.36f;
        }
        else
        {
            height = 5.16f;
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 3.5f));
            
            //transform.position = Camera.main.ScreenToWorldPoint(touch);
        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.tag == "Piece" & Input.touchCount > 0)
        {
            GameObject piece = collider.gameObject;
            PieceScript pieceScript = piece.GetComponent<PieceScript>();

            if (!pieceScript.draggable)
            {
                return;
            }

            piece.transform.position = PieceScript.RoundPosition(transform.position);
            piece.transform.position = new Vector3(piece.transform.position.x, 5.36f, piece.transform.position.z);
        }
    }


    void Two2Three(float x, float y, float knowny)
    {
        float numerator1, cosx, cosy, y_shift, x_shift, view_factor, siny, sinx;
        
        numerator1 = (cosx**2 * cosy * x * knowny) + \
                (-1 * cosx * *2 * cosy * x * (y_shift - 100)) + \
                (cosx * cosy * *2 * y * -1 * x_shift) + \
                (cosx * y * siny * *2 * -1 * x_shift) + \
                (-1 * cosx * y * siny * view_factor) + \
                (cosx * siny * view_factor * (y_shift - 100)) + \
                (cosy * *2 * sinx * view_factor * -1 * x_shift) + \
                (cosy * x * knowny * sinx * *2) + \
                (-1 * cosy * x * sinx * *2 * (y_shift - 100)) + \
                (y * knowny * sinx * siny) + \
                (-1 * y * sinx * siny * (y_shift - 100)) + \
                (sinx * siny * *2 * view_factor * -1 * x_shift)
        
    }

    */



    // ONLINE

    //public string draggingTag;
    //public Camera cam;

    //private Vector3 dis;
    //private float posX;
    //private float posY;

    //private bool touched = false;
    //private bool dragging = false;

    //private Transform toDrag;
    //private Rigidbody toDragRigidbody;
    //private Vector3 previousPosition;

    //private void Start()
    //{

    //}


    //void FixedUpdate()
    //{

    //    if (Input.touchCount != 1 && Input.touchCount != 2)
    //    {
    //        dragging = false;
    //        touched = false;
    //        if (toDragRigidbody)
    //        {
    //            SetFreeProperties(toDragRigidbody);
    //        }

    //        return;
    //    }





    //    Touch touch = Input.touches[0];
    //    Vector3 pos = touch.position;

    //    if (touch.phase == TouchPhase.Began)
    //    {
    //        RaycastHit hit;
    //        Ray ray = cam.ScreenPointToRay(pos);

    //        if (Physics.Raycast(ray, out hit))
    //        {
    //            if (hit.transform.gameObject.GetComponentInParent<Rigidbody>().gameObject.CompareTag(draggingTag))
    //            {
    //                toDrag.gameObject.GetComponent<PieceScript>().Unhighlight();
    //                toDrag = hit.transform.gameObject.GetComponentInParent<Rigidbody>().gameObject.transform;
    //                previousPosition = toDrag.position;
    //                toDragRigidbody = toDrag.GetComponent<Rigidbody>();

    //                dis = cam.WorldToScreenPoint(previousPosition);
    //                posX = Input.GetTouch(0).position.x - dis.x;
    //                posY = Input.GetTouch(0).position.y - dis.y;

    //                SetDraggingProperties(toDragRigidbody);

    //                touched = true;
    //                toDrag.gameObject.GetComponent<PieceScript>().Highlight();
    //            }
    //            else
    //            {
    //                toDrag.gameObject.GetComponent<PieceScript>().Unhighlight();
    //            }

    //        }

    //    }

    //    if (touched && touch.phase == TouchPhase.Moved)
    //    {
    //        if (toDrag.gameObject.GetComponent<PieceScript>().draggable)
    //        {
    //            dragging = true;

    //            float posXNow = Input.GetTouch(0).position.x - posX;
    //            float posYNow = Input.GetTouch(0).position.y - posY;
    //            Vector3 curPos = new Vector3(posXNow, posYNow, dis.z);

    //            Vector3 worldPos = cam.ScreenToWorldPoint(curPos);
    //            worldPos = new Vector3(worldPos.x, 5.4f, worldPos.z);

    //            //toDragRigidbody.velocity = worldPos / (Time.deltaTime * 10);
    //            toDrag.position = worldPos;


    //            previousPosition = toDrag.position;
    //        }
    //    }

    //    if (dragging && (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled))
    //    {
    //        dragging = false;
    //        touched = false;
    //        previousPosition = new Vector3(0.0f, 0.0f, 0.0f);
    //        SetFreeProperties(toDragRigidbody);
    //    }



    //}

    //private void SetDraggingProperties(Rigidbody rb)
    //{
    //    rb.useGravity = false;
    //}

    //private void SetFreeProperties(Rigidbody rb)
    //{
    //    rb.useGravity = true;
    //}

    //public void Rotate()
    //{
    //    if (toDrag.gameObject.GetComponent<PieceScript>().isHighlighted)
    //    {
    //        toDrag.gameObject.GetComponent<PieceScript>().Rotate();
    //    }
    //}

    //public void Flip()
    //{
    //    if (toDrag.gameObject.GetComponent<PieceScript>().isHighlighted)
    //    {
    //        toDrag.gameObject.GetComponent<PieceScript>().Flip();
    //    }
    //}


    public string draggingTag;
    public Camera cam;

    private Vector3 dis;
    private float posX;
    private float posY;

    private bool touched = false;
    private bool dragging = false;

    private Transform toDrag;
    private Rigidbody toDragRigidbody;
    private Vector3 previousPosition;

    private void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    // Input is polled per rendered frame, so it must be read in Update (FixedUpdate can miss clicks).
    void Update()
    {
        Vector3 pos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            HandlePress(pos);
        }

        if (touched && toDrag != null && Input.GetMouseButton(0))
        {
            DragSelected();
        }

        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            touched = false;
            previousPosition = Vector3.zero;
            if (toDragRigidbody)
            {
                SetFreeProperties(toDragRigidbody);
            }
        }
    }

    private void HandlePress(Vector3 pos)
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(pos);

        if (!Physics.Raycast(ray, out hit))
        {
            return;
        }

        Rigidbody hitBody = hit.transform.GetComponentInParent<Rigidbody>();
        bool isPiece = hit.transform.CompareTag(draggingTag) || (hitBody != null && hitBody.CompareTag(draggingTag));

        if (!isPiece || hitBody == null)
        {
            Deselect();
            return;
        }

        if (toDrag == hitBody.transform)
        {
            // Clicking the selected piece again toggles the selection off.
            Deselect();
            return;
        }

        Deselect();
        toDrag = hitBody.transform;
        previousPosition = toDrag.position;
        toDragRigidbody = hitBody;

        dis = cam.WorldToScreenPoint(previousPosition);
        posX = pos.x - dis.x;
        posY = pos.y - dis.y;

        SetDraggingProperties(toDragRigidbody);

        touched = true;
        PieceScript selected = PieceOf(toDrag);
        if (selected != null)
        {
            selected.Highlight();
        }
    }

    private void DragSelected()
    {
        PieceScript piece = PieceOf(toDrag);
        if (piece == null || !piece.draggable)
        {
            return;
        }

        dragging = true;

        float posXNow = Input.mousePosition.x - posX;
        float posYNow = Input.mousePosition.y - posY;
        Vector3 curPos = new Vector3(posXNow, posYNow, dis.z);

        Vector3 worldPos = cam.ScreenToWorldPoint(curPos);
        toDrag.position = new Vector3(worldPos.x, 5.4f, worldPos.z);
        previousPosition = toDrag.position;
    }

    private void Deselect()
    {
        if (toDrag != null)
        {
            PieceScript previous = PieceOf(toDrag);
            if (previous != null)
            {
                previous.Unhighlight();
            }
        }
        if (toDragRigidbody)
        {
            SetFreeProperties(toDragRigidbody);
        }
        toDrag = null;
        toDragRigidbody = null;
        touched = false;
        dragging = false;
    }

    private static PieceScript PieceOf(Transform t)
    {
        return t != null ? t.GetComponent<PieceScript>() : null;
    }

    private void SetDraggingProperties(Rigidbody rb)
    {
        rb.useGravity = false;
    }

    private void SetFreeProperties(Rigidbody rb)
    {
        rb.useGravity = true;
    }

    public void Rotate()
    {
        PieceScript piece = PieceOf(toDrag);
        if (piece != null && piece.isHighlighted)
        {
            piece.Rotate();
        }
    }

    public void Flip()
    {
        PieceScript piece = PieceOf(toDrag);
        if (piece != null && piece.isHighlighted)
        {
            piece.Flip();
        }
    }
}
