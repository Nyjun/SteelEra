using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Steel_Era.Stages
{
    class Stage
    {
        public Stage()
        {
            lists = new Lists();
        }

        public Lists lists;

        public virtual void Update()
        {

        }

    }
}
