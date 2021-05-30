using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Important
{
    public class VelocitiesOfGameObjects
    {
        public string NameOfGameObject { get; set; }
        public float VelocityX { get; set; }
        public float VelocityY { get; set; }
        public VelocitiesOfGameObjects(string nameOfGameObject, float velocityX, float velocityY) 
        {
            this.NameOfGameObject = nameOfGameObject;
            this.VelocityX = velocityX;
            this.VelocityY = velocityY;
        }
        public static void AddToList(GameObject gameObject, List<VelocitiesOfGameObjects> velocitiesOfGameObjectsMap)
        {
            VelocitiesOfGameObjects velocitiesOfGameObjectsMapObject = new VelocitiesOfGameObjects(gameObject.name.ToString(), gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y);
            velocitiesOfGameObjectsMap.Add(velocitiesOfGameObjectsMapObject);
        }
        public static void ReadFromList(GameObject gameObject, List<VelocitiesOfGameObjects> velocitiesOfGameObjectsMap) 
        {
            foreach (VelocitiesOfGameObjects velocitiesOfGameObjectsMapObject in velocitiesOfGameObjectsMap)
                gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.name.ToString() == velocitiesOfGameObjectsMapObject.NameOfGameObject.ToString() ? new Vector2(velocitiesOfGameObjectsMapObject.VelocityX, velocitiesOfGameObjectsMapObject.VelocityY) : gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }
}
