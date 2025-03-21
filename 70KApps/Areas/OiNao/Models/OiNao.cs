using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _70KApps.Areas.OiNao.Models
{
    [Table("Contact", Schema = "OiNao")]
    public class OiNaoContact
    {
        //Tracking Info
        [Key]
        public int ID { get; set; }
        //Basic Info
        public string title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string suffix { get; set; }
        public string nickname { get; set; }
        public string GivenYomi { get; set; }
        public string SurnameYomi { get; set; }
        public string Company { get; set; }
        public string OfficeLocation { get; set; }

        //Auditing Information
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }

        //Connections
        public List<OiNaoEmail> AssociatedEmails { get; set; }
        public List<OiNaoAddress> AssociatedAddresses { get; set; }
        public List<OiNaoRelationship> AssociatedContacts { get; set; }
        public List<OiNaoContactNumber> AssociatedContactNumbers { get; set; }

        //Functions
        public string getDisplayName()
        {
            string contactName = "";

            if (!this.title.Equals(null))
            {
                contactName = this.title;
            }

            if (!this.nickname.Equals(null))
            {
                contactName += " " + this.nickname + " " + this.LastName;
            }
            else
            {
                if (!this.GivenYomi.Equals(null))
                {
                    contactName += " " + this.GivenYomi + " " + this.SurnameYomi;
                }
                else
                {
                    contactName += " " + this.FirstName + " " + this.LastName;
                }
            }

            if (!this.suffix.Equals(null))
            {
                contactName += " " + this.suffix;
            }

            return contactName;
        }
    }

    [Table("Email", Schema = "OiNao")]
    public class OiNaoEmail
    {
        //Tracking Info
        [Key]
        public int ID { get; set; }
        public int OiNaoContactID { get; set; }
        //Basic Info
        public string emailaddress { get; set; }
        public bool primary { get; set; }
        public string type { get; set; }

        //Auditing Information
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    [Table("Addresses", Schema = "OiNao")]
    public class OiNaoAddress
    {
        //Tracking Info
        [Key]
        public int ID { get; set; }
        public int OiNaoContactID { get; set; }
        //Basic Info
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string type { get; set; }

        //Auditing Information
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }

        //Functions
        public string getFormattedAddress()
        {
            string formattedAddress = "";

            //If HTML needed, rewrite later
            formattedAddress = this.Street1;
            formattedAddress += " " + this.Street2;
            formattedAddress += " " + this.City;
            formattedAddress += ", " + this.State;
            formattedAddress += ", " + this.Country;
            formattedAddress += " " + this.PostalCode;

            return formattedAddress;
        }
    }

    [Table("ContactNumber", Schema = "OiNao")]
    public class OiNaoContactNumber
    {
        //Tracking Info
        [Key]
        public int ID { get; set; }
        public int OiNaoContactID { get; set; }
        //Basic Info
        public string contactNumber { get; set; }
        public bool primary { get; set; }
        public string type { get; set; }

        //Auditing Information
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }

    [Table("Relationship", Schema = "OiNao")]
    public class OiNaoRelationship
    {
        //Tracking Info
        [Key]
        public int ID { get; set; }
        public int OiNaoContactA { get; set; }
        public int OiNaoContactB { get; set; }
        public int relationshipA { get; set; }
        public int relationshipB { get; set; }
    }
}