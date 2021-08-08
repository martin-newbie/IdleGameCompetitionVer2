using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteManager : MonoBehaviour
{
    public int NoteAM_G = 0;
    public int NoteAM_D = 0;
    public int NoteAM_E = 0;
    public int NoteAM_A = 0;

    double CurTimeG = 0d;
    double CurTimeD = 0d;
    double CurTimeE = 0d;
    double CurTimeA = 0d;

    [SerializeField]
    Transform NoteSpawnG = null;
    [SerializeField]
    GameObject NoteG = null;

    [SerializeField]
    Transform NoteSpawnD = null;
    [SerializeField]
    GameObject NoteD = null;

    [SerializeField]
    Transform NoteSpawnA = null;
    [SerializeField]
    GameObject NoteA = null;

    [SerializeField]
    Transform NoteSpawnE = null;
    [SerializeField]
    GameObject NoteE = null;

    // Update is called once per frame
    void Update()
    {
        CurTimeG += Time.deltaTime;
        CurTimeD += Time.deltaTime;
        CurTimeA += Time.deltaTime;
        CurTimeE += Time.deltaTime;

        if (CurTimeG >= 60d / NoteAM_G)
        {
            GameObject C_Note = Instantiate(NoteG, NoteSpawnG.position, Quaternion.identity);
            C_Note.transform.SetParent(this.transform);

            CurTimeG -= 60d / NoteAM_G;

        }
        if (CurTimeD >= 60d / NoteAM_D)
        {
            GameObject C_Note = Instantiate(NoteD, NoteSpawnD.position, Quaternion.identity);
            C_Note.transform.SetParent(this.transform);

            CurTimeD -= 60d / NoteAM_D;

        }
        if (CurTimeA >= 60d / NoteAM_A)
        {
            GameObject C_Note = Instantiate(NoteA, NoteSpawnA.position, Quaternion.identity);
            C_Note.transform.SetParent(this.transform);

            CurTimeA -= 60d / NoteAM_A;

        }
        if (CurTimeE >= 60d / NoteAM_E)
        {
            GameObject C_Note = Instantiate(NoteE, NoteSpawnE.position, Quaternion.identity);
            C_Note.transform.SetParent(this.transform);

            CurTimeE -= 60d / NoteAM_E;

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Note"))
        {
            Destroy(collision.gameObject);
        }
    }
}
