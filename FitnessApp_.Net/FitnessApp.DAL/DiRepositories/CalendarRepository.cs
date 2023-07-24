using FitnessApp.DAL.InterfaceRepositories;
using FitnessApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.DAL.repositories
{
    public class CalendarRepository : ICalendarRepository
    {
        private readonly FitnessAppContext _context;
        public CalendarRepository(FitnessAppContext _context)
        {
            this._context = _context;
        }
        public async Task CreateCalendarAsync(Calendar calendar)
        {
            await _context.Calendars.AddAsync(calendar);
            await SaveChangeAsync();
        }

        public async Task DeleteCalendarAsync(int CalendarId)
        {
            _context.Calendars.Remove(await GetCalendarByIdAsync(CalendarId));
            await SaveChangeAsync();
        }

        public async Task<List<Calendar>> GetAllCalendarsAsync()
        {
            return await _context.Calendars.ToListAsync();
        }

        public async Task<List<Calendar>> GetCalendarByDayAsync(DateTime Day)
        {
            return  await _context.Calendars.Where(c=>c.day.Day== Day.Day).ToListAsync();            
        }

        public async Task<Calendar> GetCalendarByIdAsync(int CalendarId)
        {
            return await _context.Calendars.FindAsync(CalendarId);
        }

        public async Task UpdateCalendarAsync(Calendar calendar)
        {
            var changingCalendar = await _context.Calendars.FirstOrDefaultAsync(c=>c.id == calendar.id);
            changingCalendar = calendar;
            await SaveChangeAsync();
        }
        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
