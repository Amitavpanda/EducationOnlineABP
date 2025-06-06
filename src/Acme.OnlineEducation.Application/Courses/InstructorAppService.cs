using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.OnlineEducation.Courses
{
    public class InstructorAppService :
        CrudAppService<
            Instructor,
            InstructorDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateInstructorDto>,
        IInstructorAppService
    {
        private readonly IRepository<Instructor, Guid> _instructorRepository;

        public InstructorAppService(IRepository<Instructor, Guid> instructorRepository)
            : base(instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
    }
}
