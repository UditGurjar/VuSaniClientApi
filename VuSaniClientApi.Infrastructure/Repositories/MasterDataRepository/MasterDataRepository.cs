using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
using VuSaniClientApi.Models.DBModels;
using VuSaniClientApi.Models.DTOs;

namespace VuSaniClientApi.Infrastructure.Repositories.MasterDataRepository
{
    public class MasterDataRepository : IMasterDataRepository
    {
        private readonly ApplicationDbContext _context;

        public MasterDataRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<object> GetCountriesAsync(bool all = true)
        {
            try
            {
                var query = _context.Countries.AsQueryable();

                var countries = await query
                    .Select(c => new CountryListDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Code = null // Country model doesn't have Code field
                    })
                    .ToListAsync();

                return new { status = true, data = countries };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetStatesAsync(int? countryId = null, bool all = true)
        {
            try
            {
                var query = _context.States.AsQueryable();

                if (countryId.HasValue)
                {
                    query = query.Where(s => s.CountryId == countryId.Value);
                }

                var states = await query
                    .Select(s => new StateListDto
                    {
                        Id = s.Id,
                        Name = s.Name,
                        CountryId = s.CountryId,
                        CountryName = s.Country != null ? s.Country.Name : null
                    })
                    .ToListAsync();

                return new { status = true, data = states };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetCitiesAsync(int? stateId = null, bool all = true)
        {
            try
            {
                var query = _context.Cities.AsQueryable();

                if (stateId.HasValue)
                {
                    query = query.Where(c => c.StateId == stateId.Value);
                }

                var cities = await query
                    .Select(c => new CityListDto
                    {
                        Id = c.Id,
                        Name = c.Name,
                        StateId = c.StateId,
                        StateName = c.State != null ? c.State.Name : null
                    })
                    .ToListAsync();

                return new { status = true, data = cities };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetGendersAsync()
        {
            try
            {
                var genders = await _context.Genders
                    .Select(g => new GenderListDto
                    {
                        Id = g.Id,
                        Name = g.Name
                    })
                    .ToListAsync();

                return new { status = true, data = genders };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetLanguagesAsync()
        {
            try
            {
                var languages = await _context.Languages
                    .Select(l => new LanguageListDto
                    {
                        Id = l.Id,
                        Name = l.Name
                    })
                    .ToListAsync();

                return new { status = true, data = languages };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetRacesAsync()
        {
            try
            {
                var races = await _context.Set<VuSaniClientApi.Models.DBModels.Race>()
                    .Select(r => new RaceListDto
                    {
                        Id = r.Id,
                        Name = r.Name
                    })
                    .ToListAsync();

                return new { status = true, data = races };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetEmployeeTypesAsync()
        {
            try
            {
                var employeeTypes = await _context.EmployeeTypes
                    .Select(et => new EmployeeTypeListDto
                    {
                        Id = et.Id,
                        Name = et.Name
                    })
                    .ToListAsync();

                return new { status = true, data = employeeTypes };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetBanksAsync()
        {
            try
            {
                var banks = await _context.Banks
                    .Select(b => new BankListDto
                    {
                        Id = b.Id,
                        Name = b.Name
                    })
                    .ToListAsync();

                return new { status = true, data = banks };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetRelationshipsAsync()
        {
            try
            {
                var relationships = await _context.RelationShips
                    .Select(r => new RelationshipListDto
                    {
                        Id = r.Id,
                        Name = r.Name
                    })
                    .ToListAsync();

                return new { status = true, data = relationships };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetReasonForInactiveAsync(int page, int pageSize, bool all, string search, string filter)
        {
            try
            {
                var query = from r in _context.ReasonForInactives
                            join org in _context.Organizations on r.OrganizationId equals org.Id into orgGroup
                            from org in orgGroup.DefaultIfEmpty()
                            join dept in _context.Department on r.DepartmentId equals dept.Id into deptGroup
                            from dept in deptGroup.DefaultIfEmpty()
                            join createdUser in _context.Users on r.CreatedBy equals createdUser.Id into createdGroup
                            from createdUser in createdGroup.DefaultIfEmpty()
                            where r.Deleted == "0"
                            select new { r, org, dept, createdUser };

                if (!string.IsNullOrWhiteSpace(search))
                {
                    var searchLower = search.ToLower();
                    query = query.Where(x =>
                        (x.r.Name != null && x.r.Name.ToLower().Contains(searchLower)) ||
                        (x.r.Description != null && x.r.Description.ToLower().Contains(searchLower)) ||
                        (x.createdUser.Name != null && x.createdUser.Name.ToLower().Contains(searchLower)));
                }

                if (!string.IsNullOrWhiteSpace(filter) && int.TryParse(filter, out int orgFilterId))
                {
                    query = query.Where(x => x.r.OrganizationId == orgFilterId);
                }

                var total = await query.CountAsync();

                if (!all)
                {
                    query = query.Skip((page - 1) * pageSize).Take(pageSize);
                }

                var list = await query
                    .Select(x => new ReasonForInactiveListDto
                    {
                        Id = x.r.Id,
                        Name = x.r.Name,
                        Description = x.r.Description,
                        OrganizationId = x.r.OrganizationId,
                        OrganizationName = x.org != null ? x.org.Name : null,
                        DepartmentId = x.r.DepartmentId,
                        DepartmentName = x.dept != null ? x.dept.Name : null,
                        CreatedBy = x.r.CreatedBy,
                        CreatedByName = x.createdUser != null ? x.createdUser.Name : null,
                        CreatedBySurname = x.createdUser != null ? x.createdUser.Surname : null,
                        UniqueId = x.r.UniqueId
                    })
                    .ToListAsync();

                return new { status = true, data = list, total };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<object> GetReasonForInactiveByIdAsync(int id)
        {
            try
            {
                var item = await (from r in _context.ReasonForInactives
                                 join org in _context.Organizations on r.OrganizationId equals org.Id into orgGroup
                                 from org in orgGroup.DefaultIfEmpty()
                                 join dept in _context.Department on r.DepartmentId equals dept.Id into deptGroup
                                 from dept in deptGroup.DefaultIfEmpty()
                                 join createdUser in _context.Users on r.CreatedBy equals createdUser.Id into createdGroup
                                 from createdUser in createdGroup.DefaultIfEmpty()
                                 where r.Id == id && r.Deleted == "0"
                                 select new ReasonForInactiveListDto
                                 {
                                     Id = r.Id,
                                     Name = r.Name,
                                     Description = r.Description,
                                     OrganizationId = r.OrganizationId,
                                     OrganizationName = org != null ? org.Name : null,
                                     DepartmentId = r.DepartmentId,
                                     DepartmentName = dept != null ? dept.Name : null,
                                     CreatedBy = r.CreatedBy,
                                     CreatedByName = createdUser != null ? createdUser.Name : null,
                                     CreatedBySurname = createdUser != null ? createdUser.Surname : null,
                                     UniqueId = r.UniqueId
                                 })
                    .FirstOrDefaultAsync();

                if (item == null)
                    return new { status = false, message = "Record not found", data = (object?)null };

                return new { status = true, data = new[] { item } };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

