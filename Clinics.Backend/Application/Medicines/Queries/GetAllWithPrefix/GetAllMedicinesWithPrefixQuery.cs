using Application.Abstractions.CQRS.Queries;

namespace Application.Medicines.Queries.GetAllWithPrefix;

public class GetAllMedicinesWithPrefixQuery : IQuery<GetAllMedicinesWithPrefixResponse>
{
    public string? Prefix { get; set; } = null;
}
