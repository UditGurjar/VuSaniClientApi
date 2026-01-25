using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VuSaniClientApi.Infrastructure.DBContext;
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
    }
}

