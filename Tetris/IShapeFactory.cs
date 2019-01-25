using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Tetris
{
    /// <authors>
    /// Seaim Khan and William Ngo
    /// </authors>
    public interface IShapeFactory
    {
        //methods
        /// <summary>
        /// Makes a new shape.
        /// </summary>
        void DeployNewShape();
    }
}
