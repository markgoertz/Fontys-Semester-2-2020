using BLL.Converters;
using Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CarCollection
    {
        private List<Car> _car;

        public void Create(Car article)
        {
            var result = ModelConverter.ConvertModelToDto(article);
            DalFactory.CarHandler.Create(result);
        }

        public List<Car> GetAllCars()
        {
            _car = new List<Car>();
            var result = DalFactory.CarHandler.GetAll();

            foreach (var dto in result)
            {
                _car.Add(ModelConverter.ConvertDtoToModel(dto));
            }

            return _car;
        }
    }
}
