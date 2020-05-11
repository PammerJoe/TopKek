using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionProgress : MonoBehaviour
{
    public GameObject missionText;
    public GameObject warningMark;
    public AudioClip missionSound;
    public GameObject mainCam;
    public GameObject manQ1, manQ2, manQ3;
    private int missionNum;
    private Quaternion originalRot;
    private Vector3 originalPos;
    private bool showMission;
    private RectTransform paneltrans;
    private Vector3 newpos;
    private float startTime = 0;
    private float endTime = 2;
    private float normValue;
    private int currentMission;
    private GameObject scasec, scaseo;

    // Start is called before the first frame update
    void Start()
    {
        paneltrans = GetComponent<RectTransform>();
        missionText.SetActive(true);
        changeMission(0);
        originalRot = transform.rotation;
        originalPos = paneltrans.anchoredPosition;
        showMission = false;
        currentMission = 0;
        newpos = new Vector3(-originalPos.x, originalPos.y, originalPos.z);
        manQ1.SetActive(false);
        manQ2.SetActive(false);
        scasec = GameObject.Find("scasec");
        scaseo = GameObject.Find("CaseThings");
        scasec.SetActive(true);
        scaseo.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            paneltrans.anchoredPosition = new Vector3(-originalPos.x, originalPos.y, originalPos.z);

            /*if (!showMission)
            {*/
            //comeOut();
            //paneltrans.anchoredPosition = Vector3.Lerp(newpos, originalPos, 0.5f);
            showMission = true;
            //}
        } else if(Input.GetKeyUp(KeyCode.Tab))
        {
            paneltrans.anchoredPosition = new Vector3(originalPos.x, originalPos.y, originalPos.z);
            /*if (showMission)
            {*/
            //goBack();
            //paneltrans.anchoredPosition = Vector3.Lerp(originalPos, newpos, 0.5f);
            showMission = false;
            //}
        }
    }
    
    public int getCurrentMission()
    {
        return currentMission;
    }

    bool first = true;
    public void changeMission(int _missionNum)
    {
        if (_missionNum != 0) { StartCoroutine(blinkExclamation()); }
        missionNum = _missionNum;
        currentMission = _missionNum;
        if (!first)
        {
            mainCam.GetComponent<AudioSource>().PlayOneShot(missionSound);
        } else
        {
            first = false;
        }
        //if (missionNum != prevNum)
        //{ // Nem fog folyamatosan futni a switch |Mar nem kell
        switch (missionNum)
            {
                case 1: // Portan megtalaljuk a szamokat
                    missionText.GetComponent<Text>().text = "Úgy néz ki valamiféle kódot vár a gép, lehet ez nyitja az ajtót. Vajon hol lehet a kód?\n( Kutasd át a szintet. )";
                
                scasec.SetActive(false);
                scaseo.SetActive(true);
                break;
                case 2: // Megvizsgaljuk a papirt
                    missionText.GetComponent<Text>().text = "Talán ez lesz a kód! Meg kell próbálnom...\n( Használd a kódot a portán. )";
                    break;
                case 3: // Beirjuk a helyes kódot
                    missionText.GetComponent<Text>().text = "Úgy néz ki kinyílt egy ajtó, de nem a bejárati.. De akkor melyik?\n( Keresd meg a termet. )";
                    break;
                case 4: // Be megyünk a terembe
                    missionText.GetComponent<Text>().text = "Micsoda káosz! Nem látom jól, de mintha lenne valami a táblán.\n( Vizsgáld meg a táblát. )";
                    break;
                case 5: // Szamologep helyes kod es = lenyomasa utan
                    missionText.GetComponent<Text>().text = "Ez fura.. az eredmény megadása után mintha hallottam volna az egyik ajtót kinyílni!\n( Keresd meg a kinyílt ajtót. )";
                    break;

            default: // Jatek kezdete
                    missionText.GetComponent<Text>().text = "Valamiért nem nyílik az ajtó, talán a portán ki lehet nyitni?\n( Nyisd ki az ajtót a portán. )";
                    break;
            }
        setActiveManQ(missionNum); // Babu "mozgatas"
        //}
    }

    void setActiveManQ(int num)
    {
        switch (num)
        {
            case 1:
                manQ1.SetActive(true);
                manQ2.SetActive(false);
                manQ3.SetActive(false);
                break;
            case 2:
                manQ1.SetActive(false);
                manQ2.SetActive(true);
                manQ3.SetActive(false);
                break;
            case 3:
                manQ1.SetActive(false);
                manQ2.SetActive(false);
                manQ3.SetActive(true);
                break;
            default:
                manQ1.SetActive(false); ;
                manQ2.SetActive(false);
                manQ3.SetActive(false);
                break;
        }
    }

    IEnumerator blinkExclamation()
    {
        warningMark.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningMark.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        warningMark.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningMark.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        warningMark.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        warningMark.SetActive(false);
    }
}
