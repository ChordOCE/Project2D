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
        protected Matrix3 LocalTranform;
        protected Matrix3 GlobalTransform;
        protected Image logo;
        protected Texture2D texture;
        protected static List<GameObject> ChildrenList = new List<GameObject>();
        

        static void GetParent()
        {

        }

        static void AddChild(GameObject child)
        {
            ChildrenList.Add(child);
        }

        static void RemoveChild(GameObject child)
        {
            ChildrenList.Remove(child);
        }

        public static void SetPosition(Vector2 PlayerPos)
        {
            PlayerPos.x = 0;
            PlayerPos.y = 0;
        }

        public static Vector2 GetPosition()
        {
            return ;
        }

        public virtual void Update()
        {

        }
    }

}
