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
    class SpellCard : Card
    {
        //Fields
        readonly int value;
        bool disabled;

        //Properties
        public int Value
        {
            get { return value; }
        }

        public bool Disabled
        {
            get { return disabled; }
            set { this.disabled = value; }
        }

        public SpellCard(Texture2D asset, Rectangle position, string name, string skill, int value, string skillInfo)
                        : base(asset, position, name, skill, value, skillInfo)
        {
            this.value = value;
            this.disabled = false;
        }

        public override void Draw(SpriteBatch sb)
        {
            base.Draw(sb);
        }

        //Methods

        public void Heal(GodsCard g)
        {
            g.CurrentHealth += Value;
            if (g.CurrentHealth >= g.Health)
            {
                g.CurrentHealth = g.Health;
            }
        }

        public void Refresh(GodsCard g)
        {
            g.Disabled = false;
        }

        public void IncreaseAttack(GodsCard g)
        {
            g.Attack *= Value;
            g.AttackIncreased = true;
        }
    }
}
