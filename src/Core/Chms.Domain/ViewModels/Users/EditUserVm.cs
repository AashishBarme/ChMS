using System.ComponentModel.DataAnnotations;
using Chms.Domain.Common.Enums;

namespace Chms.Domain.ViewModels.Users
{

    public class UserDetailsVm
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserGroup UserGroup { get; set; }
        public string FirstName { get; set; }

        public string MiddleName { get; set; } = null;
        public string LastName { get; set; }
        public ActiveStatus IsActive { get; set; }
        public string UserImage { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }

        }
        public string UserMetaData {get; set;}
        public string UserImagePath {get; set;} = null;
    }

    public class EditUserVm 
    {
        public long Id {get; set;}
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Lastname is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "USername is required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "User Group is required")]
        public int UserGroup { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Active Status is required")]
        public int IsActive { get; set; }
        public string UserMetaData {get; set;}
        public string UserImagePath {get; set;} = null;
    }

    public class BioDataEditVm
    {
        public string BioData {get; set;}
        public string FacebookId {get; set;}
        public string InstagramId {get; set;}
        public string Twitter {get; set;}
    }
}