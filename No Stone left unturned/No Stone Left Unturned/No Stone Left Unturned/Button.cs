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
    class Button
    {
        protected Texture2D asset;
        protected Rectangle position;
        protected Color color;
        
        public Button(Texture2D asset, Rectangle position)
        {
            this.asset = asset;
            this.position = position;
            this.color = Color.White;
        }

        public Texture2D Asset
        {
            get
            {
                return this.asset;
            }
            set
            {
                this.asset = value;
            }
        }

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


        public void Draw(SpriteBatch sb)
        {
            sb.Draw(asset, position, color);
        }

    }
}
