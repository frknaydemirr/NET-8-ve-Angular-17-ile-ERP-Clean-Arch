﻿using AutoMapper;
using ERPServer.Application.Features.Customers.CreateCustomer;
using ERPServer.Domain.Entities;
using ERPServer.Domain.Repository;
using GenericRepository;
using MediatR;
using TS.Result;

internal sealed class CreateCustomerCommandHandler(
    ICustomerRepository customerRepository,
    IUnitOfWork unitOfWork,
    IMapper mapper) : IRequestHandler<CreateCustomerCommand, Result<string>>



{
    public async Task<Result<string>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        bool isTaxNumberExists = await customerRepository.AnyAsync(p => p.TaxNumber == request.TaxNumber,
            cancellationToken
            );
        if (isTaxNumberExists)
        {
            return Result<string>.Failure("Vergi numarası daha önceden kaydedilmiş!");
        }
        Customer customer = mapper.Map<Customer>(request);
        await customerRepository.AddAsync(customer,cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return "Müşteri kaydı başarıyla tamamlandı!"; 

    }


}


