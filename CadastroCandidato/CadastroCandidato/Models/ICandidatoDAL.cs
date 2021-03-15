using System.Collections.Generic;

namespace CadastroCandidato.Models
{
    interface ICandidatoDAL
    {
        IEnumerable<Candidato> GetAllCandidatos();
        void AddCandidato(Candidato candidato);
        void UpdateCandidato(Candidato candidato);
        Candidato GetCandidato(int CandidatoID);
        void DeleteCandidato(int? CandidatoID);
    }
}
