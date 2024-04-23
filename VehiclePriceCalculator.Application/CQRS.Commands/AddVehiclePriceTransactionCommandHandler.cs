using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehiclePriceCalculator.Domain.Entities;
using VehiclePriceCalculator.Domain.Interfaces;
using VehiclePriceCalculator.Domain.Interfaces.Repositories;

namespace VehiclePriceCalculator.Application.CQRS.Commands
{
    public class AddVehiclePriceTransactionCommandHandler : IRequestHandler<AddVehiclePriceTransactionCommand, VehiclePriceTransaction>
    {
        private readonly IVehiclePriceTransactionRepository _vehiclePriceTransactionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddVehiclePriceTransactionCommandHandler(IVehiclePriceTransactionRepository vehiclePriceTransactionRepository, IUnitOfWork unitOfWork)
        {
            _vehiclePriceTransactionRepository = vehiclePriceTransactionRepository ?? throw new ArgumentNullException(nameof(vehiclePriceTransactionRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<VehiclePriceTransaction> Handle(AddVehiclePriceTransactionCommand request, CancellationToken cancellationToken)
        {
            var vehiclePriceTransaction = new VehiclePriceTransaction
            {
                VehiclePrice = request.VehiclePrice,
                BasicFee = request.BasicFee,
                SpecialFee = request.SpecialFee,
                AssociationFee = request.AssociationFee,
                StorageFee = request.StorageFee,
                TotalCost = request.TotalCost,
                VehicleTypeId = request.VehicleTypeId,
                DateCreated = DateTime.Now,
                CreatedBy = "System",
                DateModified =DateTime.Now,
                ModifiedBy = "System"
            };

            var response = await _vehiclePriceTransactionRepository.AddVehiclePriceTransactionListAsync(vehiclePriceTransaction);
            await _unitOfWork.SaveAsync();


            return response;
        }
    }
}
 
