using FP_EN_Brusnikau_s24109.Classes.Models;
using FP_EN_Brusnikau_s24109.Classes.Models.Core_Module;
using FP_EN_Brusnikau_s24109.Classes.Models.School_Module;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FP_EN_Brusnikau_s24109.Services.School_Module
{
	public class EnrollmentRepository : IEnrollmentRepository
	{
		private readonly MageCompendiumContext _context;

		public EnrollmentRepository(MageCompendiumContext context)
		{
			_context = context;
		}

		public async Task AddEnrollmentAsync(Enrollment enrollment)
		{
			_context.Enrollments.Add(enrollment);

			await _context.SaveChangesAsync();
		}

		public async Task DeleteEnrollmentAsync(int id)
		{
			var Enrollment = await _context.Enrollments.FindAsync(id);

			if (Enrollment != null)
			{
				_context.Enrollments.Remove(Enrollment);

				await _context.SaveChangesAsync();
			}
		}

		public async Task<List<Enrollment>> FindEnrollmentsByStudentAndSchoolAsync(Mage student, ArcaneSchool arcaneSchool)
		{
			var enrollments = await _context.Enrollments
				.Include(e => e.Mage)
				.Include(e => e.ArcaneSchool)
				.Where(e => e.Mage == student && e.ArcaneSchool == arcaneSchool)
				.ToListAsync();

			return enrollments;
		}

		public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
		{
			return await _context.Enrollments.ToListAsync();
		}

		public async Task<Enrollment?> GetEnrollmentByIdAsync(int id)
		{
			return await _context.Enrollments.FindAsync(id);
		}
	}
}
