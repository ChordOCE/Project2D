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
    class GameObject
    {
        protected GameObject Parent;
        protected Matrix3 LocalTransform;
        protected Matrix3 GlobalTransform;
        protected Image image;
        protected Image TurretImage;
        protected Image crate;
        protected Texture2D crateTexture;
        protected Texture2D TurretTexture;
        protected Texture2D texture;
        protected List<GameObject> ChildrenList = new List<GameObject>();
        public bool EnableCollision = true;
        public Vector2 objMin;
        public Vector2 objMax;
        public Vector2 LastSafe;

        //creating all the images needed for the tank game
        //and adding GameObject to the Collision Manager
        public GameObject(string fileName)
        {
            image = LoadImage(fileName);
            texture = LoadTextureFromImage(image);
            TurretImage = LoadImage(fileName);
            TurretTexture = LoadTextureFromImage(TurretImage);
            crate = LoadImage(fileName);
            crateTexture = LoadTextureFromImage(crate);
            LocalTransform = new Matrix3(true);
            GlobalTransform = new Matrix3(true);
            objMin.x = .5f * -texture.width;
            objMin.y = .5f * -texture.height;
            objMax.x = .5f * texture.width;
            objMax.y = .5f * texture.height;
            CollisionManager.AddObject(this);
        }

        // function to get the x and y position of any GameObject
        public Vector2 GetPosition()
        {
            Vector2 Position;
            Position.x = GlobalTransform.m[6];
            Position.y = GlobalTransform.m[7];
            return Position;

        }

        //allows to give objects parents so that they follow that object without movement functions
        public void SetParent(GameObject parent)
        {
            if (Parent != null)
                Parent.ChildrenList.Remove(this);

            Parent = parent;

            if (Parent != null)
                Parent.ChildrenList.Add(this);
            
        }


        public GameObject GetParent(GameObject parent)
        {
            return Parent = parent;
        }


        //allows for rotation of objects
        public void UpdateTransforms()
        {
            if (Parent != null)
                GlobalTransform = Parent.GlobalTransform * LocalTransform;
            else
                GlobalTransform = LocalTransform;

            foreach (GameObject child in ChildrenList)
            {
                child.UpdateTransforms();
            }
        }

        //saves the last position that an object wasnt colliding with another object
        //so that we can move the object back to that position
        public virtual void OnCollision()
        {
            LocalTransform.m[6] = LastSafe.x;
            LocalTransform.m[7] = LastSafe.y;
            UpdateTransforms();
        }

        //function that can be used to draw all the different objects
        public void Draw()
        {
            Renderer.DrawTexture(texture, GlobalTransform, RLColor.WHITE.ToColor());

            foreach (GameObject child in ChildrenList)
            {
                child.Draw();
            }
        }

        public virtual void Update(float deltaTime)
        {
            //updates the current lastsafe position to the current frame every frame
            LastSafe.x = LocalTransform.m[6];
            LastSafe.y = LocalTransform.m[7];
            foreach (GameObject child in ChildrenList)
            {
                child.Update(deltaTime);
            }
        }
    }

}
