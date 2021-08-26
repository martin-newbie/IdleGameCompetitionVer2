using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Note_Manager : MonoBehaviour
{
    public int bpm = 0;
    public int type;
    public int type2;
    double curTime = 0d;
    public List<Spawn> spawn_list;

    public bool SongEnd = false;
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
            if(!SongEnd)
            {
                if (curTime >= 100d / spawn_list[spawnIndex].bpm)
                {
                    if (spawn_list[spawnIndex].type2 != 4)
                    {
                        GameObject Note2 = Instantiate(Notes[spawn_list[spawnIndex].type2], NoteSpawnPoints[spawn_list[spawnIndex].type2].position, Quaternion.identity);
                        gameManager.NoteList.Add(Note2);
                    }

                    GameObject Note = Instantiate(Notes[spawn_list[spawnIndex].type], NoteSpawnPoints[spawn_list[spawnIndex].type].position, Quaternion.identity);
                    gameManager.NoteList.Add(Note);
                    spawnIndex++;
                    if (spawnIndex == spawn_list.Count)
                    {
                        SpawnEnd = true;
                        SongEnd = true;
                        return;
                    }
                    curTime -= 100d / spawn_list[spawnIndex].bpm;
                }
            }    
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Note"))
        {
            gameManager.combo = 0;
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
            spawnData.type2 = int.Parse(line.Split(',')[2]);

            spawn_list.Add(spawnData);
        }
        Reader.Close();

        bpm = spawn_list[0].bpm;
    }

}
