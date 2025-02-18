﻿using Dispo.Commom;
using Dispo.Domain.Entities;
using Dispo.Infrastructure.Repositories.Interfaces;
using Dispo.Service.DTOs.ResponseDTOs;
using Dispo.Service.Services.Interfaces;
using System.Transactions;

namespace Dispo.Service.Services
{
    public class UserAccountService : IUserAccountService
    {
        private readonly IUserRepository _userRepository;

        public UserAccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserAccountResponseDto> UpdateUserAccountInfo(UserAccountResponseDto userAccountModel)
        {
            User? userInfo = null;

            using (var tc = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var userUpdated = await _userRepository.GetUserByAccountId(userAccountModel.Id);

                if (userUpdated == null)
                    throw new Exception("Informações não encontradas para esta conta!");

                userUpdated.BirthDate = userAccountModel.BirthDate;
                userUpdated.CpfCnpj = userAccountModel.CpfCnpj;
                userUpdated.FirstName = userAccountModel.FirstName;
                userUpdated.LastName = userAccountModel.LastName;
                userUpdated.Phone = userAccountModel.Phone;

                userInfo = _userRepository.Update(userUpdated);

                tc.Complete();
            }

            return new UserAccountResponseDto()
            {
                Id = userInfo.Id.ToLong(),
                FirstName = userInfo.FirstName,
                LastName = userInfo.LastName,
                BirthDate = userInfo.BirthDate,
                Phone = userInfo.Phone,
                CpfCnpj = userInfo.CpfCnpj,
            };
        }
    }
}