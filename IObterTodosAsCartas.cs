using Revisao.Application.ViewModels;

namespace Revisao.Application.Interfaces
{
    public interface IObeterTodosAsCartas
    {
        Task<IEnumerable<IObeterTodosAsCartasViewModel>> IObeterTodosAsCartas();
    }
}