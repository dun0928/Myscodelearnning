using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeBar : MonoBehaviour
{
    TextMeshProUGUI dateTime_Time;
    TextMeshProUGUI dateTime_Date;
    TextMeshProUGUI dateTime_Week;
    // Start is called before the first frame update
    void Start() {
        for (int i = 0; i < transform.childCount; i++) {
            Transform child = transform.GetChild(i);
            switch (child.tag) {
                case "DateTime_Time":
                    dateTime_Time = child.gameObject.GetComponent<TextMeshProUGUI>();
                    break;
                case "DateTime_Date":
                    dateTime_Date = child.gameObject.GetComponent<TextMeshProUGUI>();
                    break;
                case "DateTime_Week":
                    dateTime_Week = child.gameObject.GetComponent<TextMeshProUGUI>();
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update() {
        updateDateTime();
    }
    static string[] weeks = {"日", "一", "二", "三", "四", "五", "六"};

    void updateDateTime() {
        dateTime_Time.text =
            System.DateTime.Now.Hour.ToString("00") + ":" +
            System.DateTime.Now.Minute.ToString("00") + ":" +
            System.DateTime.Now.Second.ToString("00");
        dateTime_Week.text = "星期" + weeks[(int)System.DateTime.Now.DayOfWeek];
        dateTime_Date.text = 
            System.DateTime.Now.Year.ToString("00") + "/" +
            System.DateTime.Now.Month.ToString("00") + "/" +
            System.DateTime.Now.Day.ToString("00");
    }
}
