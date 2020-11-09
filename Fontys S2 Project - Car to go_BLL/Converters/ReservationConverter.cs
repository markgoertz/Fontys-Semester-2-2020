using BLL.Models;
using DTO_layer.Entities_DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public class ReservationConverter
    {

            private static Reservation _model;
            private static ReservationDTO _dto;
            public static Reservation ConvertDtoToModel(ReservationDTO dto)
            {
                _model = new Reservation()
                {
                    ReservationID = dto.ReservationID,
                    Email = dto.Email,
                    VehicleID = dto.VehicleID,
                    StartDate = dto.StartDate,
                    EndDate = dto.EndDate,
                };

                return _model;
            }

            public static ReservationDTO ConvertModelToDto(Reservation model)
            {
                _dto = new ReservationDTO()
                {
                    ReservationID = model.ReservationID,
                    Email = model.Email,
                    VehicleID = model.VehicleID,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                };

                return _dto;
            }
        
    }
}

