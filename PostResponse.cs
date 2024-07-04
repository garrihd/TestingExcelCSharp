using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OutLook = Microsoft.Office.Interop.Outlook;


namespace HelperFunctions{

    public class SomeClass
    {
    public static void Main(string[] args)
    {
        // string ?name = Console.ReadLine();
        string ?loc = Console.ReadLine();
        // Console.WriteLine(NickToName(name));
        string ?text = Console.ReadLine();
        Console.WriteLine(ReplaceEmojis(text));

        string _snowUser = "userpad1";
        string _snowPass = ",EGHc?crKju3hz0),n{T)zRDXr5nr80I";
        Dictionary <string, string> _apiHeaders = new Dictionary<string, string>();
        _apiHeaders.Add("x-dxc-inf-user", "Palbot");
        _apiHeaders.Add("Accept-Encoding", "gzip");
        _apiHeaders.Add("x-dxc-inf-route-key", "serviceNow");

    }

    public static string NickToName(string name)
    {
        Dictionary<string, string> namesOfAgents = new Dictionary<string, string>();
        namesOfAgents.Add("Dido", "Deyan Radushev");
        namesOfAgents.Add("Rado", "Radoslav Hubekov");
        namesOfAgents.Add("Ivelina","Ivelina Banalieva");
        namesOfAgents.Add("Mitko G","Dimitar Guenkov");
        namesOfAgents.Add("MG", "Mirela Gyaurova");
        namesOfAgents.Add("Ines", "Ines Hillebrandt");
        namesOfAgents.Add("Jeni", "Evgeniya Stefanova");
        namesOfAgents.Add("Kamen", "Kamen Kirov");
        namesOfAgents.Add("Mihaela", "Michaela Petrova");
        namesOfAgents.Add("Maria", "Maria Petrova");
        namesOfAgents.Add("Svilen", "Svilen Stanev");

        if (namesOfAgents.ContainsKey(name))
        {
            return namesOfAgents[name];
        }
        else{
            return "";
        }
        
    }

    public static string SetCorrectLocation(string location){


        Dictionary<string, string> dictOfLoc = new Dictionary<string, string>();
        
        dictOfLoc.Add("AT-BER", "BE");
        dictOfLoc.Add("AT-BE2", "BE");
        dictOfLoc.Add("AT-ELS", "ELS");
        dictOfLoc.Add("AT-KOD", "KO");
        dictOfLoc.Add("AT-LEN", "LE");
        dictOfLoc.Add("AT-SBG", "KA");
        dictOfLoc.Add("AT-VIE", "VIE");
        dictOfLoc.Add("DE-AIN", "AI");

        if (dictOfLoc.ContainsKey(location)){
            return dictOfLoc[location];
        }

        else{
            return location.Split("-")[0];
        }
    
        
    }

    public static string ReplaceEmojis(string text)
    {
        Regex emojiPattern = new Regex("["
                               + "\U0001F600-\U0001F64F"  // emoticons
                               + "\U0001F300-\U0001F5FF"  // symbols & pictographs
                               + "\U0001F680-\U0001F6FF"  // transport & map symbols
                               + "\U0001F1E0-\U0001F1FF"  // flags (iOS)
                               + "\U00002702-\U000027B0"  // miscellaneous
                               + "\U000024C2-\U0001F251"
                               + "]+", RegexOptions.Compiled);
        return emojiPattern.Replace(text, "");
    }

    }

}