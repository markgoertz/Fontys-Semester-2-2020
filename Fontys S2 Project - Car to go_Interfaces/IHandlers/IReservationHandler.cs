using DTO_layer.Entities_DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces.IHandlers
{
    public interface IReservationHandler
    {
        void PlaceReservation(ReservationDTO C1);
        void Delete(int ID);
        List<ReservationDTO> GetallReservations();
        bool CheckForDoubleReservations(ReservationDTO C1);
    }
}
