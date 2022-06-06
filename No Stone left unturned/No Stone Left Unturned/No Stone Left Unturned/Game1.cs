using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace No_Stone_Left_Unturned
{
    enum GameState
    {
        MainMenu,
        Tutorial,
        Options,
        SpellPhase,
        AttackPhase,
        GameOver
    }


    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GameState currentGameState;
        GameState previousGameState;

        //State of mouse input
        MouseState previousMouseState;
        MouseState currentMouseState;

        //Cursur position
        Rectangle cursur;
        Rectangle infoBoxPosition;

        Texture2D playerOneWin;
        Texture2D playerTwoWin;
        Texture2D gameOver;
        Texture2D title;
        Texture2D tutorialPic;
        Texture2D backGroundPic;

        //Game testing use only texture
        Texture2D white;

        //Height and Width of the window
        int height;
        int width;

        //List of gods
        readonly List<GodsCard> godsListP1 = new List<GodsCard>();
        readonly List<GodsCard> godsListP2 = new List<GodsCard>();

        //List of spells
        readonly List<SpellCard> spellListP1 = new List<SpellCard>();
        readonly List<SpellCard> spellListP2 = new List<SpellCard>();

        //List of button
        readonly Dictionary<string, Button> bttnDict = new Dictionary<string, Button>();

        //store the god who is using his skill
        GodsCard attackGodSave;

        //store the god who is attack by the attack god
        GodsCard targetGodSave;

        //store the spell that player want to cast
        SpellCard selectedSpellSave;

        //store the state of spell casted or not
        bool spellCasted = false;

        //Check if healing skill started or not
        bool healStart = false;

        //Check if is player 1's turn or player 2's turn
        bool player1Turn = true;

        //Default font of the game
        SpriteFont font;

        //mouse click sound effects
        SoundEffect clickSFX;

        readonly GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            //Set default window size
            graphics = new GraphicsDeviceManager(this)
            {
                PreferredBackBufferWidth = 1980,
                PreferredBackBufferHeight = 1080,
                IsFullScreen = false
            };
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //Set width and height to the size of the window
            width = graphics.GraphicsDevice.Viewport.Width;
            height = graphics.GraphicsDevice.Viewport.Height;

            //Set position of the cursur to the position of the mouse
            cursur = new Rectangle(currentMouseState.X, currentMouseState.Y, 10, 10);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //Load the default font, texture, bgm and sound effects
            white = Content.Load<Texture2D>("white");
            font = Content.Load<SpriteFont>("Font/font");
            clickSFX = Content.Load<SoundEffect>("SFX/MouseClick");

            //Setup gods for Player 1
            godsListP1.Add(new GodsCard(Content.Load<Texture2D>("GodsAsset/Poseidon_Piskel"), new Rectangle((width / 2 - width / 4) - 200, ((height * 3) / 8) - 250, 200, 200), "Poseidon", "Water", 20, 120, "Deal 20 damage to \nall opponents"));
            godsListP1.Add(new GodsCard(Content.Load<Texture2D>("GodsAsset/Hades_Piskel"), new Rectangle((width / 2 - width / 4) - 200, ((height * 3) / 8), 200, 200), "Hades", "Burn", 20, 120, "Deal 20 damage to target \nand 5 to the others"));
            godsListP1.Add(new GodsCard(Content.Load<Texture2D>("GodsAsset/Athena_Piskel"), new Rectangle((width / 2 - width / 4) - 200, ((height * 3) / 8) + 250, 200, 200), "Athena", "Taunt", 10, 200, "Deal 10 damage to target \nand taunt all opponenets"));

            //Setup gods for Player 2
            godsListP2.Add(new GodsCard(Content.Load<Texture2D>("GodsAsset/Tyr_Piskel"), new Rectangle((width / 2 + width / 4), ((height * 3) / 8) - 250, 200, 200), "Tyr", "SelfDamage", 40, 120,"Deal 40 damage to target \nand 20 damage to himself"));
            godsListP2.Add(new GodsCard(Content.Load<Texture2D>("GodsAsset/Thor_Piskel"), new Rectangle((width / 2 + width / 4), ((height * 3) / 8), 200, 200), "Thor", "Lightning", 30, 80,"Deal 30 damage to target"));
            godsListP2.Add(new GodsCard(Content.Load<Texture2D>("GodsAsset/Freya_Piskel"), new Rectangle((width / 2 + width / 4), ((height * 3) / 8) + 250, 200, 200), "Freya", "Heal", 20, 120, "Deal 20 damage to target \nand heal target ally by 10"));

            //Setup spells for Player 1
            spellListP1.Add(new SpellCard(Content.Load<Texture2D>("SpellAsset/HealCard"), new Rectangle((width / 4) - 410, height - 150, 200, 200), "Kiss of life", "Heal", 10, "Heal a god for 10HP"));
            spellListP1.Add(new SpellCard(Content.Load<Texture2D>("SpellAsset/RefreshCard"), new Rectangle((width / 4) - 200, height - 150, 200, 200), "Im bored", "Refresh", 0, "Remove the cooldown \nfor a god"));
            spellListP1.Add(new SpellCard(Content.Load<Texture2D>("SpellAsset/PunchCard"), new Rectangle((width / 4) + 10, height - 150, 200, 200), "Dumbells", "Increase strength", 2, "Double the attack"));

            //Setup spells for Player 2
            spellListP2.Add(new SpellCard(Content.Load<Texture2D>("SpellAsset/HealCard"), new Rectangle((width / 2) + (width / 4) - 210, height - 150, 200, 200), "Fountain of youth", "Heal", 10, "Heal a god for 10HP"));
            spellListP2.Add(new SpellCard(Content.Load<Texture2D>("SpellAsset/RefreshCard"), new Rectangle((width / 2) + (width / 4), height - 150, 200, 200), "Fight me", "Refresh", 0, "Remove the cooldown \nfor a god"));
            spellListP2.Add(new SpellCard(Content.Load<Texture2D>("SpellAsset/PunchCard"), new Rectangle((width / 2) + (width / 4) + 210, height - 150, 200, 200), "Determination", "Increase strength", 2, "Double the attack"));

            infoBoxPosition = new Rectangle((width / 2) - 200, height - 200, 400, 200);

            //Setup all the buttons
            bttnDict.Add("startBttn", new Button(Content.Load<Texture2D>("UIAsset/Start Button"), new Rectangle((width / 2) - 160, 400, 320, 140)));
            bttnDict.Add("optionsBttn", new Button(Content.Load<Texture2D>("UIAsset/Options Button"), new Rectangle((width / 2) - 160, 600, 320, 140)));
            bttnDict.Add("tutorialBttn", new Button(Content.Load<Texture2D>("UIAsset/Tutorial Button"), new Rectangle((width / 2) - 160, 800, 320, 140)));

            bttnDict.Add("pauseBttn", new Button(Content.Load<Texture2D>("UIAsset/Pause Button"), new Rectangle((width / 2)-160, 90, 160, 80)));
            bttnDict.Add("reselectBttn", new Button(Content.Load<Texture2D>("UIAsset/Reselect Button"), new Rectangle((width / 2), 90, 160, 80)));

            bttnDict.Add("fullScreenBttn", new Button(Content.Load<Texture2D>("UIAsset/Full Screen Button"), new Rectangle((width / 2) - 160, 200, 320, 140)));
            bttnDict.Add("mainMenuBttn", new Button(Content.Load<Texture2D>("UIAsset/Main Menu Button"), new Rectangle((width / 2) - 160, 400, 320, 140)));
            bttnDict.Add("importBttn", new Button(Content.Load<Texture2D>("UIAsset/Import Button"), new Rectangle((width / 2) - 160, 600, 320, 140)));
            bttnDict.Add("backBttn", new Button(Content.Load<Texture2D>("UIAsset/Back Button"), new Rectangle((width / 2) - 160, 600, 320, 140)));

            bttnDict.Add("tutorialBackBttn", new Button(Content.Load<Texture2D>("UIAsset/Back Button"), new Rectangle((width / 2) - 160, 950, 240, 100)));

            playerOneWin = Content.Load<Texture2D>("Font/PlayerOneWin");
            playerTwoWin = Content.Load<Texture2D>("Font/PlayerTwoWin");
            gameOver = Content.Load<Texture2D>("Font/GameOver");
            title = Content.Load<Texture2D>("UIAsset/Title");
            tutorialPic = Content.Load<Texture2D>("UIAsset/TutorialPic");
            backGroundPic = Content.Load<Texture2D>("UIAsset/The BackGround");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            UpdateCursur();

            switch (currentGameState)
            {
                case GameState.MainMenu:

                    if (CollisionCheck(bttnDict["startBttn"].Position))
                    {
                        if (ClickCheck())
                        {
                            currentGameState = GameState.SpellPhase;
                        }
                    }

                    if (CollisionCheck(bttnDict["optionsBttn"].Position))
                    {
                        if (ClickCheck())
                        {
                            previousGameState = currentGameState;
                            currentGameState = GameState.Options;
                        }
                    }

                    if (CollisionCheck(bttnDict["tutorialBttn"].Position))
                    {
                        if (ClickCheck())
                        {
                            currentGameState = GameState.Tutorial;
                        }
                    }
                    break;

                case GameState.Tutorial:

                    if (CollisionCheck(bttnDict["tutorialBackBttn"].Position))
                    {
                        if (ClickCheck())
                        {
                            currentGameState = GameState.MainMenu;
                        }
                    }
                    break;

                case GameState.Options:

                    if (CollisionCheck(bttnDict["backBttn"].Position))
                    {
                        if (ClickCheck() && previousGameState != GameState.MainMenu)
                        {
                            currentGameState = previousGameState;
                        }
                    }

                    if (CollisionCheck(bttnDict["mainMenuBttn"].Position))
                    {
                        if (ClickCheck())
                        {
                            Reset();
                            currentGameState = GameState.MainMenu;
                        }
                    }

                    if (CollisionCheck(bttnDict["fullScreenBttn"].Position))
                    {
                        if (ClickCheck())
                        {
                            if (graphics.IsFullScreen == true)
                            {
                                graphics.IsFullScreen = false;
                                graphics.ApplyChanges();
                            }
                            else
                            {
                                graphics.IsFullScreen = true;
                                graphics.ApplyChanges();
                            }
                        }
                    }

                    if (CollisionCheck(bttnDict["importBttn"].Position))
                    {
                        if (ClickCheck() && previousGameState == GameState.MainMenu)
                        {
                            CardCreation importData = new CardCreation();
                            importData.DataReader();
                            GodsCard tempGod = null;

                            foreach (GodsCard g in godsListP1)
                            {
                                if(importData.GodReplaceWith == g.Name)
                                {
                                    tempGod = g;
                                }
                            }

                            foreach (GodsCard g in godsListP2)
                            {
                                if (importData.GodReplaceWith == g.Name)
                                {
                                    tempGod = g;
                                }
                            }

                            if (tempGod != null)
                            {
                                string tempSkillInfo = "";
                                for (int i =0; i<3;i++)
                                {
                                    if(godsListP1[i].Skill==importData.SkillData)
                                    {
                                        tempSkillInfo = godsListP1[i].SkillInfo;
                                    }

                                    if (godsListP2[i].Skill == importData.SkillData)
                                    {
                                        tempSkillInfo = godsListP2[i].SkillInfo;
                                    }
                                }

                                tempGod = new GodsCard(Content.Load<Texture2D>("GodsAsset/"+importData.GodAsset + "_Piskel"), tempGod.Position, importData.NameData, importData.SkillData, importData.AttackData, importData.HealthData, tempSkillInfo);
                            }

                            for (int i = 0; i < 3; i++)
                            {
                                if (importData.GodReplaceWith == godsListP1[i].Name)
                                {
                                    godsListP1[i] = tempGod;
                                }

                                if (importData.GodReplaceWith == godsListP2[i].Name)
                                {
                                    godsListP2[i] = tempGod;
                                }
                            }
                        }
                    }
                    break;

                case GameState.SpellPhase:

                    for (int i = 0; i < 3; i++)
                    {
                        if (godsListP1[i].CurrentHealth <= 0)
                        {
                            godsListP1[i].Disabled = true;
                            godsListP1[i].Dead = true;
                        }

                        if (godsListP2[i].CurrentHealth <= 0)
                        {
                            godsListP2[i].Disabled = true;
                            godsListP2[i].Dead = true;
                        }
                    }

                    if (CollisionCheck(bttnDict["pauseBttn"].Position))
                    {
                        if (ClickCheck())
                        {
                            previousGameState = currentGameState;
                            currentGameState = GameState.Options;
                        }
                    }

                    if (CollisionCheck(bttnDict["reselectBttn"].Position))
                    {
                        if (ClickCheck()&& selectedSpellSave != null)
                        {
                            selectedSpellSave.Clicked = false;
                            selectedSpellSave = null;
                        }
                    }

                    if (player1Turn == true)
                    {
                        if (selectedSpellSave == null)
                        {
                            SpellCard tempSelectedSpell = SelectSpell(spellListP1);

                            if (tempSelectedSpell != null)
                            {
                                selectedSpellSave = tempSelectedSpell;
                            }
                        }

                        if (selectedSpellSave != null && spellCasted == false)
                        {
                            spellCasted = CastSpellOnGod(selectedSpellSave, godsListP1);

                            if(spellCasted)
                            {
                                foreach (SpellCard spell in spellListP1)
                                {
                                    spell.Disabled = false;
                                }
                            }
                        }

                        GameStateCheck();
                    }

                    //Player 2's turn
                    else
                    {
                        if (selectedSpellSave == null)
                        {
                            SpellCard tempSelectedSpell = SelectSpell(spellListP2);

                            if (tempSelectedSpell != null)
                            {
                                selectedSpellSave = tempSelectedSpell;
                            }
                        }

                        if (selectedSpellSave != null && spellCasted == false)
                        {
                            spellCasted = CastSpellOnGod(selectedSpellSave, godsListP2);

                            if (spellCasted)
                            {
                                foreach (SpellCard spell in spellListP2)
                                {
                                    spell.Disabled = false;
                                }
                            }
                        }

                        GameStateCheck();
                    }

                    break;

                case GameState.AttackPhase:

                    if (CollisionCheck(bttnDict["pauseBttn"].Position))
                    {
                        if (ClickCheck())
                        {
                            previousGameState = currentGameState;
                            currentGameState = GameState.Options;
                        }
                    }

                    if (CollisionCheck(bttnDict["reselectBttn"].Position))
                    {
                        if (ClickCheck() && attackGodSave != null)
                        {
                            attackGodSave.Clicked = false;
                            attackGodSave = null;
                        }
                    }

                    //Player 1 turn
                    if (player1Turn == true)
                    {
                        if (attackGodSave == null)
                        {
                            GodsCard tempAttackGod = AttackGod(godsListP1);

                            if (tempAttackGod != null)
                            {
                                attackGodSave = tempAttackGod;
                            }
                        }

                        if (attackGodSave != null && targetGodSave == null)
                        {
                            GodsCard tempTargetGod = TargetGods(attackGodSave, godsListP2);
                            if (tempTargetGod != null)
                            {
                                targetGodSave = tempTargetGod;
                            }
                        }

                        if (attackGodSave != null && targetGodSave != null)
                        {
                            if (healStart == true)
                            {

                                GodsCard healGod = HealGod(godsListP1);
                                if (healGod != null)
                                {
                                    attackGodSave.HealingSkill(healGod);

                                    healStart = false;
                                }
                            }
                        }
                        GameStateCheck();
                    }

                    //Player 2 turn
                    else
                    {
                        if (attackGodSave == null)
                        {
                            GodsCard tempAttackGod = AttackGod(godsListP2);

                            if (tempAttackGod != null)
                            {
                                attackGodSave = tempAttackGod;
                            }
                        }

                        if (attackGodSave != null && targetGodSave == null)
                        {
                            GodsCard tempTargetGod = TargetGods(attackGodSave, godsListP1);
                            if (tempTargetGod != null)
                            {
                                targetGodSave = tempTargetGod;
                            }
                        }

                        if (attackGodSave != null && targetGodSave != null)
                        {
                            if (healStart == true)
                            {
                                GodsCard healGod = HealGod(godsListP2);
                                if (healGod != null)
                                {
                                    attackGodSave.HealingSkill(healGod);

                                    healStart = false;
                                }
                            }
                        }
                        GameStateCheck();
                    }
                    break;

                case GameState.GameOver:
                    Reset();
                    if (CollisionCheck(bttnDict["mainMenuBttn"].Position))
                    {
                        if (ClickCheck())
                        {
                            Reset();
                            currentGameState = GameState.MainMenu;
                        }
                    }
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            // TODO: Add your drawing code here
            //FSM
            spriteBatch.Begin();
            switch (currentGameState)
            {
                case GameState.MainMenu:

                    spriteBatch.Draw(backGroundPic, new Rectangle(0, 0, 1980, 1080), Color.White);
                    spriteBatch.Draw(title, new Rectangle((width / 2) - 600, 100, 1200, 200), Color.White);

                    if (CollisionCheck(bttnDict["startBttn"].Position))
                    {
                        bttnDict["startBttn"].Color = Color.Gray;
                        bttnDict["startBttn"].Draw(spriteBatch);
                    }
                    else
                    {
                        bttnDict["startBttn"].Color = Color.White;
                        bttnDict["startBttn"].Draw(spriteBatch);
                    }

                    //Options button
                    if (CollisionCheck(bttnDict["optionsBttn"].Position))
                    {
                        bttnDict["optionsBttn"].Color = Color.Gray;
                        bttnDict["optionsBttn"].Draw(spriteBatch);
                    }
                    else
                    {
                        bttnDict["optionsBttn"].Color = Color.White;
                        bttnDict["optionsBttn"].Draw(spriteBatch);
                    }

                    if (CollisionCheck(bttnDict["tutorialBttn"].Position))
                    {
                        bttnDict["tutorialBttn"].Color = Color.Gray;
                        bttnDict["tutorialBttn"].Draw(spriteBatch);
                    }
                    else
                    {
                        bttnDict["tutorialBttn"].Color = Color.White;
                        bttnDict["tutorialBttn"].Draw(spriteBatch);
                    }
                    break;

                case GameState.Tutorial:

                    spriteBatch.Draw(tutorialPic, new Vector2(140, 0), Color.White);

                    if (CollisionCheck(bttnDict["tutorialBackBttn"].Position))
                    {
                        bttnDict["tutorialBackBttn"].Color = Color.Gray;
                        bttnDict["tutorialBackBttn"].Draw(spriteBatch);
                    }
                    else
                    {
                        bttnDict["tutorialBackBttn"].Color = Color.White;
                        bttnDict["tutorialBackBttn"].Draw(spriteBatch);
                    }

                    break;

                case GameState.Options:

                    spriteBatch.Draw(backGroundPic, new Rectangle(0, 0, 1980, 1080), Color.White);
                    if (previousGameState!=GameState.MainMenu)
                    {
                        if (CollisionCheck(bttnDict["backBttn"].Position))
                        {
                            bttnDict["backBttn"].Color = Color.Gray;
                            bttnDict["backBttn"].Draw(spriteBatch);
                        }
                        else
                        {
                            bttnDict["backBttn"].Color = Color.White;
                            bttnDict["backBttn"].Draw(spriteBatch);
                        }
                    }

                    if (CollisionCheck(bttnDict["mainMenuBttn"].Position))
                    {
                        bttnDict["mainMenuBttn"].Color = Color.Gray;
                        bttnDict["mainMenuBttn"].Draw(spriteBatch);
                    }
                    else
                    {
                        bttnDict["mainMenuBttn"].Color = Color.White;
                        bttnDict["mainMenuBttn"].Draw(spriteBatch);
                    }

                    if (CollisionCheck(bttnDict["fullScreenBttn"].Position))
                    {
                        bttnDict["fullScreenBttn"].Color = Color.Gray;
                        bttnDict["fullScreenBttn"].Draw(spriteBatch);
                    }
                    else
                    {
                        bttnDict["fullScreenBttn"].Color = Color.White;
                        bttnDict["fullScreenBttn"].Draw(spriteBatch);
                    }

                    if(previousGameState==GameState.MainMenu)
                    {
                        if (CollisionCheck(bttnDict["importBttn"].Position))
                        {
                            bttnDict["importBttn"].Color = Color.Gray;
                            bttnDict["importBttn"].Draw(spriteBatch);
                        }
                        else
                        {
                            bttnDict["importBttn"].Color = Color.White;
                            bttnDict["importBttn"].Draw(spriteBatch);
                        }
                    }
                    break;


                case GameState.SpellPhase:

                    DrawUI("Spell Phase");

                    for (int i = 0; i < 3; i++)
                    {

                        if (spellListP1[i].Disabled == true)
                        {
                            spriteBatch.Draw(spellListP1[i].Asset, spellListP1[i].Position, Color.Blue);
                        }

                        if (spellListP2[i].Disabled == true)
                        {
                            spriteBatch.Draw(spellListP2[i].Asset, spellListP2[i].Position, Color.Blue);
                        }

                        if (godsListP1[i].Dead == true)
                        {
                            spriteBatch.Draw(godsListP1[i].Asset, godsListP1[i].Position, Color.Red);
                        }
                        else if (godsListP1[i].Disabled == true)
                        {
                            spriteBatch.Draw(godsListP1[i].Asset, godsListP1[i].Position, Color.Blue);
                        }

                        if (godsListP2[i].Dead == true)
                        {
                            spriteBatch.Draw(godsListP2[i].Asset, godsListP2[i].Position, Color.Red);
                        }
                        else if (godsListP2[i].Disabled == true)
                        {
                            spriteBatch.Draw(godsListP2[i].Asset, godsListP2[i].Position, Color.Blue);
                        }
                    }

                    if (player1Turn == true)
                    {
                        spriteBatch.DrawString(font, "Player1's Turn", new Vector2((width / 2) - 70, 50), Color.White);
                        //Spell card
                        foreach (SpellCard spell in spellListP1)
                        {
                            if (spell.Disabled == true)
                            {

                            }
                            else if (spell.Clicked == true)
                            {
                                spriteBatch.Draw(spell.Asset, spell.Position, Color.Gray);
                            }
                            else if (CollisionCheck(spell.Position) && spell.Disabled == false)
                            {
                                spriteBatch.Draw(spell.Asset, spell.Position, Color.Gray);
                            }
                            else
                            {
                                spriteBatch.Draw(spell.Asset, spell.Position, Color.White);
                            }
                        }

                        //Character card
                        foreach (GodsCard god in godsListP1)
                        {
                            if (god.Dead == true)
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.Red);
                            }
                            else if (god.Disabled == true)
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.Blue);
                            }
                            else if (god.Clicked == true)
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.Gray);
                            }
                            else if (CollisionCheck(god.Position) && god.Dead == false)
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.Gray);
                            }
                            else
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.White);
                            }
                        }
                    }
                    //Player 2
                    else
                    {
                        spriteBatch.DrawString(font, "Player2's Turn", new Vector2((width / 2) - 70, 50), Color.White);
                        //Spell card
                        foreach (SpellCard spell in spellListP2)
                        {
                            if(spell.Disabled == true)
                            {

                            }
                            else if (spell.Clicked == true)
                            {
                                spriteBatch.Draw(spell.Asset, spell.Position, Color.Gray);
                            }
                            else if (CollisionCheck(spell.Position) && spell.Disabled == false)
                            {
                                spriteBatch.Draw(spell.Asset, spell.Position, Color.Gray);
                            }
                            else
                            {
                                spriteBatch.Draw(spell.Asset, spell.Position, Color.White);
                            }
                        }

                        //Character card
                        foreach (GodsCard god in godsListP2)
                        {
                            if (god.Dead == true)
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.Red);
                            }
                            else if (god.Disabled == true)
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.Blue);
                            }
                            else if (god.Clicked == true)
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.Gray);
                            }
                            else if (CollisionCheck(god.Position) && god.Dead == false)
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.Gray);
                            }
                            else
                            {
                                spriteBatch.Draw(god.Asset, god.Position, Color.White);
                            }
                        }
                    }
                    break;

                case GameState.AttackPhase:

                    DrawUI("Attack Phase");

                    for (int i = 0; i < 3; i++)
                    {
                        if (spellListP1[i].Disabled == true)
                        {
                            spriteBatch.Draw(spellListP1[i].Asset, spellListP1[i].Position, Color.Blue);
                        }

                        if (spellListP2[i].Disabled == true)
                        {
                            spriteBatch.Draw(spellListP2[i].Asset, spellListP2[i].Position, Color.Blue);
                        }

                        if (godsListP1[i].Dead == true)
                        {
                            spriteBatch.Draw(godsListP1[i].Asset, godsListP1[i].Position, Color.Red);
                        }
                        else if (godsListP1[i].Disabled == true)
                        {
                            spriteBatch.Draw(godsListP1[i].Asset, godsListP1[i].Position, Color.Blue);
                        }

                        if (godsListP2[i].Dead == true)
                        {
                            spriteBatch.Draw(godsListP2[i].Asset, godsListP2[i].Position, Color.Red);
                        }
                        else if (godsListP2[i].Disabled == true)
                        {
                            spriteBatch.Draw(godsListP2[i].Asset, godsListP2[i].Position, Color.Blue);
                        }
                    }

                    if (player1Turn == true)
                    {
                        spriteBatch.DrawString(font, "Player1's Turn", new Vector2((width / 2) - 70, 50), Color.White);

                        foreach (GodsCard attackGod in godsListP1)
                        {
                            if (attackGod.Dead == true)
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.Red);
                            }
                            else if (attackGod.Disabled == true)
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.Blue);
                            }
                            else if (attackGod.Clicked == true)
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.Gray);
                            }
                            else if (CollisionCheck(attackGod.Position) && attackGod.Dead == false)
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.Gray);
                            }
                            else
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.White);
                            }
                        }

                        //Character card
                        foreach (GodsCard targetGod in godsListP2)
                        {
                            if (targetGod.Dead == true)
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.Red);
                            }
                            else if (targetGod.Disabled == true)
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.Blue);
                            }
                            else if (targetGod.Clicked == true)
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.Gray);
                            }
                            else if (CollisionCheck(targetGod.Position) && targetGod.Dead == false)
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.Gray);
                            }
                            else
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.White);
                            }
                        }
                    }
                    else
                    {
                        spriteBatch.DrawString(font, "Player2's Turn", new Vector2((width / 2) - 70, 50), Color.White);
                        //Character card 2
                        foreach (GodsCard attackGod in godsListP2)
                        {
                            if (attackGod.Dead == true)
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.Red);
                            }
                            else if (attackGod.Disabled == true)
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.Blue);
                            }
                            else if (attackGod.Clicked == true)
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.Gray);
                            }
                            else if (CollisionCheck(attackGod.Position) && attackGod.Dead == false)
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.Gray);
                            }
                            else
                            {
                                spriteBatch.Draw(attackGod.Asset, attackGod.Position, Color.White);
                            }
                        }

                        //Character card
                        foreach (GodsCard targetGod in godsListP1)
                        {
                            if (targetGod.Dead == true)
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.Red);
                            }
                            else if (targetGod.Disabled == true)
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.Blue);
                            }
                            else if (targetGod.Clicked == true)
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.Gray);
                            }
                            else if (CollisionCheck(targetGod.Position) && targetGod.Dead == false)
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.Gray);
                            }
                            else
                            {
                                spriteBatch.Draw(targetGod.Asset, targetGod.Position, Color.White);
                            }
                        }
                    }
                    break;
                case GameState.GameOver:
                    if (CollisionCheck(bttnDict["mainMenuBttn"].Position))
                    {
                        bttnDict["mainMenuBttn"].Color = Color.Gray;
                        bttnDict["mainMenuBttn"].Draw(spriteBatch);
                    }
                    else
                    {
                        bttnDict["mainMenuBttn"].Color = Color.White;
                        bttnDict["mainMenuBttn"].Draw(spriteBatch);
                    }
                    if (godsListP1[0].CurrentHealth == 0 && godsListP1[1].CurrentHealth == 0 && godsListP1[2].CurrentHealth == 0)
                    {
                        spriteBatch.Draw(playerTwoWin, new Vector2((width / 2)-300, 120), Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(playerOneWin, new Vector2((width / 2) - 300, 120), Color.White);
                    }
                    spriteBatch.Draw(gameOver, new Vector2((width / 2) - 270, 260), Color.White);
                    break;
            }
            DrawCursur();
            spriteBatch.End();
            base.Draw(gameTime);
        }

        //resets the game when it ends so it can be played again
        private void Reset()
        {
            foreach (GodsCard god in godsListP1)
            {
                god.Disabled = false;
                god.CurrentHealth = god.Health;
                god.Dead = false;
                god.Taunt = false;
            }
            foreach (GodsCard god in godsListP2)
            {
                god.Disabled = false;
                god.CurrentHealth = god.Health;
                god.Dead = false;
                god.Taunt = false;
            }
            foreach (SpellCard spell in spellListP1)
            {
                spell.Disabled = false;
            }
            foreach (SpellCard spell in spellListP2)
            {
                spell.Disabled = false;
            }
            attackGodSave = null;
            targetGodSave = null;
            spellCasted = false;
            player1Turn = true;
        }

        /// <summary>
        /// Update the position of cursur and state of mouse
        /// </summary>
        private void UpdateCursur()
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();
            cursur.X = currentMouseState.X;
            cursur.Y = currentMouseState.Y;
        }

        private void DrawCursur()
        {
            spriteBatch.Draw(white, cursur, Color.Blue);
        }

        private bool ClickCheck()
        {
            if(previousMouseState.LeftButton == ButtonState.Released && currentMouseState.LeftButton == ButtonState.Pressed)
            {
                clickSFX.Play();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DrawUI(string phase)
        {
            spriteBatch.Draw(backGroundPic, new Rectangle(0, 0, 1980, 1080), Color.White);

            //Draw every spell and gods
            foreach (SpellCard s1 in spellListP1)
            {
                s1.Draw(spriteBatch);
            }
            foreach (SpellCard s2 in spellListP2)
            {
                s2.Draw(spriteBatch);
            }
            //Character cards
            foreach (GodsCard g1 in godsListP1)
            {
                g1.Draw(spriteBatch);
            }

            foreach (GodsCard g2 in godsListP2)
            {
                g2.Draw(spriteBatch);
            }

            if (CollisionCheck(bttnDict["pauseBttn"].Position))
            {
                bttnDict["pauseBttn"].Color = Color.Gray;
                bttnDict["pauseBttn"].Draw(spriteBatch);
            }
            else
            {
                bttnDict["pauseBttn"].Color = Color.White;
                bttnDict["pauseBttn"].Draw(spriteBatch);
            }

            if (CollisionCheck(bttnDict["reselectBttn"].Position))
            {
                bttnDict["reselectBttn"].Color = Color.Gray;
                bttnDict["reselectBttn"].Draw(spriteBatch);
            }
            else
            {
                bttnDict["reselectBttn"].Color = Color.White;
                bttnDict["reselectBttn"].Draw(spriteBatch);
            }

            InformationBox();

            spriteBatch.Draw(white, new Rectangle(godsListP1[0].Position.X, godsListP1[0].Position.Y - 40, 200, 30), Color.Black);
            spriteBatch.Draw(white, new Rectangle(godsListP1[1].Position.X, godsListP1[1].Position.Y - 40, 200, 30), Color.Black);
            spriteBatch.Draw(white, new Rectangle(godsListP1[2].Position.X, godsListP1[2].Position.Y - 40, 200, 30), Color.Black);
            spriteBatch.Draw(white, new Rectangle(godsListP2[0].Position.X, godsListP2[0].Position.Y - 40, 200, 30), Color.Black);
            spriteBatch.Draw(white, new Rectangle(godsListP2[1].Position.X, godsListP2[1].Position.Y - 40, 200, 30), Color.Black);
            spriteBatch.Draw(white, new Rectangle(godsListP2[2].Position.X, godsListP2[2].Position.Y - 40, 200, 30), Color.Black);

            //Draw every string
            spriteBatch.DrawString(font, string.Format("HP: " + godsListP1[0].CurrentHealth), new Vector2(godsListP1[0].Position.X, godsListP1[0].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format("HP: " + godsListP1[1].CurrentHealth), new Vector2(godsListP1[1].Position.X, godsListP1[1].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format("HP: " + godsListP1[2].CurrentHealth), new Vector2(godsListP1[2].Position.X, godsListP1[2].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format(godsListP1[0].Name), new Vector2(godsListP1[0].Position.X + 100, godsListP1[0].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format(godsListP1[1].Name), new Vector2(godsListP1[1].Position.X + 100, godsListP1[1].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format(godsListP1[2].Name), new Vector2(godsListP1[2].Position.X + 100, godsListP1[2].Position.Y - 40), Color.White);

            spriteBatch.DrawString(font, string.Format("HP: " + godsListP2[0].CurrentHealth), new Vector2(godsListP2[0].Position.X, godsListP2[0].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format("HP: " + godsListP2[1].CurrentHealth), new Vector2(godsListP2[1].Position.X, godsListP2[1].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format("HP: " + godsListP2[2].CurrentHealth), new Vector2(godsListP2[2].Position.X, godsListP2[2].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format(godsListP2[0].Name), new Vector2(godsListP2[0].Position.X + 100, godsListP2[0].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format(godsListP2[1].Name), new Vector2(godsListP2[1].Position.X + 100, godsListP2[1].Position.Y - 40), Color.White);
            spriteBatch.DrawString(font, string.Format(godsListP2[2].Name), new Vector2(godsListP2[2].Position.X + 100, godsListP2[2].Position.Y - 40), Color.White);

            spriteBatch.DrawString(font, phase, new Vector2((width / 2) - 70, 20), Color.White);
        }

        /// <summary>
        /// Check if two rectangle collided or not
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool CollisionCheck(Rectangle position)
        {
            return position.Intersects(cursur);
        }

        private GodsCard AttackGod(List<GodsCard> attackGodList)
        {
            GodsCard tempCard = null;

            foreach (GodsCard attackGod in attackGodList)
            {
                if (attackGod.CurrentHealth <= 0)
                {
                    attackGod.Disabled = true;
                    attackGod.Dead = true;
                }

                if (player1Turn == true)
                {
                    if(godsListP1[0].Dead && godsListP1[1].Dead || godsListP1[0].Dead && godsListP1[2].Dead || godsListP1[1].Dead && godsListP1[2].Dead )
                    {
                        attackGod.Disabled = false;
                    }
                }
                else
                {
                    if ((godsListP2[0].Dead && godsListP2[1].Dead) || (godsListP2[0].Dead && godsListP2[2].Dead) || (godsListP2[1].Dead && godsListP2[2].Dead))
                    {
                        attackGod.Disabled = false;
                    }
                }

                if (CollisionCheck(attackGod.Position) && !attackGod.Disabled && !attackGod.Dead)
                {
                    if (ClickCheck())
                    {
                        attackGod.Clicked = true;
                        tempCard = attackGod;

                        foreach (GodsCard gods in attackGodList)
                        {
                            gods.Disabled = false;
                        }
                    }
                }
            }
            return tempCard;
        }

        private GodsCard TargetGods(GodsCard attackGod, List<GodsCard> TargetGodList)
        {
            GodsCard tempGod = null;

            if (attackGod != null)
            {
                if (attackGod.Clicked && healStart != true)
                {
                    if (attackGod.Taunt)
                    {
                        foreach (GodsCard targetGods in TargetGodList)
                        {
                            if (CollisionCheck(targetGods.Position) && targetGods.Skill == "Taunt")
                            {
                                if (ClickCheck()&&!targetGods.Dead)
                                {
                                    targetGods.Clicked = true;
                                    tempGod = targetGods;

                                    if (attackGod.Skill == "Water")
                                    {
                                        attackGod.AoeSkill(TargetGodList[0], TargetGodList[1], TargetGodList[2]);
                                    }
                                    else if (attackGod.Skill == "Burn")
                                    {
                                        if (TargetGodList[0].Clicked == true)
                                        {
                                            attackGod.AoeBurnSkill(targetGods, TargetGodList[1], TargetGodList[2]);
                                        }
                                        else if (TargetGodList[1].Clicked == true)
                                        {
                                            attackGod.AoeBurnSkill(targetGods, TargetGodList[0], TargetGodList[2]);
                                        }
                                        else if (TargetGodList[2].Clicked == true)
                                        {
                                            attackGod.AoeBurnSkill(targetGods, TargetGodList[0], TargetGodList[1]);
                                        }
                                    }
                                    else if (attackGod.Skill == "Taunt")
                                    {
                                        attackGod.SingleAttackSkill(targetGods);
                                        attackGod.TauntSkill(TargetGodList[0], TargetGodList[1], TargetGodList[2]);
                                    }
                                    else if (attackGod.Skill == "SelfDamage")
                                    {
                                        attackGod.SelfDamageAttackSkill(targetGods);
                                    }
                                    else if (attackGod.Skill == "Lightning")
                                    {
                                        attackGod.SingleAttackSkill(targetGods);
                                    }
                                    else if (attackGod.Skill == "Heal")
                                    {
                                        attackGod.SingleAttackSkill(targetGods);
                                        healStart = true;
                                        attackGod.Clicked = false;
                                        targetGods.Clicked = false;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        foreach (GodsCard targetGods in TargetGodList)
                        {
                            if (CollisionCheck(targetGods.Position))
                            {
                                if (ClickCheck()&&!targetGods.Dead)
                                {
                                    targetGods.Clicked = true;
                                    tempGod = targetGods;

                                    if (attackGod.Skill == "Water")
                                    {
                                        attackGod.AoeSkill(TargetGodList[0], TargetGodList[1], TargetGodList[2]);
                                    }
                                    else if (attackGod.Skill == "Burn")
                                    {
                                        if (TargetGodList[0].Clicked == true)
                                        {
                                            attackGod.AoeBurnSkill(targetGods, TargetGodList[1], TargetGodList[2]);
                                        }
                                        else if (TargetGodList[1].Clicked == true)
                                        {
                                            attackGod.AoeBurnSkill(targetGods, TargetGodList[0], TargetGodList[2]);
                                        }
                                        else if (TargetGodList[2].Clicked == true)
                                        {
                                            attackGod.AoeBurnSkill(targetGods, TargetGodList[0], TargetGodList[1]);
                                        }
                                    }
                                    else if (attackGod.Skill == "Taunt")
                                    {
                                        attackGod.SingleAttackSkill(targetGods);
                                        attackGod.TauntSkill(TargetGodList[0], TargetGodList[1], TargetGodList[2]);
                                    }
                                    else if (attackGod.Skill == "SelfDamage")
                                    {
                                        attackGod.SelfDamageAttackSkill(targetGods);
                                    }
                                    else if (attackGod.Skill == "Lightning")
                                    {
                                        attackGod.SingleAttackSkill(targetGods);
                                    }
                                    else if (attackGod.Skill == "Heal")
                                    {

                                        attackGod.SingleAttackSkill(targetGods);
                                        healStart = true;
                                        attackGod.Clicked = false;
                                        targetGods.Clicked = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return tempGod;
        }

        private GodsCard HealGod(List<GodsCard> healGodList)
        {
            GodsCard tempCard = null;

            foreach (GodsCard healGod in healGodList)
            {
                healGod.Clicked = false;
                if (CollisionCheck(healGod.Position))
                {
                    if (ClickCheck()&& !healGod.Dead)
                    {
                        tempCard = healGod;
                    }
                }
            }
            return tempCard;
        }

        private SpellCard SelectSpell(List<SpellCard> spellList)
        {
            SpellCard tempSpell = null;

            foreach (SpellCard targetSpell in spellList)
            {
                if (CollisionCheck(targetSpell.Position) && !targetSpell.Disabled)
                {
                    if (ClickCheck())
                    {
                        targetSpell.Clicked = true;
                        tempSpell = targetSpell;
                    }
                }
            }
            return tempSpell;
        }

        private bool CastSpellOnGod(SpellCard targetSpell, List<GodsCard> GodList)
        {
            bool casted = false;
            foreach (GodsCard god in GodList)
            { 
                if (CollisionCheck(god.Position))
                {
                    if (ClickCheck() && targetSpell.Clicked && !god.Dead)
                    {
                        casted = true;

                        if (targetSpell.Skill == "Heal")
                        {
                            targetSpell.Heal(god);
                        }
                        else if (targetSpell.Skill == "Refresh")
                        {
                            if (god.Disabled == true)
                            {
                                targetSpell.Refresh(god);
                            }
                        }
                        else if (targetSpell.Skill == "Increase strength")
                        {
                            targetSpell.IncreaseAttack(god);
                        }
                    }
                }
            }

            return casted;
        }

        private void GameStateCheck()
        {
            if (attackGodSave != null && targetGodSave != null && healStart != true)
            {
                if ((godsListP1[0].CurrentHealth == 0 && godsListP1[1].CurrentHealth == 0 && godsListP1[2].CurrentHealth == 0) || (godsListP2[0].CurrentHealth == 0 && godsListP2[1].CurrentHealth == 0 && godsListP2[2].CurrentHealth == 0))
                {
                    currentGameState = GameState.GameOver;
                }
                else
                {
                    attackGodSave.Disabled = true;
                    attackGodSave.Clicked = false;
                    targetGodSave.Clicked = false;

                    healStart = false;

                    if (player1Turn == true)
                    {
                        player1Turn = false;

                        godsListP1[0].Taunt = false;
                        godsListP1[1].Taunt = false;
                        godsListP1[2].Taunt = false;

                        foreach (GodsCard g in godsListP1)
                        {
                            if (g.AttackIncreased == true)
                            {
                                g.Attack /= 2;
                            }
                            g.AttackIncreased = false;
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            if (attackGodSave.Name == godsListP1[i].Name)
                            {
                                godsListP1[i] = attackGodSave;
                            }
                        }

                    }
                    else
                    {
                        player1Turn = true;

                        godsListP2[0].Taunt = false;
                        godsListP2[1].Taunt = false;
                        godsListP2[2].Taunt = false;

                        foreach (GodsCard g in godsListP2)
                        {
                            if (g.AttackIncreased == true)
                            {
                                g.Attack /= 2;
                            }
                            g.AttackIncreased = false;
                        }

                        for (int i = 0; i < 3; i++)
                        {
                            if (attackGodSave.Name == godsListP2[i].Name)
                            {
                                godsListP2[i] = attackGodSave;
                            }
                        }
                    }

                    attackGodSave = null;
                    targetGodSave = null;
                    currentGameState = GameState.SpellPhase;
                }
            }
            else if(selectedSpellSave != null && spellCasted)
            {
                selectedSpellSave.Clicked = false;
                selectedSpellSave.Disabled = true;
                selectedSpellSave = null;
                spellCasted = false;
                currentGameState = GameState.AttackPhase;
            }
        }

        private void InformationBox()
        {
            spriteBatch.Draw(white, infoBoxPosition, Color.Black * 0.8f);

            foreach(SpellCard spell in spellListP1)
            {
                if (CollisionCheck(spell.Position))
                {
                    spriteBatch.DrawString(font, "Name: "+spell.Name, new Vector2(infoBoxPosition.X, infoBoxPosition.Y), Color.White);
                    spriteBatch.DrawString(font, "Skill Info:" + spell.SkillInfo, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 40), Color.White);
                    spriteBatch.DrawString(font, "On CoolDown: " + spell.Disabled, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 120), Color.White);
                }
            }

            foreach (SpellCard spell in spellListP2)
            {
                if (CollisionCheck(spell.Position))
                {
                    spriteBatch.DrawString(font, "Name: " + spell.Name, new Vector2(infoBoxPosition.X, infoBoxPosition.Y), Color.White);
                    spriteBatch.DrawString(font, "Skill Info:" + spell.SkillInfo, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 40), Color.White);
                    spriteBatch.DrawString(font, "On CoolDown: " + spell.Disabled, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 120), Color.White);
                }
            }

            foreach (GodsCard god in godsListP1)
            {
                if (CollisionCheck(god.Position))
                {
                    spriteBatch.DrawString(font, "Name: " + god.Name, new Vector2(infoBoxPosition.X, infoBoxPosition.Y), Color.White);
                    spriteBatch.DrawString(font, "Skill Info:" + god.SkillInfo, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 40), Color.White);
                    spriteBatch.DrawString(font, "On CoolDown: " + god.Disabled, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 120), Color.White);
                    spriteBatch.DrawString(font, "Dead: " + god.Dead, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 160), Color.White);
                }
            }

            foreach (GodsCard god in godsListP2)
            {
                if (CollisionCheck(god.Position))
                {
                    spriteBatch.DrawString(font, "Name: " + god.Name, new Vector2(infoBoxPosition.X, infoBoxPosition.Y), Color.White);
                    spriteBatch.DrawString(font, "Skill Info:" + god.SkillInfo, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 40), Color.White);
                    spriteBatch.DrawString(font, "On CoolDown: " + god.Disabled, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 120), Color.White);
                    spriteBatch.DrawString(font, "Dead: " + god.Dead, new Vector2(infoBoxPosition.X, infoBoxPosition.Y + 160), Color.White);
                }
            }
        }
    }
}
