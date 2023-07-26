using FitnessApp.Models;

namespace FitnessApp.DAL.InterfaceRepositories
{
    public interface ICalendarRepository
    {
        public Task<List<Calendar>> GetAllCalendarsAsync();
        public Task<List<Calendar>> GetCalendarByDayAsync(DateTime Day);
        public Task<Calendar> GetCalendarByIdAsync(int CalendarId);
        public Task CreateCalendarAsync(Calendar calendar);
        public Task UpdateCalendarAsync(Calendar calendar);
        public Task DeleteCalendarAsync(int CalendarId);
    }
}