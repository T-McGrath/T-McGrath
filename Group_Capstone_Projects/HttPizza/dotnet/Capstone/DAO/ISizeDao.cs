using System.Collections.Generic;
using Capstone.Models;

namespace Capstone.DAO
{
    public interface ISizeDao
    {
        IList<Size> GetAllSizes();
        Size GetSizeById(int sizeId);
        Size CreateSize(Size size);
        Size UpdateSizeAvailability(int sizeId, Size size);
    }
}
