using Flunt.Validations;
namespace DevAvaliacao.Domain.DataContext.Entities
{
    public class Patient : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }

        public bool Validate()
        {
            AddNotifications(new Contract()
                .HasMinLen(Name, 3, "Name", "O nome do paciente deve conter pelo menos 3 caracteres")
                .IsNotNullOrEmpty(Phone, "Phone", "Informe o telefone do paciente")
                .IsEmail(Email, "Email", "Email inválido")
                .HasLen(CPF, 11, "CPF", "CPF inválido")
            );
            return Valid;
        }
    }
}