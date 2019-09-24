using Flunt.Validations;

namespace DevAvaliacao.Domain.DataContext.Entities
{
    public class Doctor : Entity
    {
        public string Name { get; set; }
        public string CRM { get; set; }
        public int SpecialtyId { get; set; }
        public bool IsGeneralist { get; set; }
        public virtual Specialty Specialty { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Name, "Name", "Informe o nome do médico")
                .IsNotNullOrEmpty(CRM, "CRM", "Informe o CRM do médico")
                .IsFalse((!IsGeneralist && SpecialtyId == 0), "SpecialtyId", "Selecione uma especialidade")
            );
            return Valid;
        }
    }
}