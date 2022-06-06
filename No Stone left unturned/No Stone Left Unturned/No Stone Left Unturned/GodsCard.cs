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
    class GodsCard : Card
    {
        readonly int health;
        int currentHealth;
        bool taunt;
        bool disabled;
        bool attackIncreased;
        bool dead;

        public int Health
        {
            get
            {
                return health;
            }
        }

        public int CurrentHealth
        {
            get
            {
                return currentHealth;
            }
            set
            {
                currentHealth = value;
            }
        }

        public bool Taunt
        {
            get { return taunt; }
            set { taunt = value; }
        }

        public bool Disabled
        {
            get { return disabled; }
            set { disabled = value; }
        }
       

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public bool AttackIncreased
        {
            get { return attackIncreased; }
            set { attackIncreased = value; }
        }

        public bool Dead
        {
            get { return dead; }
            set { dead = value; }
        }

        public GodsCard(Texture2D asset, Rectangle position, string name, string skill, int attack,int health,string skillInfo)
                        : base(asset, position, name, skill, attack, skillInfo)
        {
            this.health = health;
            this.currentHealth = health;
            this.attack = attack;
            this.skill = skill;
            this.taunt = false;
            this.disabled = false;
            this.attackIncreased = false;
            this.dead = false;
        }

        public override void Draw(SpriteBatch sb)
        {
                base.Draw(sb);
        }

        //Methods
        public void SingleAttackSkill(GodsCard a)
        {
            a.currentHealth -= this.attack;
            if(a.currentHealth <=0)
            {
                a.currentHealth = 0;
            }
        }

        public void AoeSkill(GodsCard a,GodsCard b,GodsCard c)
        {
            a.currentHealth -= this.attack / 2;
            b.currentHealth -= this.attack / 2;
            c.currentHealth -= this.attack / 2;

            if (a.currentHealth <= 0)
            {
                a.currentHealth = 0;
            }

            if (b.currentHealth <= 0)
            {
                b.currentHealth = 0;
            }

            if (c.currentHealth <= 0)
            {
                c.currentHealth = 0;
            }
        }

        public void SelfDamageAttackSkill(GodsCard a)
        {
            a.currentHealth -= this.attack;
            this.currentHealth -= this.attack/2;

            if (a.currentHealth <= 0)
            {
                a.currentHealth = 0;
            }

            if (this.currentHealth <= 0)
            {
                this.currentHealth = 0;
            }
        }

        public void HealingSkill(GodsCard a)
        {
            a.CurrentHealth += this.Attack/2;
            if (a.CurrentHealth >= a.Health)
            {
                a.CurrentHealth = a.Health;
            }

        }

        public void TauntSkill(GodsCard a, GodsCard b, GodsCard c)
        {
            a.Taunt = true;
            b.Taunt = true;
            c.Taunt = true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a">Main attack</param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void AoeBurnSkill(GodsCard a, GodsCard b, GodsCard c)
        {
            a.currentHealth -= this.attack;
            b.currentHealth -= 5;
            c.currentHealth -= 5;

            if (a.currentHealth <= 0)
            {
                a.currentHealth = 0;
            }

            if (b.currentHealth <= 0)
            {
                b.currentHealth = 0;
            }

            if (c.currentHealth <= 0)
            {
                c.currentHealth = 0;
            }
        }
    }
}
