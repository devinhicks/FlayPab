using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    public Transform spawnPoint;
    public Transform slabs;
    public List<GameObject> slabList;
    public GameObject slabPrefab;

    public float timer = 10;
    public float waitTime;

    private int slabCount;

    private bool isPlaying;

    public GameObject playButton;
    public TextMeshProUGUI curTimeText;

    public void Start()
    {
        slabList = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPlaying)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject s = GameObject.Instantiate(slabPrefab, spawnPoint);
            s.transform.parent = slabs;
            slabList.Add(s);

            spawnPoint.transform.position += new Vector3(0, .2f, 0);
        }

        timer -= Time.deltaTime;
        curTimeText.text = (timer).ToString("F2");

        if (timer <= 0)
            StartCoroutine(End());
    }

    public void Begin()
    {
        isPlaying = true;

        playButton.SetActive(false);
    }

    public IEnumerator End()
    {
        isPlaying = false;
        yield return new WaitForSeconds(waitTime);

        slabCount = StackCounter.count;

        playButton.SetActive(true);

        Leaderboard.instance.SetLeaderboardEntry(-slabCount * 1000);
        Leaderboard.instance.DisplayLeaderboard();

        yield return null;
    }
}
