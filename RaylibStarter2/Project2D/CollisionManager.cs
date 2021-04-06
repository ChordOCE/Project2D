using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathClasses;

namespace Project2D
{
    class CollisionManager
    {

        protected static List<GameObject> ObjectList = new List<GameObject>();

        //adds objects to the collision manager so that it can collide with other objects that are on the list
        public static void AddObject(GameObject obj)
        {
            ObjectList.Add(obj);
        } 

        //check if two objects on the collision manager list are overlapping
        public static void CheckCollision()
        {
            foreach (GameObject obj1 in ObjectList)
            {
                foreach (GameObject obj2 in ObjectList)
                {
                    //this is here so that objects cannot collide with themselves
                    if (obj1 == obj2)
                        continue;
                    //this is so we can turn collision off for objects we dont wont colliding i.e the turret of the tank
                    if (obj1.EnableCollision == false || obj2.EnableCollision == false)
                        continue;
                    Vector2 obj1min = obj1.GetPosition() + obj1.objMin;
                    Vector2 obj1max = obj1.GetPosition() + obj1.objMax;
                    Vector2 obj2min = obj2.GetPosition() + obj2.objMin;
                    Vector2 obj2max = obj2.GetPosition() + obj2.objMax;

                    if (obj2max.x > obj1min.x &&
                        obj2max.y > obj1min.y && 
                        obj2min.x < obj1max.x &&
                        obj2min.y < obj1max.y)
                    {
                        obj1.OnCollision();
                    }
                }
            }
        }
    }
}
