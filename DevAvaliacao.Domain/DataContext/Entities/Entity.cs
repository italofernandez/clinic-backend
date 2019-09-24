using System;
using Flunt.Notifications;
namespace DevAvaliacao.Domain.DataContext.Entities
{
    public abstract class Entity : Notifiable
    {
        public Entity()
        {
            CreationDate = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime CreationDate { get; private set; }
    }
}