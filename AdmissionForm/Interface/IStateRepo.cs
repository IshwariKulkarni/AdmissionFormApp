using AdmissionForm.Models;

namespace AdmissionForm.Interface
{
    public interface IStateRepo
    {
        Task<IEnumerable<State>> GetStatesAsync();
        Task AddStateAsync(State state);

        State GetStateById(int stateId);
    }
}
