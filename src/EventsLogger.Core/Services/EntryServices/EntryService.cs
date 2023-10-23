using AutoMapper;
using EventsLogger.Data;
using EventsLogger.Dtos;
using EventsLogger.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventsLogger.Services.EntryServices
{

    public class EntryService : IEntryService
    {
        private readonly IMapper _mapper;
        private readonly UserContext _context;

        public EntryService(IMapper mapper, UserContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EntryDto> CreateEntryAsync(CreateUserDto entry)
        {
            entrys.Add(entry);
            return await Task.CompletedTask;
        }

        public async Task DeleteEntryAsync(Guid id)
        {
            var index = entrys.FindIndex(existingEntry => existingEntry.Id == id);
            entrys.RemoveAt(index);
            return await Task.CompletedTask;
        }

        public async Task<IEnumerable<EntryDto>> GetEntriesAsync()
        {
            var dbUsers = await _context.Users.ToListAsync();
            return await Task.FromResult(entrys);

        }

        public async Task<EntryDto> GetEntryAsync(Guid id)
        {
            var entry = entrys.SingleOrDefault(entry => entry.Id == id)!;
            return await Task.FromResult(entry);
        }

        public async Task UpdateEntryAsync(UpdateUserDto entry)
        {
            var index = entrys.FindIndex(existingEntry => existingEntry.Id == entry.Id);
            entrys[index] = entry;
            return await Task.CompletedTask;
        }
    }

}
