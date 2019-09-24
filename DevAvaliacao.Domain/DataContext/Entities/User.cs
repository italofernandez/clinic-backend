using Flunt.Validations;
namespace DevAvaliacao.Domain.DataContext.Entities
{
    public class User : Entity
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        bool Validate()
        {
            AddNotifications(new Contract()
                .HasMinLen(Name, 3, "Name", "O nome do usuário deve conter pelo menos 3 caracteres")
                .HasMinLen(Login, 3, "Login", "O login deve conter pelo menos 3 caracteres")
                .HasMinLen(Password, 6, "Password", "A senha deve conter pelo menos 6 caracteres")
                .IsEmail(Email, "Email", "Email inválido")
            );
            return Valid;
        }
    }
}