using System;
using System.Collections.Generic;

namespace OneVirtualVoice.Models
{
    public class Patient
    {
        public string Id { get; set; }

        public DateTime BirthDate
        {
            get
            {
                if (Id == "Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB")
                {
                    _birthDate = new DateTime(1959,8,1);
                }
                return _birthDate;
            }
            set => _birthDate = value;
        }

        public string Gender { get; set; }
        public Name[] Name { get; set; }
        public Communication[] Communication { get; set; }
        public Allergy Allergies { get; set; }
        public Observations VitalSigns { get; set; }

        public string Status
        {
            get
            {
                switch (Id)
                {
                    case "Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB":
                        return "Do Not Resuscitate";
                    case "TUKRxL29bxE9lyAcdTIyrWC6Ln5gZ-z7CLr2r-2SY964B":
                        return "Do Not Resuscitate";
                    case "ToHDIzZiIn5MNomO309q0f7TCmnOq6fbqOAWQHA1FRjkB":
                        return "Full Code";
                    case "TbsWqA46u3BtlZT2KSkx5cZOT1o0mGbI3VPAGXv6XcdEB":
                        return "Partial Code";
                    default:
                        return "Undetermined";
                }
            }
        }

        public Observations Imaging { get; set; }

        public static readonly Dictionary<string, string> AllPatients = new Dictionary<string, string>() {
            {"Tbt3KuCY0B5PSrJvCu2j-PlK.aiHsu2xUjUM8bWpetXoB", "Jason Argonaut"},
            {"TUKRxL29bxE9lyAcdTIyrWC6Ln5gZ-z7CLr2r-2SY964B", "Jessica Argonaut"},
            {"ToHDIzZiIn5MNomO309q0f7TCmnOq6fbqOAWQHA1FRjkB", "James T Kirk"},
            {"TbsWqA46u3BtlZT2KSkx5cZOT1o0mGbI3VPAGXv6XcdEB", "Daisy Tinsley"}
        };

        private DateTime _birthDate;
    }

    public class Name
    {
        public string Text { get; set; }
    }
    
    public class Communication
    {
        public Language Language { get; set; }   
    }

    public class Language
    {
        public string Text { get; set; }
    }
}