﻿using ApiAdmin.Exceptions;
using ApiAdmin.Models;
using ApiAdmin.Repository.Base;
using AutoMapper;
using DTO.DTO.ApiAdmin;
using DTO.Event;
using HttpCall;

namespace ApiAdmin.Features.Empleados
{
    public class CreateEmpleadoUseCase(
        IUnitOfWork _unitOfWork,
        IMapper _mapper,
        DarAltaEmpleadoNotification _darAltaEmpleadoNotification)
    {
        public async Task Execute(EmpleadoDTO empleado)
        {
            using (var transaction = _unitOfWork.BeginTransaction())
            {
                try
                {
                    var entity = _mapper.Map<Empleado>(empleado);
                    entity.CodigoRh = Guid.NewGuid().ToString();

                    await _unitOfWork.Empleado.Add(entity);
                    await _unitOfWork.SaveChangesAsync();

                    await _darAltaEmpleadoNotification.Notify(empleado);

                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
        }
    }


}
