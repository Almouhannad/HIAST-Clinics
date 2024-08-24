using Domain.Errors;
using Domain.Primitives;
using Domain.Shared;

namespace Domain.Entities.Visits;

public sealed class Holiday : Entity
{
    #region Private ctor
    private Holiday(int id) : base(id)
    {
    }

    private Holiday(int id, int visitId, DateOnly from, int duration) : base(id)
    {
        VisitId = visitId;
        From = from;
        Duration = duration;
    }
    #endregion

    #region Properties

    #region Visit
    public int VisitId { get; private set; }
    #endregion

    public DateOnly From { get; private set; }
    public int Duration { get; private set; }

    #endregion

    #region Methods

    #region Static factory
    public static Result<Holiday> Create (int visitId, DateOnly from, int duration)
    {
        if (visitId <= 0 || duration <= 0)
            return Result.Failure<Holiday>(DomainErrors.InvalidValuesError);
        if (duration > 5)
            return Result.Failure<Holiday>(DomainErrors.InvalidHolidayDuration);
        return new Holiday(0, visitId, from, duration);

    }
    #endregion

    #endregion
}
