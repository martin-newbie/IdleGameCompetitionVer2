using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Note_Manager : MonoBehaviour
{
    public int bpm = 0;
    public int type;
    double curTime = 0d;
    public List<Spawn> spawn_list;

    public bool SpawnEnd;
    public int spawnIndex;

    [SerializeField] Transform[] NoteSpawnPoints;
    [SerializeField] GameObject[] Notes;

    SelectMusic selectMusic;
    FNK_GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<FNK_GameManager>();
        selectMusic = FindObjectOfType<SelectMusic>();
        ReadSpawnFile();
    }

    void Awake()
    {
        spawn_list = new List<Spawn>();
    }

    void Update()
    {
        curTime += Time.deltaTime;

        if (!SpawnEnd)
        {
            if (curTime >= 60d / spawn_list[spawnIndex].bpm)
            {
                GameObject Note = Instantiate(Notes[spawn_list[spawnIndex].type], NoteSpawnPoints[spawn_list[spawnIndex].type].position, Quaternion.identity);
                gameManager.NoteList.Add(Note);
                spawnIndex++;
                if (spawnIndex == spawn_list.Count)
                {
                    SpawnEnd = true;
                    return;
                }
                curTime -= 60d / spawn_list[spawnIndex].bpm;
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            gameManager.combo = 0;
            gameManager.Hit.text = "Miss";
            gameManager.hp -= 10;
            gameManager.NoteList.Remove(col.gameObject);
            Destroy(col.gameObject);
        }
    }

    void ReadSpawnFile()
    {
        spawn_list.Clear();
        spawnIndex = 0;
        SpawnEnd = false;

        string Music = "";

        switch (selectMusic.Music)
        {
            case 0:
                Music = "GoRock";
                break;
            case 1:
                Music = "TheHunter";
                break;
            case 2:
                Music = "Cantina";
                break;
        }

        TextAsset textFile = Resources.Load(Music) as TextAsset;
        StringReader Reader = new StringReader(textFile.text);

        while (Reader != null)
        {
            string line = Reader.ReadLine();
            Debug.Log(line);

            if (line == null)
                break;

            Spawn spawnData = new Spawn();
            spawnData.bpm = int.Parse(line.Split(',')[0]);
            spawnData.type = int.Parse(line.Split(',')[1]);

            spawn_list.Add(spawnData);
        }
        Reader.Close();

        bpm = spawn_list[0].bpm;
    }

}
