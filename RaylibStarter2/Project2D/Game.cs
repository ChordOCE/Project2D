using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raylib;
using static Raylib.Raylib;
using MathClasses;


namespace Project2D
{
    class Game
    {
        Player tank = null;
        Crate crate = null;
        Stopwatch stopwatch = new Stopwatch();
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;
        public float deltaTime = 0.005f;


        public Game()
        {
        }

        public void Init()
        {
            stopwatch.Start();
            lastTime = stopwatch.ElapsedMilliseconds;

            if (Stopwatch.IsHighResolution)
            {
                Console.WriteLine("Stopwatch high-resolution frequency: {0} ticks per second", Stopwatch.Frequency);
            }

            //Initialize objects here
            //image = LoadImage("../Images/aie-logo-dark.jpg");
            //texture = LoadTextureFromImage(image);
            tank = new Player("../Images/unnamed.png");
            crate = new Crate("../Images/Crate.png");

        }

        public void Shutdown()
        {
        }

        public virtual void Update()
        {
            lastTime = currentTime;
            currentTime = stopwatch.ElapsedMilliseconds;
            deltaTime = (currentTime - lastTime) / 1000.0f;
            timer += deltaTime;
            if (timer >= 1)
            {
                fps = frames;
                frames = 0;
                timer -= 1;
            }
            frames++;

            //Update game objects here   

            tank.Update(deltaTime);
            tank.UpdateTransforms();
            crate.Update(deltaTime);
            crate.UpdateTransforms();
            CollisionManager.CheckCollision();
        }
    
        public void Draw()
        {
            BeginDrawing();


            ClearBackground(RLColor.WHITE);

			//Draw game objects here
            DrawText(fps.ToString(), 10, 10, 14, RLColor.RED);

            //DrawTexture(texture, GetScreenWidth() / 2 - texture.width / 2, GetScreenHeight() / 2 - texture.height / 2, RLColor.WHITE);
            tank.Draw();
            crate.Draw();
            EndDrawing();
        }

    }
}
