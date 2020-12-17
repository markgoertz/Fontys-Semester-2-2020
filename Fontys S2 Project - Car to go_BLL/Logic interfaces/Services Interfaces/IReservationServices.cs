using BLL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic_interfaces.Services_Interfaces
{
    public interface IReservationServices
    {
        bool CorrectStartDate(Reservation reservation);
        bool CheckForDate(Reservation inputUser);
        bool IsEndDateGreaterThenStartDate(Reservation reservation);
    }
}
