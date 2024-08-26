using Application.Abstractions.CQRS.Queries;
using Domain.Repositories;
using Domain.Shared;

namespace Application.Medicines.Queries.GetAllWithPrefix;

public class GetAllMedicinesWithPrefixHandler : IQueryHandler<GetAllMedicinesWithPrefixQuery, GetAllMedicinesWithPrefixResponse>
{
    #region CTOR DI
    private readonly IMedicinesRepository _medicinesRepository;

    public GetAllMedicinesWithPrefixHandler(IMedicinesRepository medicinesRepository)
    {
        _medicinesRepository = medicinesRepository;
    }
    #endregion
    public async Task<Result<GetAllMedicinesWithPrefixResponse>> Handle(GetAllMedicinesWithPrefixQuery request, CancellationToken cancellationToken)
    {
        #region 1. Fetch data from persistence
        var medicinesFromPersistence = await _medicinesRepository.GetAllWithPrefix(request.Prefix);
        if (medicinesFromPersistence.IsFailure)
            return Result.Failure<GetAllMedicinesWithPrefixResponse>(medicinesFromPersistence.Error);
        var medicines = medicinesFromPersistence.Value;
        #endregion

        return Result.Success<GetAllMedicinesWithPrefixResponse>(
            GetAllMedicinesWithPrefixResponse.GetResponse(medicines));
    }
}
