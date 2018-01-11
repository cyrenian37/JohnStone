using System;
using System.Collections.Generic;
using System.Text;

namespace UISolution.Models
{

    public interface IShapeRepository : IRepository<Shape>
    {
        IEnumerable<Shape> RetrieveByNumberOfSides(int sideCount);
    }
}