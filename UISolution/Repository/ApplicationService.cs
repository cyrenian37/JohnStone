using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UISolution.Models
{
    public class ApplicationService
    {
        private IRepository<Shape> _genericShapeRepository;
        private IShapeRepository _specializedShapeRepository;

        public ApplicationService(IRepository<Shape> genericShapeRepository, IShapeRepository specializedShapeRepository)
        {
            _genericShapeRepository = genericShapeRepository;

            _specializedShapeRepository = specializedShapeRepository;
        }

        public void DoSomethingWithTheGenericRepository()
        {
            IList<Shape> threeSidedShapes = _genericShapeRepository.FindAll(shape => shape.NumberOfSides == 3).ToList();

            _genericShapeRepository.MarkForDeletion(threeSidedShapes[0]);
            _genericShapeRepository.SaveAll();
        }

        public void DoSomethingWithTheSpecializedRepository()
        {
            IList<Shape> threeSidedShapes = _specializedShapeRepository.RetrieveByNumberOfSides(3).ToList();

            _specializedShapeRepository.MarkForDeletion(threeSidedShapes[0]);
            _specializedShapeRepository.SaveAll();
        }

    }
}
