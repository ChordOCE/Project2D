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
        GameObject world;
        Player tank = null;
        Crate crate = null;
        Wall wallLeft = null;
        Wall wallRight = null;
        Wall wallTop = null;
        Wall wallBottom = null;
        Stopwatch stopwatch = new Stopwatch();
        private long currentTime = 0;
        private long lastTime = 0;
        private float timer = 0;
        private int fps = 1;
        private int frames;
        public float deltaTime = 0.005f;
        Random randomPos;

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

            world = new GameObject("");

            //Initialize objects here
            //image = LoadImage("../Images/aie-logo-dark.jpg");
            //texture = LoadTextureFromImage(image);dw
            tank = new Player("../Images/unnamed.png");
            randomPos = new Random();
            crate = new Crate("../Images/Crate.png",new Vector2(randomPos.Next(68, 1852), randomPos.Next(68,1014)));
            wallLeft = new Wall("", 50, 2000, new Vector2(0, 0));
            wallRight = new Wall("", 50, 2000, new Vector2(1920, 1080/2));
            wallTop = new Wall("", 5000, 50, new Vector2(0, 0));
            wallBottom = new Wall("", 5000, 50, new Vector2(0, 1080));
            tank.SetParent(world);
            wallBottom.SetParent(world);
            wallTop.SetParent(world);
            wallLeft.SetParent(world);
            wallRight.SetParent(world);
            crate.SetParent(world);
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

            world.Update(deltaTime);
            world.UpdateTransforms();
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
            crate.Draw();
            wallBottom.Draw();
            EndDrawing();
        }
    }
}
