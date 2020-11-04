using BLL.Models;
using DTO_layer.Entities_DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class UserModelConverter
    {
        private static User _model;
        private static UserDTO _dto;
        public static User ConvertDtoToModel(UserDTO dto)
        {
            _model = new User()
            {
                ID = dto.ID,
                Firstname = dto.Firstname,
                Lastname = dto.Lastname,
                Adres = dto.Adres,
                Postalcode = dto.Postalcode,
                Email = dto.Email,
                Housenumber = dto.Housenumber,
                Role = dto.Role,
                Password = dto.Password
            };

            return _model;
        }

        public static UserDTO ConvertModelToDto(User model)
        {
            _dto = new UserDTO()
            {
                ID = model.ID,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                Adres = model.Adres,
                Postalcode = model.Postalcode,
                Email = model.Email,
                Housenumber = model.Housenumber,
                Role = model.Role,
                Password = model.Password
            };

            return _dto;
        }
    }
}
