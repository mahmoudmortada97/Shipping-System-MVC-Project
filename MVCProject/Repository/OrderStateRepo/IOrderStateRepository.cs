﻿using MVCProject.Models;

namespace MVCProject.Repository.OrderStateRepo
{
    public interface IOrderStateRepository
    {
        List<OrderState> GetAll();
    }
}
