using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Steel_Era
{
    abstract class Physics
    {
        static public List<Sprite> ListSprite
        {
            get { return listSprite; }
            set { listSprite = value; }
        }
         static private List<Sprite> listSprite;

        static public List<Sprite> ListObstacle
        {
            get { return listObstacle; }
            set { listObstacle = value; }
        }
        static private List<Sprite> listObstacle;

        /// <summary>
        /// Force de support.
        /// </summary>
        public Vector2 Support(Vector2 force, Vector2 direction)
        {
            return new Vector2(direction.X * force.X, direction.Y * force.Y);
        }

        /// <summary>
        /// Force de frottement.
        /// </summary>
        public Vector2 Friction(Vector2 force, float roughness)
        {

            return (1f - roughness) * force;// new Vector2(force.X - roughness, force.Y - roughness);
        }

        /// <summary>
        /// Elasticity.
        /// </summary>
        public void Reject(Sprite obstacle, Sprite spriteMov)
        {
            spriteMov.Position = spriteMov.Position;
        }



        static public Vector2 CalculateForces(Sprite s)
        { 
            return Vector2.Zero; 
        }

        

        

    }
}
