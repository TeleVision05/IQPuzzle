using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField]
    private GameObject pieces;

    [SerializeField]
    private Button hintButton;

    // Start is called before the first frame update
    void Start()
    {
        hintButton.onClick.AddListener(delegate { GenerateHint(); });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateHint()
    {
        Levels inst = Levels.Instance;
        int currentLevel = PlayerPrefs.GetInt("currentLevel") - 1;

        for (int i = 0; i < inst.posx.Count; i++)
        {
            if (Mathf.Abs(inst.posx[currentLevel][i]) >= 10)
            {
                GameObject piece = pieces.transform.GetChild(i).gameObject;
                PieceScript pieceScript = piece.GetComponent<PieceScript>();
                inst.posx[currentLevel][i] %= 10;
                inst.posy[currentLevel][i] %= 10;
                inst.rotx[currentLevel][i] %= 10;
                inst.roty[currentLevel][i] %= 10;
                piece.transform.position = new Vector3(inst.posx[currentLevel][i] * 0.2f, 5.1f, inst.posy[currentLevel][i] * 0.2f);
                pieceScript.currentRot = new Vector3(inst.rotx[currentLevel][i] * 180f, inst.roty[currentLevel][i] * 90f, 0f);
                pieceScript.draggable = false;
                hintButton.gameObject.SetActive(false);
                break;
            }
        }
    }
}
