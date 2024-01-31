using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{

    [SerializeField] private GameObject pieces;

    //private GameObject lightBlue;
    //private GameObject blue;
    //private GameObject violet;
    //private GameObject purple;
    //private GameObject pink;
    //private GameObject mahogany;
    //private GameObject red;
    //private GameObject orange;
    //private GameObject yellow;
    //private GameObject green;
    //private GameObject seaGreen;
    //private GameObject teel;


    // Start is called before the first frame update
    void Start()
    {
        Levels.Instance.Initialize();
        SetupPositions();
        //lightBlue = pieces.transform.GetChild(0).gameObject;
        //blue = pieces.transform.GetChild(1).gameObject;
        //violet = pieces.transform.GetChild(2).gameObject;
        //purple = pieces.transform.GetChild(3).gameObject;
        //pink = pieces.transform.GetChild(4).gameObject;
        //mahogany = pieces.transform.GetChild(5).gameObject;
        //red = pieces.transform.GetChild(6).gameObject;
        //orange = pieces.transform.GetChild(7).gameObject;
        //yellow = pieces.transform.GetChild(8).gameObject;
        //green = pieces.transform.GetChild(9).gameObject;
        //seaGreen = pieces.transform.GetChild(10).gameObject;
        //teel = pieces.transform.GetChild(11).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SetupPositions()
    {
        int currentLevel = PlayerPrefs.GetInt("currentLevel") - 1;
        Levels levels = Levels.Instance;
        for (int i = 0; i < 12; i++)
        {
            PieceScript pieceScript = pieces.transform.GetChild(i).gameObject.GetComponent<PieceScript>();
            if (Mathf.Abs(levels.posx[currentLevel][i]) < 10)
            {
                pieceScript.gameObject.transform.position = new Vector3(levels.posx[currentLevel][i] * 0.2f, 5.3f + i * 0.4f, levels.posy[currentLevel][i] * 0.2f);
                pieceScript.currentRot = new Vector3(levels.rotx[currentLevel][i] * 180f, levels.roty[currentLevel][i] * 90f, 0f);
                pieceScript.draggable = false;
            }
            else
            {
                pieceScript.draggable = true;
                pieceScript.currentRot = pieceScript.gameObject.transform.rotation.eulerAngles;
            }

        }
    }
}
