using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace No_Stone_Left_Unturned
{
    abstract class Card
    {
        protected string name;
        protected int attack;
        protected string skill;
        protected bool clicked;
        protected Texture2D asset; 
        protected Rectangle position;
        protected Color color;
        string skillInfo;

        public Rectangle Position 
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        public string SkillInfo
        {
            get { return skillInfo; }
        }

        public Color Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public bool Clicked
        {
            get
            {
                return this.clicked;
            }
            set
            {
                this.clicked = value;
            }
        }

        public string Name
        {
            get { return name; }
        }
        public string Skill
        {
            get { return skill; }
        }
        public Texture2D Asset
        {
            get
            {
                return asset;
            }
        }


        protected Card(Texture2D asset, Rectangle position, string name, string skill, int attack, string skillInfo) //constructor
        {
            this.asset = asset;
            this.position = position;
            this.name = name;
            this.skill = skill;
            this.attack = attack;
            this.color = Color.White;
            this.clicked = false;
            this.skillInfo = skillInfo;
        }

        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(asset, position, color);
        }

    }
}
