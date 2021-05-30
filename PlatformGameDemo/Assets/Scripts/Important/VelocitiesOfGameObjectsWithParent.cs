using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Important
{
    public class VelocitiesOfGameObjectsWithParent : VelocitiesOfGameObjects
    {
        public string NameOfFather { get; set; }
        public VelocitiesOfGameObjectsWithParent(string nameOfGameObject, float velocityX, float velocityY, string nameOfFather) : base(nameOfGameObject,velocityX,velocityY)
        {
            this.NameOfFather = nameOfFather;
        }
        public static void AddToList(GameObject gameObject, List<VelocitiesOfGameObjectsWithParent> velocitiesOfGameObjectsWithParentMap)
        {
            VelocitiesOfGameObjectsWithParent velocitiesOfGameObjectsWithParentMapObject = new VelocitiesOfGameObjectsWithParent(gameObject.name.ToString(), gameObject.GetComponent<Rigidbody2D>().velocity.x, gameObject.GetComponent<Rigidbody2D>().velocity.y, gameObject.transform.parent.name.ToString());
            velocitiesOfGameObjectsWithParentMap.Add(velocitiesOfGameObjectsWithParentMapObject);
        }
        public static void ReadFromList(GameObject gameObject, List<VelocitiesOfGameObjectsWithParent> velocitiesOfGameObjectsWithParentMap)
        {
            foreach (VelocitiesOfGameObjectsWithParent velocitiesOfGameObjectsWithParentMapObject in velocitiesOfGameObjectsWithParentMap)
                gameObject.GetComponent<Rigidbody2D>().velocity = gameObject.transform.parent.name.ToString() == velocitiesOfGameObjectsWithParentMapObject.NameOfFather.ToString() && gameObject.name.ToString() == velocitiesOfGameObjectsWithParentMapObject.NameOfGameObject.ToString() ? new Vector2(velocitiesOfGameObjectsWithParentMapObject.VelocityX, velocitiesOfGameObjectsWithParentMapObject.VelocityY) : gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }
}
