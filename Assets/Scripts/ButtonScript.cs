using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{

    private Button myButton;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.name.Contains("LevelButton"))
        {
            level = Convert.ToInt32(gameObject.name.Split('.')[1]);
        }
        else
        {
            level = Convert.ToInt32(gameObject.name);
        }
        

        if (level > Levels.Instance.posx.Count)
        {
            Destroy(this.gameObject);
        }

        FinishedLevelsClass finishedLevelsClass = JsonUtility.FromJson<FinishedLevelsClass>(PlayerPrefs.GetString("levelsFinished", JsonUtility.ToJson(new FinishedLevelsClass(new List<int> { }))));
        List<int> levelsFinished = finishedLevelsClass.levelsFinished;
        myButton = gameObject.GetComponent<Button>();

        gameObject.GetComponentInChildren<TMP_Text>().text = level.ToString();

        myButton.onClick.AddListener(delegate { LoadLevel(); });    // Adds an onclick event, so that "LoadLevel" is called when clicked.

        if (levelsFinished.Contains(level))
        {
            gameObject.GetComponent<Image>().color = new Color(0f, 170f, 255f, 255f);
        }

        if (level == 1)
        {
            StartCoroutine(RemoveBlankScreens());
        }
    }

    private IEnumerator RemoveBlankScreens()
    {
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();
        for (int i = 0; i < transform.parent.parent.parent.parent.childCount; i++)
        {
            GameObject screen = transform.parent.parent.parent.parent.GetChild(i).gameObject;
            if(screen.transform.GetChild(0).GetChild(0).childCount == 0)
            {
                Destroy(screen);

            }
        }

    }

    private void Update()
    {
        // For setting the scroll size of the content so that it doesn't scroll into empty space.
        if (level == 1)
        {
            GameObject content = transform.parent.parent.parent.parent.gameObject;
            RectTransform contentRect = content.GetComponent<RectTransform>();
            contentRect.sizeDelta = new Vector2(800f * content.transform.childCount, contentRect.sizeDelta.y);
            contentRect.ForceUpdateRectTransforms();
        }

    }

    public void LoadLevel()
    {
        PlayerPrefs.SetInt("currentLevel", level);
        PlayerPrefs.Save();
        if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex == 1)    // This means that we are choosing 2D levels
        {

        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("2DMain"); // Or whatever the scene where the 2D gameplay takes place is called.
    }

    [Serializable]
    public class FinishedLevelsClass
    {
        public List<int> levelsFinished;

        public FinishedLevelsClass(List<int> lF)
        {
            levelsFinished = lF;
        }
    }

}
