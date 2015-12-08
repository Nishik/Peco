using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Pego
{
    public class User: BaseEntity, IEntity
    {
        public User ():base()
        {
            this.DateCreated = DateTime.Now;
            this.Phones = new List<Phone>();
            this.Emails = new List<Email>();
            this.Accounts = new List<Account>();
            this.Reminders = new HashSet<Reminder>();
        }

        public DateTime? DateCreated { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set;}
        [MaxLength(25)]
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
            public Guid UserSettingsId { get; set; }    
        [ForeignKey("UserSettingsId")]
        public virtual UserSettings UserSettings { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
        public Guid SysRoleId { get; set; }
        [ForeignKey("SysRoleId")]
        public SysRole SysRole { get; set; }
        //КАК ХРАНИТЬ ПАРОЛЬ
        //public string Password { get; set; }
    }
}
