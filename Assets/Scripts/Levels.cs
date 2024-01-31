using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public List<List<int>> posx = new List<List<int>>();
    public List<List<int>> posy = new List<List<int>>();
    public List<List<int>> rotx = new List<List<int>>();
    public List<List<int>> roty = new List<List<int>>();
    public List<List<int>> drag = new List<List<int>>();


    public static Levels theInstance = null;


    public static Levels Instance {
        get {
            if (theInstance == null)
            {
                GameObject obj = new GameObject();
                obj.AddComponent<Levels>();
                theInstance = obj.GetComponent<Levels>();
                theInstance.Initialize();
            }
            return theInstance;
        }
        private set { }
    }


    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        posx.Clear();
        posy.Clear();
        rotx.Clear();
        roty.Clear();

        /*
        Template
        posx.Add(new List<int> { 
        posy.Add(new List<int> { 
        rotx.Add(new List<int> { 
        roty.Add(new List<int> { 
        */

        // Ordered in Light Blue, Blue, Violet, Purple, Pink, Mahogany, Red, Orange, Yellow, Green, Sea Green, Teel
        // The number '1' in the 'drag' list indicates whether the object is draggable or not. 1 means draggable. 0 means fixed.
        //1
        posx.Add(new List<int> { -2, -5, 3, 13, -4, -1, 15, 1, -4, 14, -3, 3 });    // Counted in # of columns left or right from middle
        posy.Add(new List<int> { -1, 0, 2, 10, -1, 0, -11, 0, 2, 11, 1, -2 });      // Counted in # of rows up or down from the middle
        rotx.Add(new List<int> { 0, 0, 0, 10, 0, 0, 10, 1, 1, 10, 0, 1 });         // Counted in either 0 or 1, 0 meaning no flip, 1 meaning flip
        roty.Add(new List<int> { 1, 1, 2, 11, 3, 1, 13, 2, 0, 12, 1, 2 });         // Counted in 0, 1, 2, or 3 times rotated 90 degrees clockwise
        
        //2
        posx.Add(new List<int> { 1, 13, -5, -3, -2, -3, 0, 13, -1, 5, 14, -3 });
        posy.Add(new List<int> { -1, -12, 0, 0, 2, 2, -2, -11, 2, 2, -11, -2 });
        rotx.Add(new List<int> { 0, 10, 1, 0, 0, 1, 0, 11, 1, 0, 10, 1 });
        roty.Add(new List<int> { 1, 10, 3, 1, 1, 1, 3, 12, 0, 2, 13, 2 });
        
        //3
        posx.Add(new List<int> { -5, 13, 2, -4, 1, 13, -3, -2, -1, -5, 3, 15 });
        posy.Add(new List<int> { 2, 10, 0, -1, -1, 11, -2, -1, 2, 0, 2, 11 });
        rotx.Add(new List<int> { 0, 10, 1, 0, 0, 10, 0, 0, 0, 0, 0, 11 });
        roty.Add(new List<int> { 1, 11, 1, 0, 3, 10, 0, 0, 2, 1, 2, 11 });
        
        //4
        posx.Add(new List<int> { 1, -5, 15, -4, 13, -1, -5, 3, -1, 0, -3, 13 });
        posy.Add(new List<int> { -2, 1, 12, 0, -11, -2, -2, 2, 2, 2, 2, -12 });
        rotx.Add(new List<int> { 0, 0, 11, 0, 11, 0, 0, 0, 1, 0, 0, 10 });
        roty.Add(new List<int> { 0, 1, 11, 0, 13, 0, 0, 2, 1, 1, 2, 10 });
        
        //5
        posx.Add(new List<int> { 5, 5, -12, -15, 0, -5, 1, 4, 2, 4, -15, -3 });
        posy.Add(new List<int> { -2, 0, 10, -12, 2, 2, -1, -2, -2, 1, 11, 2 });
        rotx.Add(new List<int> { 0, 0, 11, 10, 1, 1, 1, 1, 1, 0, 10, 1 });
        roty.Add(new List<int> { 3, 3, 11, 10, 1, 0, 3, 2, 2, 2, 11, 0 });
        
        //6
        posx.Add(new List<int> { -11, 0, 1, 4, -11, 4, -12, 4, -1, -5, 5, 2 });
        posy.Add(new List<int> { -12, 0, 0, 2, 10, 0, -12, -2, 1, 2, 0, -2 });
        rotx.Add(new List<int> { 10, 0, 1, 0, 10, 0, 11, 1, 1, 0, 0, 1 });
        roty.Add(new List<int> { 13, 3, 3, 2, 12, 1, 12, 2, 2, 1, 3, 2 });
        
        //7
        posx.Add(new List<int> { 2, 5, 0, 5, 4, -12, 4, 1, -12, -13, -1, -3 });
        posy.Add(new List<int> { 0, 0, -2, -2, 1, 10, -2, 0, -12, 10, 2, 1 });
        rotx.Add(new List<int> { 0, 0, 0, 0, 1, 10, 1, 0, 11, 10, 0, 1 });
        roty.Add(new List<int> { 1, 3, 3, 3, 2, 11, 2, 3, 12, 12, 2, 2 });

        //8
        posx.Add(new List<int> { -13, 3, 0, 2, -1, 3, 5, -15, -12, -3, 5, -1 });
        posy.Add(new List<int> { -11, 2, 0, 1, -1, 1, -2, -11, -12, 2, -1, -2 });
        rotx.Add(new List<int> { 10, 0, 0, 0, 0, 0, 1, 11, 11, 0, 0, 0 });
        roty.Add(new List<int> { 10, 2, 3, 1, 3, 0, 2, 13, 12, 2, 3, 0 });
        
        //9
        posx.Add(new List<int> { -2, -3, 0, -3, -4, 1, 12, 13, -1, 13, 1, 11 });
        posy.Add(new List<int> { 2, 2, -2, 1, 1, 1, 12, 11, -2, -12, 2, 10 });
        rotx.Add(new List<int> { 0, 0, 0, 0, 1, 1, 11, 11, 1, 10, 0, 10 });
        roty.Add(new List<int> { 1, 2, 3, 1, 1, 0, 10, 10, 2, 10, 2, 11 });
        
        //10
        posx.Add(new List<int> { 0, 13, 0, 12, -3, 1, -2, -2, -5, 13, -5, 14 });
        posy.Add(new List<int> { 2, -12, -2, 11, -1, -1, -1, -2, 2, 12, -2, 10 });
        rotx.Add(new List<int> { 0, 10, 0, 10, 0, 0, 0, 0, 0, 10, 0, 11 });
        roty.Add(new List<int> { 2, 10, 0, 11, 3, 3, 3, 0, 1, 12, 0, 13 });
        
        //11
        posx.Add(new List<int> { 0, 15, -1, 1, 14, 0, -2, -5, -2, -5, 12, 12 });
        posy.Add(new List<int> { -2, 10, 0, 0, 11, 1, -2, 1, 2, -2, -12, -11 });
        rotx.Add(new List<int> { 0, 10, 1, 0, 10, 0, 0, 0, 0, 0, 10, 11 });
        roty.Add(new List<int> { 0, 13, 3, 2, 11, 0, 3, 1, 2, 0, 10, 13 });
        
        //12
        posx.Add(new List<int> { 1, 0, 3, -11, 2, 5, -11, 10, -15, 3, 3, -5 });
        posy.Add(new List<int> { -1, 0, 2, 11, 1, 1, -12, -12, -12, -2, 0, 2 });
        rotx.Add(new List<int> { 0, 0, 0, 10, 0, 1, 11, 10, 11, 0, 0, 1 });
        roty.Add(new List<int> { 1, 3, 2, 12, 0, 1, 12, 13, 13, 0, 2, 0 });
        
        //13
        posx.Add(new List<int> { -1, 11, 12, 13, -5, -4, -5, -2, 15, -5, 1, 2 });
        posy.Add(new List<int> { -2, 10, -11, 10, -1, 1, -2, 1, 12, 2, 2, 2 });
        rotx.Add(new List<int> { 0, 10, 10, 10, 0, 0, 0, 1, 11, 0, 0, 1 });
        roty.Add(new List<int> { 0, 11, 13, 11, 0, 0, 0, 0, 11, 1, 2, 0 });
        
        //14
        posx.Add(new List<int> { -5, 2, 12, -4, 15, -2, 15, 2, 11, -1, -3, -5 });
        posy.Add(new List<int> { -1, 2, 10, 0, -12, -1, -11, -2, 11, 0, 2, 0 });
        rotx.Add(new List<int> { 0, 0, 11, 0, 11, 1, 10, 1, 10, 0, 0, 1 });
        roty.Add(new List<int> { 1, 2, 10, 1, 12, 0, 13, 2, 10, 3, 1, 3 });
        
        //15
        posx.Add(new List<int> { 1, -5, 15, 14, 1, 13, -5, -5, -1, -2, -1, 13 });
        posy.Add(new List<int> { 2, 1, 10, 10, 1, -11, -2, 2, 2, 0, -2, -12 });
        rotx.Add(new List<int> { 0, 0, 10, 10, 0, 10, 0, 1, 0, 0, 0, 10 });
        roty.Add(new List<int> { 2, 1, 13, 13, 1, 13, 0, 0, 1, 3, 0, 10 });
        
        //16
        posx.Add(new List<int> { -1, -5, 1, -2, -4, 12, -3, 12, -2, 15, 2, 13 });
        posy.Add(new List<int> { 2, 0, 0, -2, -1, -12, -1, 10, 2, 10, 2, -12 });
        rotx.Add(new List<int> { 0, 0, 1, 0, 0, 11, 0, 11, 0, 10, 0, 10 });
        roty.Add(new List<int> { 1, 1, 1, 0, 3, 13, 3, 13, 1, 13, 2, 10 });
        
        //17
        posx.Add(new List<int> { 10, -11, 1, -5, -3, -5, -2, 15, 15, 2, -5, 14 });
        posy.Add(new List<int> { 10, 10, 0, -2, 2, 2, 1, 12, 11, 2, 1, -12 });
        rotx.Add(new List<int> { 10, 10, 0, 0, 1, 1, 1, 10, 11, 0, 0, 11 });
        roty.Add(new List<int> { 11, 11, 3, 0, 0, 0, 1, 12, 11, 1, 1, 12 });
        
        //18
        posx.Add(new List<int> { 14, -5, 11, -3, -4, 13, 5, 11, 0, 12, -2, -3 });
        posy.Add(new List<int> { 10, 0, 10, 0, -1, -11, -1, 11, 2, 10, 2, -1 });
        rotx.Add(new List<int> { 10, 0, 11, 0, 0, 11, 0, 10, 1, 10, 0, 1 });
        roty.Add(new List<int> { 13, 1, 11, 0, 3, 10, 3, 12, 0, 11, 2, 0 });
        
        //19
        posx.Add(new List<int> { 10, 3, 1, 4, 4, 2, -12, -13, 10, -3, 10, -2 });
        posy.Add(new List<int> { -12, -2, 0, 2, -1, -2, -12, -11, 10, 2, -11, 2 });
        rotx.Add(new List<int> { 10, 0, 1, 0, 1, 1, 11, 11, 11, 0, 10, 1 });
        roty.Add(new List<int> { 10, 0, 3, 2, 3, 3, 12, 12, 12, 2, 12, 0 });
        
        //20
        posx.Add(new List<int> { 4, 2, -11, 11, -13, 2, -12, -14, -4, 5, -5, 3 });
        posy.Add(new List<int> { 1, 0, 11, -12, -11, -2, -12, -11, 2, 2, 2, -2 });
        rotx.Add(new List<int> { 0, 0, 11, 10, 11, 1, 11, 11, 1, 0, 0, 0 });
        roty.Add(new List<int> { 1, 3, 10, 13, 10, 3, 12, 13, 0, 2, 1, 0 });

        //21
        posx.Add(new List<int> { -2, 13, 10, -4, 1, 14, -11, -11, -5, 1, -5, 14 });
        posy.Add(new List<int> { 1, -12, 11, 2, 0, 10, -12, 10, 2, 2, -2, 12 });
        rotx.Add(new List<int> { 0, 10, 10, 0, 1, 11, 10, 11, 0, 0, 0, 10 });
        roty.Add(new List<int> { 3, 10, 11, 1, 0, 13, 10, 11, 1, 2, 0, 12 });

        //22
        posx.Add(new List<int> { -3, 15, 15, -1, 10, -4, -1, 15, 10, -5, 11, -3 });
        posy.Add(new List<int> { -2, 12, -11, 0, 11, 1, 2, -12, -12, 2, 11, -1 });
        rotx.Add(new List<int> { 0, 10, 10, 0, 11, 1, 1, 11, 10, 0, 10, 0 });
        roty.Add(new List<int> { 0, 12, 13, 3, 11, 0, 0, 12, 10, 1, 11, 2 });

        //23
        posx.Add(new List<int> { 0, -3, -13, 11, -14, 1, -11, 11, 2, 3, -3, 13 });
        posy.Add(new List<int> { 1, 2, -12, 10, -11, 2, 10, -12, 2, 0, 1, -11 });
        rotx.Add(new List<int> { 0, 0, 11, 10, 11, 0, 11, 11, 1, 0, 0, 11 });
        roty.Add(new List<int> { 3, 2, 12, 11, 10, 1, 12, 12, 0, 0, 0, 10 });

        //24
        posx.Add(new List<int> { 14, -5, -2, 12, -1, -5, -12, -2, 1, 15, 11, 11 });
        posy.Add(new List<int> { 11, 0, 2, 11, 1, 2, 10, -2, 2, -12, -12, -11 });
        rotx.Add(new List<int> { 10, 0, 1, 10, 1, 0, 10, 0, 1, 10, 10, 10 });
        roty.Add(new List<int> { 10, 1, 0, 11, 2, 1, 10, 3, 0, 13, 10, 12 });

    }
}
