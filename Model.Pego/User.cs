using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// НУЖНО ДОБАВИТЬ IDENTITY

namespace Model.Pego
{
    public class User: BaseEntity, IEntity, IUser<Guid>
    {
        public User ():base()
        {
            this.DateCreated = DateTime.Now;
            this.Phones = new HashSet<Phone>();
            this.Emails = new HashSet<Email>();
            this.Accounts = new HashSet<Account>();
            this.Reminders = new HashSet<Reminder>();
            this.UserProjects = new HashSet<UserProject>();
        }

        public DateTime? DateCreated { get; set; }
        [MaxLength(25)]
        public virtual string UserName { get; set;}
        [MaxLength(25)]
        public virtual string FirstName { get; set;}
        [MaxLength(25)]
        public virtual string LastName { get; set; }
        public virtual DateTime? DOB { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
        public virtual ICollection<Email> Emails { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
            public Guid UserSettingsId { get; set; }    
        [ForeignKey("UserSettingsId")]
        public virtual UserSettings UserSettings { get; set; }
        public virtual ICollection<Reminder> Reminders { get; set; }
        public Guid SysRoleId { get; set; }
        [ForeignKey("SysRoleId")]
        public virtual SysRole SysRole { get; set; }
        public virtual ICollection<UserProject> UserProjects { get; set; }
    }
}
