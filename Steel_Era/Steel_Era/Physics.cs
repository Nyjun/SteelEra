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
    class Physics
    {
        public List<Sprite> ListSprite
        {
            get { return listSprite; }
            set { listSprite = value; }
        }
        private List<Sprite> listSprite;

        public List<Sprite> ListObstacle
        {
            get { return listObstacle; }
            set { listObstacle = value; }
        }
        private List<Sprite> listObstacle;

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



        public Vector2 CalculateForces()
        { 
            return Vector2.Zero; 
        }

        public Vector2 SpriteIntersection(Sprite Obstacle, Sprite spriteMov)
        {
            float interX = 0, interY = 0;

            if ((spriteMov.HitBox.SideRight < Obstacle.HitBox.SideRight && spriteMov.HitBox.SideLeft > Obstacle.HitBox.SideLeft) || (spriteMov.HitBox.SideRight > spriteMov.HitBox.SideRight && spriteMov.HitBox.SideLeft < Obstacle.HitBox.SideLeft))
            {
                if (spriteMov.HitBox.SideDown < Obstacle.HitBox.SideUp && spriteMov.HitBox.SideDown > Obstacle.HitBox.SideDown)//
                {
                    interY = spriteMov.HitBox.SideDown - Obstacle.HitBox.SideUp;
                }
                if (spriteMov.HitBox.SideUp > Obstacle.HitBox.SideDown && spriteMov.HitBox.SideUp < Obstacle.HitBox.SideUp)
                {
                    interY = Obstacle.HitBox.SideUp - spriteMov.HitBox.SideDown;
                }
            }
            else
            if (spriteMov.HitBox.SideRight < Obstacle.HitBox.SideRight && spriteMov.HitBox.SideRight > Obstacle.HitBox.SideLeft)//
            {
                if ((spriteMov.HitBox.SideDown < Obstacle.HitBox.SideUp && spriteMov.HitBox.SideDown > Obstacle.HitBox.SideDown)||(spriteMov.HitBox.SideUp > Obstacle.HitBox.SideDown && spriteMov.HitBox.SideUp < Obstacle.HitBox.SideUp))
                {
                    interX = Obstacle.HitBox.SideLeft - spriteMov.HitBox.SideRight;//
                }
            }
            else
            if (spriteMov.HitBox.SideLeft < Obstacle.HitBox.SideRight && spriteMov.HitBox.SideLeft > spriteMov.HitBox.SideLeft)//
            {
                if ((spriteMov.HitBox.SideDown < Obstacle.HitBox.SideUp && spriteMov.HitBox.SideDown > Obstacle.HitBox.SideDown)||(spriteMov.HitBox.SideUp > Obstacle.HitBox.SideDown && spriteMov.HitBox.SideUp < Obstacle.HitBox.SideUp))
                {
                    interX = Obstacle.HitBox.SideRight - spriteMov.HitBox.SideLeft;//
                }
            }

            /*if (spriteMov.Direction.X >= 0)//Deplacement vers la droite.
            {
                if (spriteMov.HitBox.SideRight > Obstacle.HitBox.SideLeft)//Collision droite.
                {
                    if (spriteMov.Direction.Y >= 0)//Deplacement vers le haut.
                    {
                        if (spriteMov.HitBox.SideUp >= Obstacle.HitBox.SideDown)//Collision haute.
                        {
                            interY = spriteMov.HitBox.SideUp - Obstacle.HitBox.SideDown;
                        }
                        else//Pas de collision haute.
                        {
                            return new Vector2(spriteMov.HitBox.SideRight - Obstacle.HitBox.SideLeft, 0);
                        }
                    }
                    else//Deplacement vers le bas
                    {
                        if (spriteMov.HitBox.SideDown >= Obstacle.HitBox.SideUp)//Collision Basse.
                        {
                            interY = spriteMov.HitBox.SideDown - Obstacle.HitBox.SideUp;
                        }
                        else//Pas de collision basse.
                        {
                            return new Vector2(spriteMov.HitBox.SideRight - Obstacle.HitBox.SideLeft, 0);
                        }
                    }

                }
            }
            else if (spriteMov.Direction.X < 0)
            {

            }*/

            return new Vector2(interX, interY);
        }

    }
}
