using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Carbolibrary;
using System.IO;
using System.Xml;

namespace Carbolibrary
{

	public class SaveLoad
	{
		static protected List<string> xmlFile = new List<string>();
		//static protected string location = @"..\..\AppData\SampleData.xml";

		static public List<Group> LoadData(string url)
		{
			List<Group> groups = new List<Group>();

			if (!File.Exists(url))
				throw new FileNotFoundException("Where in the world is that location!!");

			Group currentGroup = null;
			Meeting currentMeeting = null;
			Post currentPost = null;

			XmlReader reader = XmlReader.Create(url);
			string currentNode = "";

			while (reader.Read())
			{
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						currentNode = reader.Name;

						switch (reader.Name)
						{
							case "group":
								currentGroup = new Group(reader.GetAttribute("name"));
								groups.Add(currentGroup);
								break;

							case "user":
								currentGroup.AddUser(new User(reader.GetAttribute("name"), reader.GetAttribute("origin")));
								break;

							case "meeting":
								currentMeeting = currentGroup.AddMeeting(reader.GetAttribute("name"), "", currentGroup.Users, null);
								break;

							case "post":
								currentPost = currentMeeting.AddPost(reader.GetAttribute("name"), "", currentGroup.Users, null);

								if (reader.GetAttribute("date") != null)
								{
									string dateString = reader.GetAttribute("date");
									string[] dateData = dateString.Split(dateString.IndexOf('-') >= 0 ? '-' : '/');

									int year, month, date;

									if ((year = int.Parse(dateData[0])) > 12)
									{
										if (year < 100)
											year = 2000 + year;

										month = int.Parse(dateData[1]);
										date = int.Parse(dateData[2]);
									}
									else
									{
										month = int.Parse(dateData[0]);
										date = int.Parse(dateData[1]);

										if ((year = int.Parse(dateData[2])) < 100)
											year = 2000 + year;
									}

									currentPost.Date = new DateTime(year, month, date);
								}

								break;
						}

						break;

					case XmlNodeType.Text:
						string text = FormatXMLText(reader.Value, "load");

						switch (currentNode)
						{
							case "group":
								currentGroup.Description = text;
								break;

							case "meeting":
								currentMeeting.Description = text;
								break;

							case "post":
								currentPost.Content = text;
								break;
						}

						break;
				}
			}

			//tra.ce(groups[0]);

			reader.Close();

			return groups;
		}

		//static public bool CheckLoadData(string location)
		//{
		//    List<Group> tempGroups = new List<Group>();

		//    if (!File.Exists(location))
		//    {
		//        return false;
		//    }

		//    Group currentGroup = null;
		//    Meeting currentMeeting = null;
		//    Post currentPost = null;

		//    XmlReader reader = XmlReader.Create(location);
		//    string currentNode = "";

		//    try
		//    {

		//        while (reader.Read())
		//        {
		//            switch (reader.NodeType)
		//            {
		//                case XmlNodeType.Element:
		//                    currentNode = reader.Name;

		//                    switch (reader.Name)
		//                    {
		//                        case "group":
		//                            currentGroup = new Group(reader.GetAttribute("name"));
		//                            tempGroups.Add(currentGroup);
		//                            break;

		//                        case "user":
		//                            currentGroup.AddUser(new User(reader.GetAttribute("name"), reader.GetAttribute("origin")));
		//                            break;

		//                        case "meeting":
		//                            currentMeeting = currentGroup.AddMeeting(reader.GetAttribute("name"), "", currentGroup.Users, null);
		//                            break;

		//                        case "post":
		//                            currentPost = currentMeeting.AddPost(reader.GetAttribute("name"), "", currentGroup.Users, null);

		//                            if (reader.GetAttribute("date") != null)
		//                            {
		//                                string[] date = reader.GetAttribute("date").Split('/');
		//                                currentPost.Date = new DateTime(
		//                                    int.Parse(date[2]),
		//                                    int.Parse(date[0]),
		//                                    int.Parse(date[1])
		//                                //ran.dom(23),
		//                                //ran.dom(59),
		//                                //ran.dom(59)
		//                                );
		//                            }

		//                            break;
		//                    }

		//                    break;

		//                case XmlNodeType.Text:
		//                    string text = FormatXMLText(reader.Value);

		//                    switch (currentNode)
		//                    {
		//                        case "group":
		//                            currentGroup.Description = text;
		//                            break;

		//                        case "meeting":
		//                            currentMeeting.Description = text;
		//                            break;

		//                        case "post":
		//                            currentPost.Content = text;
		//                            break;
		//                    }

		//                    break;
		//            }
		//        }

		//    }
		//    catch (XmlException e)
		//    {
		//        //throw e;
		//        return false;
		//    }

		//    reader.Close();

		//    return true;
		//}

		static protected string FormatXMLText(string text, string mode)
		{
			// when loading, we need to replace \n's with Environment.NewLines,
			// when saving, replace Environment.Newlines with \n's

			if (mode == "load")
				text = text.Substring(1).Replace("\t", "").Replace("\b", "").Replace("\n", n.l);
			else if (mode == "save")
				text = text.Replace("\t", "").Replace("\b", "").Replace(n.l, "\n");

			// remove annoying empty char at the end of the string

			//tra.ce(mode, text, (int)text[text.Length - 1]); // aha it's char code of 13!!

			if (text[text.Length - 1] == '\b' 
				|| text[text.Length - 1] == '\n' 
				|| text[text.Length - 1] == 13) // bingo!
				return text.Substring(0, text.Length - 1);

			return text;
		}

		static public void SaveData(List<Group> groups, string url)
		{
			AddXMLText($"<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
			AddXMLText($"<data>");

			foreach (Group g in groups) // 1
			{
				AddXMLText($"<group name=\"{g.Name}\">", 1);
				AddXMLText(FormatXMLText(g.Description, "save"), 2);
				foreach (User u in g.Users) // 2
				{
					AddXMLText($"<user name=\"{u.Name}\" origin=\"{u.Origin}\"/>", 1);
				}
				foreach (Meeting m in g.Meetings) // 2
				{
					AddXMLText($"<meeting name=\"{m.Name}\">", 2);
					AddXMLText(FormatXMLText(m.Description, "save"), 3);
					foreach (Post p in m.Posts) // 3
					{
						AddXMLText($"<post name=\"{p.Title}\" date=\"{p.Date.Year.ToString()}-{p.Date.Month.ToString()}-{p.Date.Day.ToString()}\">", 3);
						AddXMLText(FormatXMLText(p.Content, "save"), 4);
						AddXMLText("</post>", 3);
					}

					AddXMLText("</meeting>", 2);
				}
				AddXMLText("</group>", 1);
			}

			AddXMLText("</data>");

			File.WriteAllText(url, ""); // delete previous records
			File.WriteAllLines(url, xmlFile);

			xmlFile.Clear();
		}

		static protected void AddXMLText(string toAdd, int tabs = 0)
		{
			string tabString = "".PadRight(tabs, '\t');

			xmlFile.Add(tabString + toAdd.Replace("\n", "\n" + tabString));
		}

	}

}
