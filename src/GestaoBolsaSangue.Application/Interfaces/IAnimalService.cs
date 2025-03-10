using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoBolsaSangue.Application.Interfaces
{
    public interface IAnimalService
    {
        Task<IList<DTOs.Animal.AnimalDTO>> Listar();
        Task<DTOs.Animal.AnimalDTO> Obter(Guid id);
    }
}
