using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.School_Module
{
	public interface IEnrollmentRepository
	{
		Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync();

		Task<Enrollment?> GetEnrollmentByIdAsync(int id);

		Task AddEnrollmentAsync(Enrollment enrollment);

		Task DeleteEnrollmentAsync(int id);

		Task<List<Enrollment>> FindEnrollmentsByStudentAndSchoolAsync(Mage student, ArcaneSchool arcaneSchool);
	}
}
