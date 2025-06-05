using Acme.OnlineEducation.CourseCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.OnlineEducation.Enrollments
{
    public class EnrollmentAppService :
            CrudAppService<
                Enrollment, // The entity
                CourseEnrollmentDto, // The DTO for the entity
                Guid, // Primary key type
                PagedAndSortedResultRequestDto, // Used for paging/sorting
                CreateUpdateEnrollmentDto>,
                IEnrollmentAppService


    {
        private readonly IRepository<Enrollment, Guid> _enrollmentRepository;
        private readonly IRepository<Payment, Guid> _paymentRepository;
        private readonly IRepository<Course, Guid> _courseRepository;

        public EnrollmentAppService(
            IRepository<Enrollment, Guid> enrollmentRepository,
            IRepository<Payment, Guid> paymentRepository,
            IRepository<Course, Guid> courseRepository)
            : base(enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
            _paymentRepository = paymentRepository;
            _courseRepository = courseRepository;
        }
        // Get all enrollments for a specific user, including payment details and course title
        public async Task<List<CourseEnrollmentDto>> GetUserEnrollmentsAsync(Guid userId)
        {
            // Fetch enrollments for the user with related data
            var enrollmentsQuery = await _enrollmentRepository.WithDetailsAsync(e => e.Payments);
            var enrollments = enrollmentsQuery.Where(e => e.UserId == userId).ToList();

            // Map enrollments to DTOs
            var enrollmentDtos = ObjectMapper.Map<List<Enrollment>, List<CourseEnrollmentDto>>(enrollments);

            // Include payment details and course title for each enrollment
            foreach (var enrollmentDto in enrollmentDtos)
            {
                // Fetch the course title
                var course = await _courseRepository.GetAsync(enrollmentDto.CourseId);
                enrollmentDto.CourseTitle = course.Title;

                // Fetch payment details
                var payments = await _paymentRepository.GetListAsync(p => p.EnrollmentId == enrollmentDto.Id);
                enrollmentDto.CoursePayment = ObjectMapper.Map<Payment, CoursePaymentDto>(payments.FirstOrDefault());
            }

            return enrollmentDtos;
        }






    }
}
