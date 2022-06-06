using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace No_Stone_Left_Unturned
{
    class CardCreation
    {
        string nameData;
        string skillData;
        int attackData;
        int healthData;
        string godReplaceWith;
        string godAsset;

        readonly List<string> lineList = new List<string>();

        public string NameData
        {
            get { return nameData; }
        }
        public string SkillData
        {
            get { return skillData; }
        }
        public int AttackData
        {
            get { return attackData; }
        }
        public int HealthData
        {
            get { return healthData; }
        }
        public string GodReplaceWith
        {
            get { return godReplaceWith; }
        }
        public string GodAsset
        {
            get { return godAsset; }
        }

        public void DataReader()
        {
            if(File.Exists("CardData.txt"))
            {
                StreamReader reader = new StreamReader("CardData.txt");
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lineList.Add(line); // Add to list.
                }
                reader.Close();

                nameData = lineList[0];

                string[] str = lineList[1].Split('-');
                skillData = str[0].Trim();

                int.TryParse(lineList[2], out attackData);
                int.TryParse(lineList[3], out healthData);

                godReplaceWith = lineList[4];
                godAsset = lineList[5];
            }
        }
    }
}
