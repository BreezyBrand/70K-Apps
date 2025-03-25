using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace _70KApps.Areas.OiNao.Models
{
    [Table("Contact", Schema = "OiNao")]
    public class OiNaoContact
    {
        //Tracking Info
        [Key]
        public int ID { get; set; }
        //Basic Info
        public string? title { get; set; } = "";
        public string? FirstName { get; set; } = "";
        public string? MiddleName { get; set; } = "";
        public string? LastName { get; set; } = "";
        public string? suffix { get; set; } = "";
        public string? nickname { get; set; } = "";
        public string? GivenYomi { get; set; } = "";
        public string? SurnameYomi { get; set; } = "";
        public string? Company { get; set; } = "";
        public string? OfficeLocation { get; set; } = "";
        public string? notes { get; set; } = "";

        //Auditing Information
        public string? CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string? UpdatedBy { get; set; }
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

            if (!this.title.Equals(""))
            {
                contactName = this.title;
            }

            if (!this.nickname.Equals(""))
            {
                contactName += " " + this.nickname + " " + this.LastName;
            }            

            if (!this.suffix.Equals(""))
            {
                contactName += " " + this.suffix;
            }

            return contactName;
        }

        public OiNaoContact reinitialize()
        {
            if (this.FirstName == null || this.FirstName == string.Empty) { this.FirstName = ""; }
            if (this.MiddleName == null || this.MiddleName == string.Empty) { this.MiddleName = ""; }
            if (this.LastName == null || this.LastName == string.Empty) { this.LastName = ""; }
            if (this.title == null || this.title == string.Empty) { this.title = ""; }
            if (this.suffix == null || this.suffix == string.Empty) { this.suffix = ""; }
            if (this.GivenYomi == null || this.GivenYomi == string.Empty) { this.GivenYomi = ""; }
            if (this.SurnameYomi == null || this.SurnameYomi == string.Empty) { this.SurnameYomi = ""; }
            if (this.nickname == null || this.nickname == string.Empty) { this.nickname = ""; }
            if (this.Company == null || this.Company == string.Empty) { this.Company = ""; }
            if (this.OfficeLocation == null || this.OfficeLocation == string.Empty) { this.OfficeLocation = ""; }
            return this;
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
        public string primary { get; set; }
        public string type { get; set; }

        //Auditing Information
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }

        public string DisplayPrimary()
        {
            if (this.primary.Equals("Y"))
            {
                return "Yes";
            }
            return "No";
        }

        public string DisplayType()
        {
            if (this.type.Equals("W"))
            {
                return "Work";
            }
            return "Personal";
        }
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
        public string getFormattedAddress(string rtype)
        {
            string formattedAddress = "";

            if (rtype.Equals("A"))
            {
                //If HTML needed, rewrite later
                formattedAddress = this.Street1;
                formattedAddress += " " + this.Street2;
            }
            else
            {
                formattedAddress += " " + this.City;
                formattedAddress += ", " + this.State;
                formattedAddress += ", " + this.Country;
                formattedAddress += " " + this.PostalCode;
            }
            return formattedAddress;
        }
        public OiNaoAddress reinitialize()
        {
            if (this.Street1 == null || this.Street1 == string.Empty) { this.Street1 = ""; }
            if (this.Street2 == null || this.Street2 == string.Empty) { this.Street2 = ""; }
            if (this.City == null || this.City == string.Empty) { this.City = ""; }
            if (this.State == null || this.State == string.Empty) { this.State = ""; }
            if (this.Country == null || this.Country == string.Empty) { this.Country = ""; }
            if (this.PostalCode == null || this.PostalCode == string.Empty) { this.PostalCode = ""; }
            if (this.type == null || this.type == string.Empty) { this.type = ""; }
            return this;
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
        public string primary { get; set; }
        public string type { get; set; }

        //Auditing Information
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }

        //Functions
        public string DisplayPrimary()
        {
            if (this.primary.Equals("Y"))
            {
                return "Yes";
            }
            return "No";
        }

        public string DisplayType()
        {
            if (this.type.Equals("H"))
            {
                return "Home";
            }
            if (this.type.Equals("C"))
            {
                return "Cell";
            }

            if (this.type.Equals("W"))
            {
                return "Work";
            }

            if (this.type.Equals("F"))
            {
                return "Fax";
            }
            return "Other";
        }
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
        //Auditing Information
        public string CreatedBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}