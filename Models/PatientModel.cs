using System.ComponentModel.DataAnnotations;
namespace ShaneSampleApp.Models
{
    public class PatientModel
    {
        public enum GenderType
        {        
            Male=1,
            Female=2,
            Other=3
        }

        [Key()]
        public string Id { get; set; }

        [Required(ErrorMessage = "First Name Required!")]
        [Display(Name = "First Name")]        
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last Name Required!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Phone Number Required!")]
        [Display(Name = "Last Name")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Email Required!")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Not a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Gender Required!")]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Gender Required!")]
        [Display(Name = "GenderText")]
        public string GenderText
        {
            get
            {
                switch (Gender)
                {
                    case "MALE":
                        return "Male";
                    case "FEMALE":
                        return "Female";
                    case "UNSPECIFIED":
                        return "Unspecified";
                    default:
                        return "error:unknown";

                }
            }
        }
        [Display(Name = "Notes")]
        public string Notes { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string CreatedDate { get; set; }
        
        [DataType(DataType.DateTime)]
        public string LastUpdatedDate { get; set; }

        public string IsDeleted { get; set; } = "0";
    }
}