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
        protected Texture2D TurretTexture;
        protected Texture2D texture;
        protected List<GameObject> ChildrenList = new List<GameObject>();
        //protected bool bEnabledCollision = true;
        //protected Vector2 v2min;
        //protected Vector2 v2Max;


        // set parent
        // update transform
        // draw

        public GameObject(string fileName)
        {
            image = LoadImage(fileName);
            texture = LoadTextureFromImage(image);
            TurretImage = LoadImage(fileName);
            TurretTexture = LoadTextureFromImage(TurretImage);
            LocalTransform = new Matrix3(true);
            GlobalTransform = new Matrix3(true);
        }

        

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

        void AddChild(GameObject child)
        {
            ChildrenList.Add(child);
        }

        void RemoveChild(GameObject child)
        {
            ChildrenList.Remove(child);
        }
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
            foreach (GameObject child in ChildrenList)
            {
                child.Update(deltaTime);
            }
        }
    }

}
