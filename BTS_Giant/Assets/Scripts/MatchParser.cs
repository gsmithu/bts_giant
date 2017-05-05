//using System.Collections;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Xml;
//using System;

//public class MatchParser {

//    // Parse the formations for both teams out of the xml
//    public List<int> ParseFormation () {
//        XmlDocument xml = new XmlDocument();
//        xml.Load("http://optasports.com/media/939044/f24-Version.xml");

//        XmlNode games = xml.SelectSingleNode("Games");
//        XmlNode game = games.SelectSingleNode("Game");
//        XmlNodeList events = game.SelectNodes("Event");

//        List<int> formations = new List<int>();
//        foreach (XmlNode e in events)
//        {
//            XmlNodeList qualifications = e.SelectNodes("Q");
//            foreach (XmlNode q in qualifications)
//            {
//                if (q.Attributes["qualifier_id"].Value == "130") { //130 is the formation qualification
//                    int formation = Int32.Parse(q.Attributes["value"].Value);
//                    formations.Add(formation);
//                }
//            }
//        }

//        return formations;
//    }
//}
