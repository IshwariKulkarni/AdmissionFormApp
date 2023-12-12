using AdmissionForm.AdmissionApp;
using AdmissionForm.Interface;
using AdmissionForm.Models;
using Microsoft.EntityFrameworkCore;

namespace AdmissionForm.Repository
{
    public class StateRepo : IStateRepo
    {
        private readonly AppDbContext _context;

        public StateRepo(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            return await _context.States.ToListAsync();
        }

        public async Task AddStateAsync(State state)
        {
            _context.States.Add(state);
            await _context.SaveChangesAsync();
        }

        public State GetStateById(int stateId)
        {
            return _context.States.FirstOrDefault(s => s.StateId == stateId);
        }
    }
}
