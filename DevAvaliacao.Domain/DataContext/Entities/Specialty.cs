using Flunt.Validations;
namespace DevAvaliacao.Domain.DataContext.Entities
{
    public class Specialty : Entity
    {
        public string Name { get; set; }

        bool Validate()
        {
            AddNotifications(new Contract()
                .HasMinLen(Name, 3, "Name", "O nome do paciente deve conter pelo menos 3 caracteres")
            );
            return Valid;
        }
    }
}