using AutoMapper;
using Hali.Core.DTOs;
using Hali.Core.Models;
using Hali.Core.Repositories;
using Hali.Core.Services;
using Hali.Core.UnitOfWorks;
using Hali.Repository.UnitOfWorks;
using Hali.Shared.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Hali.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IGenericRepository<Company> _genericRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(UserManager<AppUser> userManager, IGenericRepository<Company> genericRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _genericRepository = genericRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseDto<CompanyWithUserDto>> CreateCompanyWithUserAsync(CompanyWithUserCreateDto companyWithUserCreateDto)
        {
            var companyEntity = _mapper.Map<Company>(companyWithUserCreateDto);
            await _genericRepository.AddAsync(companyEntity);
            await _unitOfWork.CommitAsync();

            var user = new AppUser { Email = companyEntity.Email, UserName = companyWithUserCreateDto.UserName, CompanyId = companyEntity.Id, FullName = companyEntity.ProprietorFullName };

            var result = await _userManager.CreateAsync(user, companyWithUserCreateDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return ResponseDto<CompanyWithUserDto>.Fail(new ErrorDto(errors, true), 400);
            }

            var companyWithUserDto = _mapper.Map<CompanyWithUserDto>(user);

            return ResponseDto<CompanyWithUserDto>.Succes(companyWithUserDto, 200);
        }

        public async Task<ResponseDto<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user=new AppUser { Email= createUserDto.Email, UserName=createUserDto.UserName, CompanyId=createUserDto.CompanyId };

            var result=await _userManager.CreateAsync(user,createUserDto.Password);

            if(!result.Succeeded)
            {
                var errors=result.Errors.Select(x=>x.Description).ToList();

                return ResponseDto<AppUserDto>.Fail(new ErrorDto(errors,true), 400);
            }
            
            var userDto=_mapper.Map<AppUserDto>(user);

            return ResponseDto<AppUserDto>.Succes(userDto, 200);
        }

        public async Task<ResponseDto<AppUserDto>> GetUserByNameAsync(string userName)
        {
            if (userName == null) throw new ArgumentNullException("Token is wrong");

            var user=await _userManager.FindByNameAsync(userName);

            if(user==null) return ResponseDto<AppUserDto>.Fail("username is not found", 404,true);

            var userDto = _mapper.Map<AppUserDto>(user);

            return ResponseDto<AppUserDto>.Succes(userDto, 200);
        }
    }
}
