using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using Newtonsoft.Json;
public static class APIHelper
{

// method for fetching healthgov.data 
    public static DataModel GetNewData()
    {

        HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://healthdata.gov/resource/8bce-qw8w.json?state=National");
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream()); 
        string json = reader.ReadToEnd();
        var list_= JsonConvert.DeserializeObject<List<DataModel>>(json);
        return list_[0];

    }

}


//create data model for the healthdata.gov response
[System.Serializable]
public class DataModel
{
    public string state;
    public string medical_neglect_only;
    public string neglect_only;
    public string other_only;
    public string physical_abuse_only;

    public string psychological_maltreatment;

    public string sexual_abuse_only;

    public string sex_trafficking_only;

    public string unknown_only;

    public string multiple_maltreatment_types;

    public string total_victims;

    public string medical_neglect_only_percent;
    public string neglect_only_percent;

    public string other_only_percent;

    public string physical_abuse_only_percent;

    public string psychological_maltreatment_1;

    public string sexual_abuse_only_percent;

    public string sex_trafficking_only_percent;

    public string unknown_only_percent;

    public string multiple_maltreatment_types_1;

    public string total_victims_percent;

}

[System.Serializable]

public class DataList{
    public DataModel[] list;
}
