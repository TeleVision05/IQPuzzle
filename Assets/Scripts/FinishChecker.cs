using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishChecker : MonoBehaviour
{

    [SerializeField]
    GameObject notFinishedText;

    bool isRunning_ShowNotFinishedText;


    // Start is called before the first frame update
    void Start()
    {
        notFinishedText.SetActive(false);
        isRunning_ShowNotFinishedText = false;
        //transform.position = new Vector3(0f, 5.25f, 0f);    // 5.25f is position to check
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void CheckFinish()
    {
        int count = 0;
        for (int x = -5; x < 6; x++)
        {
            for (int z = -2; z < 3; z++)
            {
                transform.position = new Vector3(x * 0.2f, 5.4f, z * 0.2f);
                RaycastHit hit;
                if (Physics.Raycast(new Ray(transform.position, Vector3.down), out hit, 0.2f))
                {
                    if (hit.transform.gameObject.CompareTag("Sphere") || hit.transform.gameObject.CompareTag("Piece"))
                    {
                        count++;
                    }
                }
            }
        }

        if (count == 55)
        {
            // FINISHED
            FinishedLevelsClass finishedLevelsClass = JsonUtility.FromJson<FinishedLevelsClass>(PlayerPrefs.GetString("levelsFinished", JsonUtility.ToJson(new FinishedLevelsClass(new List<int> { }))));
            List<int> levelsFinished = finishedLevelsClass.levelsFinished;

            int currentLevel = PlayerPrefs.GetInt("currentLevel");
            levelsFinished.Add(currentLevel);

            Debug.Log(JsonUtility.ToJson(finishedLevelsClass));

            PlayerPrefs.SetString("levelsFinished", JsonUtility.ToJson(finishedLevelsClass));
            PlayerPrefs.Save();
            UnityEngine.SceneManagement.SceneManager.LoadScene("2DLevels");
        }

        else
        {
            // NOT FINISHED            
            if (!isRunning_ShowNotFinishedText)
            {
                isRunning_ShowNotFinishedText = true;
                StartCoroutine(ShowNotFinishedText(2f));
            }            
        }
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

    IEnumerator ShowNotFinishedText(float duration)
    {
        notFinishedText.SetActive(true);
        yield return new WaitForSecondsRealtime(duration);
        notFinishedText.SetActive(false);
        isRunning_ShowNotFinishedText = false;
    }


}
