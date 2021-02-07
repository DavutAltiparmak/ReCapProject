using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(c => c.ColorId == id);
        }

        public void Add(Color color)
        {
            _colorDal.Add(color);
            Console.WriteLine("{0} Eklendi",color.ColorName);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("{0} Güncellendi", color.ColorName);
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("{0} Silindi", color.ColorName);
        }
    }
}
