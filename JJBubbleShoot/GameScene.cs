﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JJBubbleShoot
{
    public abstract class GameScene : DrawableGameComponent
    {
        private List<GameComponent> components;

        public List<GameComponent> Components
        {
            get
            {
                return components;
            }

            set
            {
                components = value;
            }
        }

        public virtual void show()
        {
            this.Visible = true;
            this.Enabled = true;
        }

        public virtual void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }


        public GameScene(Game game) : base(game)
        {
            components = new List<GameComponent>();
            hide();

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }

            base.Update(gameTime);

        }
        public override void Draw(GameTime gameTime)
        {
            DrawableGameComponent comp = null;
            foreach (GameComponent item in components)
            {
                if (item is DrawableGameComponent)
                {
                    comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }

                }
            }

            base.Draw(gameTime);
        }

    }
}
