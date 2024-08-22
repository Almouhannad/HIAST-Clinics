﻿using Domain.Entities.Identity.Users;
using Domain.Errors;
using Domain.Shared;

namespace Application.Users.Queries.GetAllReceptionistsUsers;

public class GetAllReceptionistUsersResponse
{
    public class GetAllReceptionistUsersResponseItem
    {
        public string UserName { get; set; } = null!;
        public string FullName { get; set; } = null!;
    }
    public ICollection<GetAllReceptionistUsersResponseItem> DoctorUsers { get; set; } = [];

    public static Result<GetAllReceptionistUsersResponse> GetResponse(ICollection<ReceptionistUser> receptionistUsers)
    {
        List<GetAllReceptionistUsersResponseItem> result = new();
        foreach (var receptionistUser in receptionistUsers)
        {
            if (receptionistUser.User is null || receptionistUser.PersonalInfo is null)
                return Result.Failure<GetAllReceptionistUsersResponse>(PersistenceErrors.NotFound);
            var receptionistUserItem = new GetAllReceptionistUsersResponseItem
            {
                UserName = receptionistUser.User.UserName,
                FullName = receptionistUser.PersonalInfo.FullName
            };
            result.Add(receptionistUserItem);
        }
        return new GetAllReceptionistUsersResponse
        {
            DoctorUsers = result
        };
    }
}