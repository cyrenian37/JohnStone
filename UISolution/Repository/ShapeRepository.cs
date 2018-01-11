using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UISolution.Models
{
    public class ShapeRepository : Repository<Shape>, IShapeRepository
    {
        public IEnumerable<Shape> RetrieveByNumberOfSides(int sideCount)
        {
            return FindAll(shape => shape.NumberOfSides == sideCount);
        }

        public ShapeRepository(IDataContextFactory dataContextFactory)
            : base(dataContextFactory)
        {
            
        }
    }
}